using ClientWindows.network;
using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ClientWindows.forms
{
    public partial class Start_Menu : MetroFramework.Forms.MetroForm
    {
        public Start_Menu()
        {
            InitializeComponent();
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            string username = this.Username_Box.Text;
            string userid = this.UserID_Box.Text;
            string ip = this.IP_Box.Text.Split(':')[0];
            try
            {
                int port = int.Parse(this.IP_Box.Text.Split(':')[1]);
                if (username != null && username.Length > 3 && userid != null && userid.Length > 5)
                {
                    if (ip != null && ip.Length > 6)
                    {
                        Hide();
                        Console.WriteLine($"{ip} {port} {username} {userid}");
                        Program.currentChatMenu.Show();
                        new Thread(() =>
                        {
                            Connection.CreateConnection(ip, port, username, userid);
                        })
                        {
                            Name = "Network"
                        }.Start();
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("format exception");
                return;
            }
        }
    }
}
