using ChatUIXForms.ViewModels;
using ClientMobile.network;
using EntryMsgMobile;
using Xamarin.Forms;

namespace ChatUIXForms.Views
{
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
            this.BindingContext = new ChatPageViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public void ScrollTap(object sender, System.EventArgs e)
        {
            lock (new object())
            {
                if (BindingContext != null)
                {
                    var vm = BindingContext as ChatPageViewModel;

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        while (vm.DelayedMessages.Count > 0)
                        {
                            vm.Messages.Insert(0, vm.DelayedMessages.Dequeue());
                        }
                        vm.ShowScrollTap = false;
                        vm.LastMessageVisible = true;
                        vm.PendingMessageCount = 0;
                        vm.ChatName = "Default";
                        ChatList?.ScrollToFirst();
                    });


                }

            }
        }
       
        public void OnListTapped(object sender, ItemTappedEventArgs e)
        {
            chatInput.UnFocusEntry();
        }

        private void Button_BackClicked(object sender, System.EventArgs e)
        {
            Connection.CloseChannel("User exit");
            Navigation.PushAsync(new AuthMenu());
        }
    }
}
