using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxClique
{
    class Evolve
    {
        #region Local Variable Declaration
        Neo neo;                                        // database connection
        int generation = 0;                             // generation counter
        int numFriends = 85;
        List<Gene> selected;                            // list of genes selected for recombination
        int numGenerations = 20;                        // number of generations before reducing crossover and mutation
        int crossoverPoints = 10;                       // number of crossover points
        double mutationAmount = .2;                     // amount of gene that will be mutated
        double mutationPercent = .5;                    // likelyhood that a gene will be mutated
        Random rand = new Random(1);                    // random number generator. this is passed to any function that needs random so can be controled
        Gene[] population = new Gene[100];              // the population to evolve
        List<Gene> childred = new List<Gene>();         // list of children created by recombination
        List<Friend> _friends = new List<Friend>();     // friends list to hold all friends
        #endregion

        #region Constructor
        public Evolve(Neo db)
        {
            neo = db;
            allFriends();
        }
        #endregion

        #region Genetic Functions

        internal void evolve()
        {
            initialize();
            while (terminate() == false)
            {
                generation++;
                if (generation >= numGenerations)
                {
                    if (crossoverPoints > 2)
                        crossoverPoints -= 2;
                    if (mutationPercent > .05)
                        mutationPercent -= .05;
                    if (mutationAmount > .05)
                        mutationAmount -= .05;
                    generation = 0;
                }

                selectParrents();
                recombineParents();
                mutateChildren();
                extractClique();
                replaceLessFit();
            }
        }

        private void initialize()
        {
            // get an array copy of _friends because 
            // it's easier to address by index
            Friend[] frndArray = _friends.ToArray();
            foreach (Gene gene in population)
            {
                // select a random friend f1 from the array
                Friend rnd = frndArray[rand.Next(frndArray.Length)];
                // get f1 and all of f1's friends
                UserNFriends f1nFriends = neo.getUserNFriends(rnd);
                // set f1 as part of the clique 
                gene.bitString[f1nFriends.user.localID] = true;
                // pop a random friend f2 from f1's list of friends
                Friend f2 = f1nFriends.popRndFrnd(rand);
                // set f2 as part of the clique
                gene.bitString[f2.localID] = true;
                // iterate through the remainder of f1's friend list
                while (f1nFriends.notEmpty())
                {
                    // pop random friend fx from f1's list of friends
                    Friend fx = f1nFriends.popRndFrnd(rand);
                    // if part of the clique
                    if (frndInClique(fx))
                        // set fx as part of the clique
                        gene.bitString[fx.localID] = true;
                }
                // calculate the fitness of each gene 
                // as they are created
                gene.calcFitness();
            }
        }

        private void selectParrents()
        {
            selected.Clear();
            int populationFitness = 0;
            // calculate total fitness of population
            foreach (Gene gene in population)
            {
                populationFitness += gene.fitness;
            }

            selected.Add(selectHelper(populationFitness));
            selected.Add(selectHelper(populationFitness));
        }

        private void recombineParents()
        {
            Gene p1 = selected.ElementAt<Gene>(0);
            Gene p2 = selected.ElementAt<Gene>(1);

            Gene c1 = new Gene(p1.bitString.Length);
            Gene c2 = new Gene(p2.bitString.Length);

            double t = (p1.bitString.Length / crossoverPoints);
            int split = (int) Math.Floor(t);
            bool flip = false;
            for (int i = 0; i < p1.bitString.Length; i++)
            {
                if (flip == true)
                {
                    c1.bitString[i] = p1.bitString[i];
                    c2.bitString[i] = p2.bitString[i];
                }
                else
                {
                    c1.bitString[i] = p2.bitString[i];
                    c2.bitString[i] = p1.bitString[i];
                }

                if ((i % split) == 0)
                {
                    if (flip == true)
                        flip = false;
                    else
                        flip = true;
                }
            }
            childred.Add(c1);
            childred.Add(c2);
        }

        private void mutateChildren()
        {
            if ( rand.NextDouble() < mutationPercent)
            {
                int rnd = rand.Next(numFriends);
                if (childred[0].bitString[rnd] == false)
                    childred[0].bitString[rnd] = true;
                else
                    childred[0].bitString[rnd] = false;
            }

        }

        private void extractClique()
        {
            foreach (Gene g in childred)
            {
                while (!isClique(g))
                    removeSmallest(g);
            }
        }

        private void replaceLessFit()
        {
        }

        private bool terminate()
        {
            return false;
        }

        #endregion

        #region Helper Methods

        private void allFriends()
        {
            _friends = neo.allFriends(); 
        }

        public Friend[] getFriends()
        {
            return _friends.ToArray();
        }

        public void rndUserNFriends()
        {
            var friendsArray = _friends.ToArray();
            int index = rand.Next(_friends.Count);
            var rndFriend = friendsArray[index];
            var userNFriends = neo.numFriends(rndFriend);
        }

        private bool isClique(Gene g)
        {
            for (int i = 0; i < g.bitString.Length; i++)
                if (g.bitString.ElementAt<bool>(i)==true)
                    for (int j = i + 1; j < g.bitString.Length; j++)
                        if (g.bitString.ElementAt<bool>(j)==true)
                            if (!neo.friends(neo.getUser(i), neo.getUser(j)))
                                return false;
            return true;
        }

        private void removeSmallest(Gene g)
        {
            for (int i = g.bitString.Length; i > 0; i--)
                if (g.bitString.ElementAt<bool>(i) == true)
                {
                    g.bitString[i] = false;
                    break;
                }
        }

        private bool frndInClique(Friend f1)
        {
            foreach (bool bit in g.bitString)
                if (bit == true)
                {
                    int localID = g.bitList.IndexOf(bit);
                    Friend f2 = neo.getUser(localID);
                    if (!neo.friends(f1, f2))
                        return false;
                }
            return true;

        }

        private Gene selectHelper(int popFit)
        {
            // create a random number between 0 and 1
            double percent = rand.NextDouble();
            int partialFitness = 0;
            Gene rtn = population[0];

            // itterate through genes
            foreach (Gene gene in population)
            {
                if (percent < (partialFitness / popFit))
                    return gene;
                rtn = gene;
                partialFitness += gene.fitness;
            }
            return rtn;
        }

        #endregion

    }
}