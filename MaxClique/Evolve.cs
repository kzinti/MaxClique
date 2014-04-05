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

        private void terminate()
        {
        }

    }
}
