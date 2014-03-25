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
            this.initPopulation = new System.Windows.Forms.Button();
            this.neoConnect = new System.Windows.Forms.Button();
            this.relateFriends = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FacebookLogin
            // 
            this.FacebookLogin.Location = new System.Drawing.Point(561, 12);
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
            this.button2.Location = new System.Drawing.Point(561, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "Get Friend List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // initPopulation
            // 
            this.initPopulation.Location = new System.Drawing.Point(561, 100);
            this.initPopulation.Name = "initPopulation";
            this.initPopulation.Size = new System.Drawing.Size(75, 38);
            this.initPopulation.TabIndex = 4;
            this.initPopulation.Text = "Initialize Population";
            this.initPopulation.UseVisualStyleBackColor = true;
            this.initPopulation.Click += new System.EventHandler(this.initPopulation_Click);
            // 
            // neoConnect
            // 
            this.neoConnect.Location = new System.Drawing.Point(562, 145);
            this.neoConnect.Name = "neoConnect";
            this.neoConnect.Size = new System.Drawing.Size(75, 38);
            this.neoConnect.TabIndex = 5;
            this.neoConnect.Text = "Populate Local Graph";
            this.neoConnect.UseVisualStyleBackColor = true;
            this.neoConnect.Click += new System.EventHandler(this.neoConnect_Click);
            // 
            // relateFriends
            // 
            this.relateFriends.Location = new System.Drawing.Point(561, 189);
            this.relateFriends.Name = "relateFriends";
            this.relateFriends.Size = new System.Drawing.Size(75, 38);
            this.relateFriends.TabIndex = 6;
            this.relateFriends.Text = "Relate Friends";
            this.relateFriends.UseVisualStyleBackColor = true;
            this.relateFriends.Click += new System.EventHandler(this.relateFriends_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 352);
            this.Controls.Add(this.relateFriends);
            this.Controls.Add(this.neoConnect);
            this.Controls.Add(this.initPopulation);
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
        private System.Windows.Forms.Button initPopulation;
        private System.Windows.Forms.Button neoConnect;
        private System.Windows.Forms.Button relateFriends;

    }
}

