using Memo.Common;
using Memo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Memo
{
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            
            iconImage.Source = ImageSource.FromResource("Memo.Assets.Images.lock_open.png", typeof(LoginPage));
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmptyEmail = string.IsNullOrEmpty(userEmail.Text);
            bool isEmptyPass = string.IsNullOrEmpty(userPassword.Text);

            if (isEmptyEmail || isEmptyPass)
            {
                return;
            }

            var user = await App.AzureDb.GetUser(userEmail.Text, userPassword.Text);          
            
            if (user == null)
            {
                await DisplayAlert("Error", "Inavlid username or password", "Ok");
                return;
            }

            App.User = user;
            
            await Navigation.PushAsync(new HomePage());
        }

        private void OnRegister_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
