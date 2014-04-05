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

        private Neo db;
        private int numFriends = 0;
        private FBLogin fbLoginBrowser;
        private FacebookConnection fc = new FacebookConnection();

        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();
            db = new Neo();
            fbLoginBrowser = new FBLogin(fc);
        }

        #endregion

        #region Button Functions

        private void button1_Click(object sender, EventArgs e)
        {
           //fbLoginBrowser.ShowDialog(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //fc.getFriendsList();
        }

        private void updateList_Click(object sender, EventArgs e)
        {
            //UpdateListView();
        }

        private void initPopulation_Click(object sender, EventArgs e)
        {
        }

        private void neoConnect_Click(object sender, EventArgs e)
        {
            //populateGraph();
        }

        private void relateFriends_Click(object sender, EventArgs e)
        {
            //createRelationships();
        }

        #endregion

        #region Helper Methods

        #region Local Graph Helpers

        private void populateGraph()
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

        #endregion

        #region ListView Helpers

        private void UpdateListView()
        {

            friendsListView.Items.Clear();

            foreach (Friend friend in fc.friendsArray())
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

        #endregion

    }
}
