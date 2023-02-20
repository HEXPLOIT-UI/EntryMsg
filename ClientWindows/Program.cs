using ClientWindows.forms;
using DotNetty.Common.Utilities;
using MetroFramework.Controls;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ClientWindows
{
    internal static class Program
    {

        public static Start_Menu mainForm;
        public static Chat_Menu currentChatMenu;

        [STAThread]
        static void Main()
        {
            AllocConsole();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new Start_Menu();
            currentChatMenu = new Chat_Menu();
            Application.Run(mainForm);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public static void AddUser(string userID, string username)
        {
            var item = new ListViewItem(userID);
            item.ImageKey = userID;
            item.Text = username;
            item.BackColor = Color.FromArgb(17, 17, 17, 1);
            item.ForeColor = Color.White;
            currentChatMenu.UserList.Items.Add(item);
        }

        public static void RemoveUser(string userID)
        {
            currentChatMenu.UserList.Items.RemoveByKey(userID);
        }

        public static void AddMessage(string message, string username)
        {
            currentChatMenu.ChatMessages.Items.Add(username + ":  " + message);
        }

        public static void AddServerMessage(string message)
        {
            currentChatMenu.ChatMessages.Items.Add("                      " + message);
        }
    }
}
