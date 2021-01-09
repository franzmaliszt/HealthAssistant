using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using HealthAssistant.Models;
using System.Collections.ObjectModel;

namespace HealthAssistant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public User User;
        public LoginPage()
        {
            InitializeComponent();
            User = new User();
            this.BindingContext = User;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {            
            User user = new User(Entry_Email.Text, Entry_Password.Text);
            
            if (user.IsLoginLegit())
            {
                DisplayAlert("Login", "Welcome!", "OK");
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                DisplayAlert("Login", "E-mail or password doesn't match", "OK");
            }
        }

        private async void SignUp_Tapped (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void Facebook_Tapped(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync("http://facebook.com", BrowserLaunchMode.SystemPreferred);
                // Assuming Facebook Login is implemented
                Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}