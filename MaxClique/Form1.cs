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
        private Evolve evolve;
        private GraphBuilder gb;
        private FBLogin fbLoginBrowser;
        private FacebookConnection fc = new FacebookConnection();

        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();
            db = new Neo();
            gb = new GraphBuilder(db, fc);
            evolve = new Evolve(db);
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
            UpdateListView();
        }

        private void initPopulation_Click(object sender, EventArgs e)
        {
            //evolve.rndUserNFriends();
            gb.setLocalIDs();
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

        #region ListView Helpers

        private void UpdateListView()
        {

            friendsListView.Items.Clear();

            foreach (Friend friend in evolve.getFriends())
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
    }
}
