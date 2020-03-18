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
            
            iconImage.Source = ImageSource.FromResource("Memo.Assets.Images.login_logo.png", typeof(LoginPage));
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmptyEmail = string.IsNullOrEmpty(UserEmail.Text);
            bool isEmptyPass = string.IsNullOrEmpty(UserPassword.Text);

            if (isEmptyEmail || isEmptyPass)
            {

            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}
