using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HealthAssistant.Models;
using System.Collections.ObjectModel;

namespace HealthAssistant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            User user = new User(Entry_Email.Text, Entry_Password.Text, Entry_DOB.Text, Int32.Parse(Entry_Weight.Text), Int32.Parse(Entry_Height.Text));            

            if (user.IsRegisterLegit())
            {
                DisplayAlert("Registering Succesful", "Well done", "OK");
                // Application.Current.MainPage = new NavigationPage(new LoginPage());
                
                this.Navigation.PopAsync();
            }
            else
                DisplayAlert("", "Please fill in all the fields!", "OK");
        }
    }
}