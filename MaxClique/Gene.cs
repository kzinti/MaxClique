﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxClique
{
    public class Gene
    {
        public int ID { get; set; }
        public bool[] bitString { get; set; }
        public int fitness { get; set; }

        public Gene(int size)
        {
            bitString = new bool[size];
        }

        internal void calcFitness()
        {
            fitness = 0;
            foreach (bool bit in bitString)
                if (bit == true)
                    fitness++;
        }
    }
}