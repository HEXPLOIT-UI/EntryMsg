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
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.UserList = new System.Windows.Forms.ListView();
            this.ChatName = new MetroFramework.Controls.MetroLabel();
            this.ChatMessages = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
            this.metroButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
            this.UserList.AllowColumnReorder = true;
            this.UserList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.UserList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.UserList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserList.GridLines = true;
            this.UserList.HideSelection = false;
            this.UserList.Location = new System.Drawing.Point(773, 55);
            this.UserList.Margin = new System.Windows.Forms.Padding(2);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(121, 335);
            this.UserList.TabIndex = 0;
            this.UserList.UseCompatibleStateImageBehavior = false;
            this.UserList.View = System.Windows.Forms.View.List;
            // 
            // ChatName
            // 
            this.ChatName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ChatName.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.ChatName.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.ChatName.Location = new System.Drawing.Point(245, 17);
            this.ChatName.Name = "ChatName";
            this.ChatName.Size = new System.Drawing.Size(486, 35);
            this.ChatName.Style = MetroFramework.MetroColorStyle.White;
            this.ChatName.TabIndex = 3;
            this.ChatName.Text = "Chat {name}";
            this.ChatName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ChatName.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ChatName.UseStyleColors = true;
            // 
            // ChatMessages
            // 
            this.ChatMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ChatMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ChatMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChatMessages.ForeColor = System.Drawing.Color.White;
            this.ChatMessages.FormattingEnabled = true;
            this.ChatMessages.HorizontalScrollbar = true;
            this.ChatMessages.Location = new System.Drawing.Point(23, 53);
            this.ChatMessages.Name = "ChatMessages";
            this.ChatMessages.Size = new System.Drawing.Size(708, 392);
            this.ChatMessages.TabIndex = 4;
            // 
            // Chat_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 519);
            this.Controls.Add(this.ChatMessages);
            this.Controls.Add(this.ChatName);
            this.Controls.Add(this.UserList);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroTextBox1);
            this.Name = "Chat_Menu";
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);

        }
        void form_Closing(object sender, CancelEventArgs e)
        {
            Program.mainForm.Show();
        }
        #endregion
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroButton metroButton1;
        public System.Windows.Forms.ListView UserList;
        public MetroFramework.Controls.MetroLabel ChatName;
        public System.Windows.Forms.ListBox ChatMessages;
    }
}