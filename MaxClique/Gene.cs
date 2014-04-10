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
        List<bool> bitList { get; set; }

        public Gene(int size)
        {
            bitString = new bool[size];
            bitList = bitString.ToList<bool>();
        }

        internal bool frndInClique(Friend f1, Neo neo)
        {
            foreach (bool bit in bitList)
                if (bit == true)
                {
                    int localID = bitList.IndexOf(bit);
                    Friend f2 = neo.getUser(localID);
                    if (!neo.friends(f1, f2))
                        return false;
                }
            return true;

        }

        internal void calcFitness()
        {
            fitness = 0;
            foreach (bool bit in bitList)
                if (bit == true)
                    fitness++;
        }
    }
}
