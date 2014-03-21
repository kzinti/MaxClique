namespace MaxClique
{
    partial class FBLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // loginWebBrowser
            // 
            this.loginWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.loginWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.loginWebBrowser.Name = "loginWebBrowser";
            this.loginWebBrowser.Size = new System.Drawing.Size(718, 388);
            this.loginWebBrowser.TabIndex = 0;
            this.loginWebBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.loginWebBrowser_Navigated);
            // 
            // FBLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 388);
            this.Controls.Add(this.loginWebBrowser);
            this.Name = "FBLogin";
            this.Text = "fblogin";
            this.Load += new System.EventHandler(this.FBLogin_Load);
            this.Shown += new System.EventHandler(this.FBLogin_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser loginWebBrowser;
    }
}