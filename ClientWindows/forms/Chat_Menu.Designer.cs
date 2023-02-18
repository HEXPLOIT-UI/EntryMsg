using System.ComponentModel;
using System;
using ClientWindows.network;

namespace ClientWindows.forms
{
    partial class Chat_Menu
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.UserList = new MetroFramework.Controls.MetroPanel();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.metroPanel1.CustomBackground = true;
            this.metroPanel1.HorizontalScrollbar = true;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = true;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 55);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(708, 382);
            this.metroPanel1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            this.metroTextBox1.Location = new System.Drawing.Point(23, 463);
            this.metroTextBox1.MaxLength = 1024;
            this.metroTextBox1.Multiline = true;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PromptText = "Write a message";
            this.metroTextBox1.Size = new System.Drawing.Size(598, 23);
            this.metroTextBox1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroTextBox1.TabIndex = 1;
            this.metroTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox1.UseStyleColors = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(638, 463);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(93, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "Send";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // UserList
            // 
            this.UserList.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.UserList.HorizontalScrollbar = true;
            this.UserList.HorizontalScrollbarBarColor = true;
            this.UserList.HorizontalScrollbarHighlightOnWheel = true;
            this.UserList.HorizontalScrollbarSize = 10;
            this.UserList.Location = new System.Drawing.Point(762, 55);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(119, 302);
            this.UserList.Style = MetroFramework.MetroColorStyle.Lime;
            this.UserList.TabIndex = 3;
            this.UserList.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.UserList.VerticalScrollbarBarColor = true;
            this.UserList.VerticalScrollbarHighlightOnWheel = false;
            this.UserList.VerticalScrollbarSize = 10;
            // 
            // Chat_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 519);
            this.Controls.Add(this.UserList);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.metroPanel1);
            this.Name = "Chat_Menu";
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "Chat {name}";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += form_Closing;
            this.ResumeLayout(false);

        }
        void form_Closing(object sender, CancelEventArgs e)
        {
            Program.mainForm.Show();
        }
        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroButton metroButton1;
        public MetroFramework.Controls.MetroPanel UserList;
    }
}