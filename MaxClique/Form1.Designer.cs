using System;
using System.Dynamic;
using Facebook;
namespace MaxClique
{
    partial class Form1
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
            this.FacebookLogin = new System.Windows.Forms.Button();
            this.friendsListView = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FacebookLogin
            // 
            this.FacebookLogin.Location = new System.Drawing.Point(561, 301);
            this.FacebookLogin.Name = "FacebookLogin";
            this.FacebookLogin.Size = new System.Drawing.Size(75, 38);
            this.FacebookLogin.TabIndex = 0;
            this.FacebookLogin.Text = "Facebook Login";
            this.FacebookLogin.UseVisualStyleBackColor = true;
            this.FacebookLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // friendsListView
            // 
            this.friendsListView.Location = new System.Drawing.Point(12, 12);
            this.friendsListView.Name = "friendsListView";
            this.friendsListView.Size = new System.Drawing.Size(543, 327);
            this.friendsListView.TabIndex = 2;
            this.friendsListView.UseCompatibleStateImageBehavior = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(561, 229);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "Get Fried List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 352);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.friendsListView);
            this.Controls.Add(this.FacebookLogin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FacebookLogin;
        private System.Windows.Forms.ListView friendsListView;
        private System.Windows.Forms.Button button2;

    }
}

