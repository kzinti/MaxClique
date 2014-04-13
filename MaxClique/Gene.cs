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
        internal List<bool> bitList { get; set; }

        public Gene(int size)
        {
            bitString = new bool[size];
            bitList = bitString.ToList<bool>();
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
