using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Facebook;

namespace MaxClique
{
    public partial class Form1 : Form
    {
        #region Local Variable Declaration

        private List<Friend> _friends = new List<Friend>();
        private FBLogin fbLoginBrowser = new FBLogin();
        private Gene[] population = new Gene[100];
        private Random rand = new Random(1);
        private bool _authorized = false;
        private string _accessToken = "";
        private int numFriends = 0;
        private Neo db;

        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();
            db = new Neo();
        }

        #endregion

        #region Button Functions

        private void button1_Click(object sender, EventArgs e)
        {
           fbLoginBrowser.ShowDialog(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            authToken();
            getFriendsList();
        }

        private void initPopulation_Click(object sender, EventArgs e)
        {
            initializePopulation();
        }

        private void neoConnect_Click(object sender, EventArgs e)
        {
            populateGraph();
        }

        private void relateFriends_Click(object sender, EventArgs e)
        {
            createRelationships();
        }

        #endregion

        #region Evolve!

        private void initializePopulation()
        {
            for (int i = 0; i < numFriends; i++ )
            {
                population[i] = new Gene(numFriends, rand);
            }
        }

        private void testFitness()
        {
            foreach (Gene gene in population)
            {
            }
        }

        private void selectFitest()
        {
        }

        private void recombine()
        {
        }

        private void terminate()
        {
        }

        #endregion

        #region Helper Methods

        #region Local Graph Helpers

        private bool friends(Friend f1, Friend f2, FacebookClient fb)
        {
            dynamic friendsTaskResult = fb.Get("/"+f1.ID+"/friends/"+f2.ID);
            var result = (IDictionary<string, object>)friendsTaskResult;
            var data = (IEnumerable<object>)result["data"];
            if (data != null)
                return false;
            else
                return true;
        }

        private void populateGraph()
        {
            foreach (Friend frnd in _friends)
                db.createUser(frnd);
        }

        public void createRelationships()
        {
            var fb = new FacebookClient(_accessToken);
            var arrayFromList = _friends.ToArray();
            for (int i = 0; i < arrayFromList.Length; i++)
            {
                for (int k = i+1; k < arrayFromList.Length; k++)
                {
                    if (friends(arrayFromList[i], arrayFromList[k], fb))
                        db.relateUsers(arrayFromList[i], arrayFromList[k]);
                }
            }
        }

        #endregion

        #region ListView Helpers

        async private void getFriendsList()
        {
            if (_authorized)
            {
                var fb = new FacebookClient(_accessToken);

                dynamic friendsTaskResult = await fb.GetTaskAsync("/me/friends");
                var results = (IDictionary<string, object>)friendsTaskResult;
                var data = (IEnumerable<object>)results["data"];
                foreach (var item in data)
                {
                    var friend = (IDictionary<string, object>)item;
                    Friend newFriend = new Friend
                    {
                        Name = (string)friend["name"],
                        ID = (string)friend["id"]
                    };
                    _friends.Add(newFriend);
                }

                UpdateListView();

            }
            else
            {
                MessageBox.Show("Not logged into Facebook!", "Not Currently Logged In", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void UpdateListView()
        {

            friendsListView.Items.Clear();

            foreach (Friend friend in _friends)
            {
                AddFriendToListView(friend);
            }

        }

        private void AddFriendToListView(Friend friend)
        {
            ListViewItem newItem = new ListViewItem(friend.Name);

            newItem.Tag = friend.ID;

            friendsListView.Items.Add(newItem);
        }

        #endregion

        private void authToken()
        {
            _accessToken = fbLoginBrowser.AccessToken;
            _authorized = fbLoginBrowser.Authorized;
        }

        #endregion

    }
}
