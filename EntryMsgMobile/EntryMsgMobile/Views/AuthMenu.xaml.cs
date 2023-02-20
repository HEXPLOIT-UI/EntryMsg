using ChatUIXForms.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EntryMsgMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthMenu : ContentPage
    {
        public AuthMenu()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChatPage());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Link", "Open link", "Ok");
        }
    }
}