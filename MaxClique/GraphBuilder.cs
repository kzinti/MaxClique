using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxClique
{
    class GraphBuilder
    {
        #region Local Variable Declaration
        private Neo db;
        private FacebookConnection fc;
        #endregion

        #region Constructor
        public GraphBuilder(Neo neo, FacebookConnection fbconn)
        {
            neo = db;
            fc = fbconn;
        }
        #endregion

        public void populateGraph()
        {
            foreach (Friend frnd in fc.friendsArray())
                db.createUser(frnd);
        }

        public void createRelationships()
        {
            var friendsArray = fc.friendsArray();
            for (int i = 0; i < friendsArray.Length; i++)
                for (int k = i+1; k < friendsArray.Length; k++)
                    if (fc.areFriends(friendsArray[i], friendsArray[k]))
                        db.relateUsers(friendsArray[i], friendsArray[k]);
        }

        public void setUserNumFriends()
        {
            foreach (Friend friend in db.allFriends())
            {
                int nfriends = db.numFriends(friend);
                db.setNumFriends(friend, nfriends);
            }
        }

        public void setLocalIDs()
        {
            int i = 0;
            Friend[] friends = db.allFriends();
            IEnumerable<Friend> sortedFriends = friends.OrderBy(friend => friend.localID);
            foreach (Friend friend in sortedFriends)
            {
                db.setLocalID(friend, i);
                i++;
            }
        }


    }
}
