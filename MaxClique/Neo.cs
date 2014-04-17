using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;

namespace MaxClique
{
    class Neo
    {
        GraphClient client = new GraphClient(new Uri("http://192.168.0.101:7474/db/data"));

        public Neo()
        {
            client.Connect();
        }

        internal bool friends(Friend f1, Friend f2)
        {
            var daFriends = client.Cypher
                .Match("(u1:Friend)", "(u2:Friend)")
                .Where((Friend u1) => u1.ID == f1.ID)
                .AndWhere((Friend u2) => u2.ID == f2.ID)
                .AndWhere("(u1)-[:FRIENDS_WITH]-(u2)")
                .Return((u1) => u1.As<Friend>())
                .Results;
            if (daFriends.Count() > 0)
                return true;
            else
                return false;

        }

        public dynamic allFriends()
        {
            var allUsers = client.Cypher
                .Match("(users:Friend)")
                .Return((users) => users.As<Friend>())
                .Results;
            return allUsers;
        }

        public dynamic getUserNFriends(Friend usr)
        {
            var usrWfrnd = client.Cypher
                .Match("(user:Friend)-[FRIENDS_WITH]-(friend:Friend)")
                .Where((Friend user) => user.ID == usr.ID)
                .Return((user, friend) => new {
                    user = user.As<Friend>(),
                    _friends = friend.CollectAs<Friend>()
                })
                .Results.ToList();
            //Friend[] fndary = new Friend[usrWfrnd.ElementAt(0)._friends.Count()];
            List<Friend> fndlst = new List<Friend>();
            if (usrWfrnd.ElementAt(0)._friends.Count() > 0)
            {
                foreach (var f in usrWfrnd.ElementAt(0)._friends)
                {
                    fndlst.Add(f.Data);
                }
            }
            UserNFriends rtn = new UserNFriends { _friends = fndlst, user = usrWfrnd.ElementAt(0).user };
            return rtn;
        }

        public dynamic numFriends(Friend usr)
        {
            var frndC = client.Cypher
                .OptionalMatch("(user:Friend)-[FRIENDS_WITH]-(friend:Friend)")
                .Where((Friend user) => user.ID == usr.ID)
                .Return((friend) => friend.Count() )
                .Results;
            int num = (int)frndC.ElementAt<long>(0);
            return num;
        }

        #region Helpers to Build the Local Graph

        public void setLocalID(Friend usr, int localID)
        {
            client.Cypher
                .Match("(user:Friend)")
                .Where((Friend user) => user.ID == usr.ID)
                .Set("user.localID = {localID}")
                .WithParam("localID", localID)
                .ExecuteWithoutResults();
        }

        public void setNumFriends(Friend usr, int numFriends)
        {
            client.Cypher
                .Match("(user:Friend)")
                .Where((Friend user) => user.ID == usr.ID)
                .Set("user.numFriends = {numFriends}")
                .WithParam("numFriends", numFriends)
                .ExecuteWithoutResults();
        }

        public void createUser(Friend newFriend)
        {
            client.Cypher
                .Create("(friend:Friend {newFriend})")
                .WithParam("newFriend", newFriend)
                .ExecuteWithoutResults();
        }

        public void relateUsers(Friend fnd1, Friend fnd2)
        {
            client.Cypher
                .Match("(friend1:Friend)", "(friend2:Friend)")
                .Where((Friend friend1) => friend1.ID == fnd1.ID)
                .AndWhere((Friend friend2) => friend2.ID == fnd2.ID)
                .CreateUnique("friend1-[:FRIENDS_WITH]->friend2")
                .ExecuteWithoutResults();
        }

        #endregion

        internal Friend getUser(int localID)
        {
            Friend frnd = (Friend)client.Cypher
                .Match("(u:Friend)")
                .Where((Friend u) => u.localID == localID)
                .Return(u => u.As<Friend>())
                .Results.ElementAt(0);
            return frnd;
        }
    }
}