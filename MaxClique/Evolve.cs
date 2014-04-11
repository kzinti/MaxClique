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
            Neo neo;
            int generation = 0;
            List<Gene> selected;
            int crossoverPoints = 10;
            Random rand = new Random(1);
            Gene[] population = new Gene[100];
            List<Friend> _friends = new List<Friend>();
        #endregion

        #region Constructor
            public Evolve(Neo db)
            {
                neo = db;
                allFriends();
            }
        #endregion

        #region Helper Methods
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

            private void allFriends()
            {
                _friends = neo.allFriends(); 
            }
        #endregion

        private void initialization()
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
                    if (gene.frndInClique(fx, neo))
                        // set fx as part of the clique
                        gene.bitString[fx.localID] = true;
                }
                // calculate the fitness of each gene 
                // as they are created
                gene.calcFitness();
            }
        }

        private void selection()
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

        private void recombination()
        {
        }

        private void mutation()
        {
        }

        private void extraction()
        {
        }

        private void replacement()
        {
        }

        private void termination()
        {
        }

    }
}
