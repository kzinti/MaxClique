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

        public Gene(int numFriends)
        {
            bitString = new bool[numFriends];
        }
    }

}
