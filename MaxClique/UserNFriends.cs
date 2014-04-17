using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxClique
{
    class UserNFriends
    {
        public Friend user { get; set; }
        public List<Friend> _friends { get; set; }
        //public Friend[] friends { get; set; }

        public bool notEmpty()
        {
            if (_friends.Count > 0)
                return true;
            return false;           
        }

        public Friend popRndFrnd(Random rnd)
        {
            int idx = rnd.Next(_friends.Count());
            Friend rtn = _friends.ElementAt<Friend>(idx);
            _friends.RemoveAt(idx);
            return rtn;
        }
    }
}