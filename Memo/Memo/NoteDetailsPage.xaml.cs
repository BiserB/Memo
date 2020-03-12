using Memo.Common;
using Memo.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Memo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteDetailsPage : ContentPage
    {
        private readonly Note selectedNote;

        public NoteDetailsPage(Note selectedNote)
        {
            InitializeComponent();
            this.selectedNote = selectedNote;

            noteContentEntry.Text = selectedNote.Text;
            createdOn.Text = $"Created on: {selectedNote.CreatedOn.ToLocalTime().ToString(AppConst.NoteDateFormat)}";

            if (selectedNote.UpdatedOn != null)
            {
                updatedOn.Text = $"Last change on: {selectedNote.UpdatedOn?.ToLocalTime().ToString(AppConst.NoteDateFormat)}";
            }
        }

        private async void update_Clicked(object sender, System.EventArgs e)
        {
            this.selectedNote.Text = noteContentEntry.Text;
            this.selectedNote.UpdatedOn = DateTime.UtcNow;

            await App.Database.SaveNoteAsync(this.selectedNote);

            await Navigation.PushAsync(new HomePage());
        }

        private async void delete_Clicked(object sender, System.EventArgs e)
        {
            await App.Database.DeleteNoteAsync(this.selectedNote);

            await Navigation.PushAsync(new HomePage());
        }
    }
}