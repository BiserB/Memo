using Memo.Models;
using Memo.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Memo.ViewModels
{
    public class HomeVM
    {
        public HomeVM()
        {
            this.NavCommand = new NavigationCommand(this);
        }

        public NavigationCommand NavCommand { get; set; }

        public async void Navigate()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddNotePage() { });
        }
    }
}
