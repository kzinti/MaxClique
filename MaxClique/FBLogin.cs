using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;

namespace MaxClique
{
    public partial class FBLogin : Form
    {

        #region Local Variable Declaration

        private List<Friend> _friends = new List<Friend>();
        private bool _authorized;
        private string _accessToken = "";
        //private string _currentName = "";
        private string _loginUrl = "";

        #endregion

        #region Property wrappers for some of the application settings

        public string AccessToken
        {
            get { return this._accessToken; }
        }

        public bool Authorized
        {
            get { return this._authorized; }
        }
        
        public string ApplicationId
        {
            get { return Properties.Settings.Default.ApplicationId; }
        }

        public string AppSecret
        {
            get { return Properties.Settings.Default.AppSecret; }
        }

        #endregion

        #region Constructor
        public FBLogin()
        {
            InitializeComponent();
        }
        #endregion


        private void FBLogin_Load(object sender, EventArgs e)
        {
            _loginUrl = GenerateLoginUrl();
        }

        private void FBLogin_Shown(object sender, EventArgs e)
        {
            loginWebBrowser.Navigate(_loginUrl);
        }

        private void loginWebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            var fb = new FacebookClient();

            FacebookOAuthResult oauthResult;
            if (fb.TryParseOAuthCallbackUrl(e.Url, out oauthResult))
            {
                if (oauthResult.IsSuccess)
                {
                    _accessToken = oauthResult.AccessToken;
                    _authorized = true;
                    loginWebBrowser.Hide();
                    this.Hide();
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

        private string GenerateLoginUrl()
        {

            dynamic parameters = new ExpandoObject();
            parameters.client_id = ApplicationId;
            parameters.redirect_uri = "https://www.facebook.com/connect/login_success.html";
            parameters.response_type = "token";
            parameters.display = "popup";

            var fb = new FacebookClient();

            Uri loginUri = fb.GetLoginUrl(parameters);
            return loginUri.AbsoluteUri;
        }

    }
}
