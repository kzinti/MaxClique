﻿using System;
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
        GraphClient client = new GraphClient(new Uri("http://192.168.0.100:7474/db/data"));

        public Neo()
        {
            client.Connect();
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
                .OptionalMatch("(user:Friend)-[FRIENDS_WITH]-(friend:Friend)")
                .Where((Friend user) => user.ID == usr.ID)
                .Return((user, friend) => new {
                    user = user.As<Friend>(),
                    friends = friend.CollectAs<Friend>()
                })
                .Results;
            return (UserNFriends) usrWfrnd;
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

        public void setLocalID(Friend usr, int ID)
        {
            client.Cypher
                .Match("(user:Freind)")
                .Where((Friend user) => user.ID == usr.ID)
                .Set("user.localID = {localID}")
                .WithParam("localID", ID)
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
    }
}
