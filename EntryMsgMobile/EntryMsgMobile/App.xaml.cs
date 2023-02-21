using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EntryMsgMobile
{
    public partial class App : Application
    {
        public static string User = "";
        public static string UserID = "";
        public static string ipAddress = "";

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new AuthMenu());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
