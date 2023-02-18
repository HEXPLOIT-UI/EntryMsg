using System.Drawing;
using System;

namespace ClientWindows.forms
{
    partial class Start_Menu
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
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.Username_Box = new MetroFramework.Controls.MetroTextBox();
            this.UserID_Box = new MetroFramework.Controls.MetroTextBox();
            this.IP_Box = new MetroFramework.Controls.MetroTextBox();
            this.Username = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(296, 334);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(186, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.White;
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "Connect";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // Username_Box
            // 
            this.Username_Box.Location = new System.Drawing.Point(268, 166);
            this.Username_Box.Name = "Username_Box";
            this.Username_Box.Size = new System.Drawing.Size(241, 23);
            this.Username_Box.Style = MetroFramework.MetroColorStyle.White;
            this.Username_Box.TabIndex = 1;
            this.Username_Box.Text = "User";
            this.Username_Box.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // UserID_Box
            // 
            this.UserID_Box.Location = new System.Drawing.Point(268, 214);
            this.UserID_Box.Name = "UserID_Box";
            this.UserID_Box.Size = new System.Drawing.Size(241, 23);
            this.UserID_Box.Style = MetroFramework.MetroColorStyle.White;
            this.UserID_Box.TabIndex = 1;
            this.UserID_Box.Text = "User_0";
            this.UserID_Box.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // IP_Box
            // 
            this.IP_Box.Location = new System.Drawing.Point(268, 267);
            this.IP_Box.Name = "IP_Box";
            this.IP_Box.Size = new System.Drawing.Size(241, 23);
            this.IP_Box.Style = MetroFramework.MetroColorStyle.White;
            this.IP_Box.TabIndex = 1;
            this.IP_Box.Text = "127.0.0.1:29070";
            this.IP_Box.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Location = new System.Drawing.Point(358, 144);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(68, 19);
            this.Username.TabIndex = 2;
            this.Username.Text = "Username";
            this.Username.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(368, 192);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(47, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "UserID";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(368, 245);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(48, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.White;
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "IP:Port";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Start_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.IP_Box);
            this.Controls.Add(this.UserID_Box);
            this.Controls.Add(this.Username_Box);
            this.Controls.Add(this.metroButton1);
            this.Name = "Start_Menu";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "EntryMesseger Login";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTextBox Username_Box;
        private MetroFramework.Controls.MetroTextBox UserID_Box;
        private MetroFramework.Controls.MetroTextBox IP_Box;
        private MetroFramework.Controls.MetroLabel Username;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}