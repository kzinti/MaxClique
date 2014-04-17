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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.FacebookLogin = new System.Windows.Forms.Button();
            this.friendsListView = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.initPopulation = new System.Windows.Forms.Button();
            this.neoConnect = new System.Windows.Forms.Button();
            this.relateFriends = new System.Windows.Forms.Button();
            this.updateList = new System.Windows.Forms.Button();
            this.graphBuilding = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graphBuilding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // FacebookLogin
            // 
            this.FacebookLogin.Location = new System.Drawing.Point(3, 3);
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
            this.button2.Location = new System.Drawing.Point(84, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "Get Friend List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // initPopulation
            // 
            this.initPopulation.Location = new System.Drawing.Point(561, 15);
            this.initPopulation.Name = "initPopulation";
            this.initPopulation.Size = new System.Drawing.Size(75, 38);
            this.initPopulation.TabIndex = 4;
            this.initPopulation.Text = "Initialize Population";
            this.initPopulation.UseVisualStyleBackColor = true;
            this.initPopulation.Click += new System.EventHandler(this.initPopulation_Click);
            // 
            // neoConnect
            // 
            this.neoConnect.Location = new System.Drawing.Point(3, 47);
            this.neoConnect.Name = "neoConnect";
            this.neoConnect.Size = new System.Drawing.Size(75, 38);
            this.neoConnect.TabIndex = 5;
            this.neoConnect.Text = "Populate Local Graph";
            this.neoConnect.UseVisualStyleBackColor = true;
            this.neoConnect.Click += new System.EventHandler(this.neoConnect_Click);
            // 
            // relateFriends
            // 
            this.relateFriends.Location = new System.Drawing.Point(84, 47);
            this.relateFriends.Name = "relateFriends";
            this.relateFriends.Size = new System.Drawing.Size(75, 38);
            this.relateFriends.TabIndex = 6;
            this.relateFriends.Text = "Relate Friends";
            this.relateFriends.UseVisualStyleBackColor = true;
            this.relateFriends.Click += new System.EventHandler(this.relateFriends_Click);
            // 
            // updateList
            // 
            this.updateList.Location = new System.Drawing.Point(877, 302);
            this.updateList.Name = "updateList";
            this.updateList.Size = new System.Drawing.Size(75, 38);
            this.updateList.TabIndex = 7;
            this.updateList.Text = "Update List View";
            this.updateList.UseVisualStyleBackColor = true;
            this.updateList.Click += new System.EventHandler(this.updateList_Click);
            // 
            // graphBuilding
            // 
            this.graphBuilding.Controls.Add(this.FacebookLogin);
            this.graphBuilding.Controls.Add(this.neoConnect);
            this.graphBuilding.Controls.Add(this.relateFriends);
            this.graphBuilding.Controls.Add(this.button2);
            this.graphBuilding.Location = new System.Drawing.Point(793, 12);
            this.graphBuilding.Name = "graphBuilding";
            this.graphBuilding.Size = new System.Drawing.Size(162, 88);
            this.graphBuilding.TabIndex = 8;
            // 
            // chart1
            // 
            chartArea1.Name = "population";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(543, 327);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 352);
            this.Controls.Add(this.graphBuilding);
            this.Controls.Add(this.updateList);
            this.Controls.Add(this.initPopulation);
            this.Controls.Add(this.friendsListView);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.graphBuilding.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FacebookLogin;
        private System.Windows.Forms.ListView friendsListView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button initPopulation;
        private System.Windows.Forms.Button neoConnect;
        private System.Windows.Forms.Button relateFriends;
        private System.Windows.Forms.Button updateList;
        private System.Windows.Forms.Panel graphBuilding;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;

    }
}

