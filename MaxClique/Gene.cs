using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxClique
{
    public class Gene
    {
        public bool[] bitString { get; set; }
        public int fitness { get; set; }

        public Gene(int numFriends, Random rand)
        {
            bitString = new bool[numFriends];
            for (int i = 0; i < numFriends; i++ )
            {
                bitString[i] = randomBit(rand);
            }
        }

        private bool randomBit(Random rand)
        {
            if (rand.Next(2) == 0)
                return false;
            else
                return true;
        }
    }

}
