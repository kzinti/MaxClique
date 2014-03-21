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
        private bool _authorized;
        private string _accessToken = "";
        private Gene[] population = new Gene[100];

        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Button Functions

        private void button1_Click(object sender, EventArgs e)
        {
           fbLoginBrowser.ShowDialog(); 
        }

        async private void button2_Click(object sender, EventArgs e)
        {
            _accessToken = fbLoginBrowser.AccessToken;
            _authorized = fbLoginBrowser.Authorized;

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

        #endregion

        #region Private Methods

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

    }
}
