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
        private Gene[] population = new Gene[100];
        int numFriends = 0;
        private Random rand = new Random(1);
        Neo neo;
        private List<Friend> _friends = new List<Friend>();
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

        private void initializePopulation()
        {
            for (int i = 0; i < numFriends; i++)
            {
                population[i] = new Gene(numFriends, rand);
            }
        }

        private void testFitness()
        {
            foreach (Gene gene in population)
            {
            }
        }

        private void selectFitest()
        {
        }

        private void recombine()
        {
        }

        private void mutate()
        {
        }

        private void replace()
        {
        }

        private void terminate()
        {
        }

    }
}
