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
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // notes.ItemsSource = await App.Database.GetNotesAsync(); // read from SQLite Database

            notes.ItemsSource = await App.MobileService.GetTable<Note>()
                                         .Where(n => n.UserId == App.User.Id)
                                         .ToListAsync();
        }

        private void OnNotesItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedNote = (Note)notes.SelectedItem;

            Navigation.PushAsync(new NoteDetailsPage(selectedNote));
        }
    }
}