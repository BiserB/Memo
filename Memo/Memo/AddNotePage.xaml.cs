using Memo.Models;
using Memo.Services;
using Plugin.Geolocator;
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

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var service = new VenueService();

            var locator = CrossGeolocator.Current;

            var position = await locator.GetPositionAsync();

            var venues = await service.GetVenuesAsync(position.Latitude, position.Longitude);

            venueList.ItemsSource = venues;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {

            Note newNote = new Note()
            {
                Text = noteEntry.Text,
                CreatedOn = DateTime.UtcNow,
                UserId = App.User.Id
            };

            var selectedVenue = (Venue)venueList.SelectedItem;

            if (selectedVenue != null)
            {
                newNote.VenueName = selectedVenue.Name;
                newNote.Lat = selectedVenue.Location.Lat;
                newNote.Lng = selectedVenue.Location.Lng;
            }

            noteEntry.Text = string.Empty;

            App.AzureDb.SaveNoteAsync(newNote);

            //await App.Database.SaveNoteAsync(newNote); // save to SQLite DB

            await DisplayAlert("Success", "Inserted", "Ok");

            await Navigation.PushAsync(new HomePage());
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}