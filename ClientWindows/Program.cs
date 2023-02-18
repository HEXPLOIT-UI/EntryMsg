using ClientWindows.forms;
using MetroFramework.Controls;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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
    }
}
