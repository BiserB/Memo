using Memo.Common;
using Memo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Memo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            if (!RegexUtilities.IsValidEmail(userEmail.Text))
            {
                await DisplayAlert("Error", "Invalid Email", "Ok");
                return;
            }

            if (password.Text != confirmPassword.Text)
            {
                await DisplayAlert("Error", "Passwords doesn't match", "Ok");
                return;
            }

            User user = new User()
            {
                Email = userEmail.Text,
                Password = CryptoService.HashPassword(password.Text)
            };

            var userTable = App.MobileService.GetTable<User>();

            await userTable.InsertAsync(user);

            await DisplayAlert("Success", "Inserted", "Ok");
        }
    }
}