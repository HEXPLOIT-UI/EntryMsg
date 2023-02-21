using ChatUIXForms.Views;
using ClientMobile.network;
using System;
using System.Diagnostics;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EntryMsgMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthMenu : ContentPage
    {
        public static ChatPage chatPage { get; set; }
        public AuthMenu()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string ip = this.txtIpPort.Text.Split(':')[0];
                int port = int.Parse(this.txtIpPort.Text.Split(':')[1]);
                if (txtUsername.Text != null && txtUsername.Text.Length > 3 && txtUserid.Text != null && txtUserid.Text.Length > 5)
                {
                    App.User = txtUsername.Text;
                    App.UserID = txtUserid.Text;
                    if (ip != null && ip.Length > 6)
                    {
                        App.ipAddress = txtIpPort.Text;
                        chatPage = new ChatPage();
                        Navigation.PushAsync(chatPage);
                        new Thread(() =>
                        {
                            Connection.CreateConnection(ip, port, txtUsername.Text, txtUserid.Text);
                        })
                        {
                            Name = "Network"
                        }.Start();
                    }
                }
            } 
            catch (NullReferenceException)
            {
                Debug.WriteLine("Enter the data");
            }
            catch (FormatException)
            {
                Console.WriteLine("format exception");
                return;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Link", "Open link", "Ok");
        }
    }
}