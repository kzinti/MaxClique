using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;

namespace MaxClique
{
    public class FacebookConnection
    {
        private bool _authorized;
        private string _accessToken;
        private List<Friend> _friends = new List<Friend>();
        FacebookClient fb;

        public Friend[] friendsArray()
        {
            return this._friends.ToArray();
        }

        public string ApplicationId
        {
            get { return Properties.Settings.Default.ApplicationId; }
        }

        public string AppSecret
        {
            get { return Properties.Settings.Default.AppSecret; }
        }

        public void loginSuccess(WebBrowserNavigatedEventArgs e)
        {
            FacebookOAuthResult oauthResult;
            if (fb.TryParseOAuthCallbackUrl(e.Url, out oauthResult))
            {
                if (oauthResult.IsSuccess)
                {
                    _accessToken = oauthResult.AccessToken;
                    _authorized = true;
                    fb = new FacebookClient(_accessToken);
                    return;
                }
                else
                {
                    _accessToken = "";
                    _authorized = false;
                    MessageBox.Show("Couldn't log into Facebook!", "Login unsuccessful", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        public string GenerateLoginUrl()
        {

            dynamic parameters = new ExpandoObject();
            parameters.client_id = ApplicationId;
            parameters.redirect_uri = "https://www.facebook.com/connect/login_success.html";
            parameters.response_type = "token";
            parameters.display = "popup";

            fb = new FacebookClient();

            Uri loginUri = fb.GetLoginUrl(parameters);
            return loginUri.AbsoluteUri;
        }

        public bool areFriends(Friend f1, Friend f2)
        {
            dynamic friendsTaskResult = fb.Get("/" + f1.ID + "/friends/" + f2.ID);
            var result = (IDictionary<string, object>)friendsTaskResult;
            var data = (IEnumerable<object>)result["data"];
            
            if (data.Count() > 0)
                return true;
            else
                return false;
        }

        async public void getFriendsList()
        {
            if (_authorized)
            {
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
            }
            else
            {
                MessageBox.Show("Not logged into Facebook!", "Not Currently Logged In", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
