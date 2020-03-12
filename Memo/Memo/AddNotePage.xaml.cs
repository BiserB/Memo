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
    public partial class AddNotePage : ContentPage
    {
        public AddNotePage()
        {
            InitializeComponent();
        }
        
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            Note newNote = new Note()
            {
                Text = noteEntry.Text,
                CreatedOn = DateTime.UtcNow
            };

            noteEntry.Text = string.Empty;

            await App.Database.SaveNoteAsync(newNote);
            
            await Navigation.PushAsync(new HomePage());

            // -- when the page is child of tabbed page
            // var masterPage = this.Parent as TabbedPage;
            // masterPage.CurrentPage = masterPage.Children[0];
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {

        }
    }
}