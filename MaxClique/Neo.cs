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
        GraphClient client = new GraphClient(new Uri("http://localhost:7474/db/data"));
        public void createUser(Friend newFriend)
        {
            client.Connect();
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
                .Create("friend1-[:FRIENDS_WITH]->friend2")
                .ExecuteWithoutResults();
        }
    }
}
