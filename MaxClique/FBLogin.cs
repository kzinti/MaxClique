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

        private string _loginUrl = "";
        FacebookConnection fc;

        #endregion

        #region Property wrappers for some of the application settings

        #endregion

        #region Constructor
        public FBLogin(FacebookConnection fbConn)
        {
            InitializeComponent();
            fc = fbConn;
        }
        #endregion


        private void FBLogin_Load(object sender, EventArgs e)
        {
            _loginUrl = fc.GenerateLoginUrl();
        }

        private void FBLogin_Shown(object sender, EventArgs e)
        {
            loginWebBrowser.Navigate(_loginUrl);
        }

        private void loginWebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            fc.loginSuccess(e);
        }



    }
}
