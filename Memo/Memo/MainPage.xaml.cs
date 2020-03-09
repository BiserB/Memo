using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Memo
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

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
