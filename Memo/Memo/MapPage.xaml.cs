using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using Memo.Models;

namespace Memo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            double zoomLevel = e.NewValue;
            double latlongDegrees = 360 / (Math.Pow(2, zoomLevel));
            if (appMap.VisibleRegion != null)
            {
                appMap.MoveToRegion(new MapSpan(appMap.VisibleRegion.Center, latlongDegrees, latlongDegrees));
            }
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            switch (button.Text)
            {
                case "Street":
                    appMap.MapType = MapType.Street;
                    break;
                case "Satellite":
                    appMap.MapType = MapType.Satellite;
                    break;
                case "Hybrid":
                    appMap.MapType = MapType.Hybrid;
                    break;
            }
        }

        void OnMyPositionClicked(object sender, EventArgs e)
        {
            appMap.IsShowingUser = true;

            this.StartPositioning();            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            //if (appMap.IsShowingUser)
            //{
            //    this.StartPositioning();
            //}

            this.StartPositioning();

            //var notes = await App.Database.GetNotesAsync();

            var notes = await App.AzureDb.GetNotesAsync();

            foreach (var note in notes)
            {
                if (!note.Lat.HasValue || !note.Lng.HasValue)
                {
                    continue;
                }

                var position = new Xamarin.Forms.Maps.Position((double)note.Lat, (double)note.Lng);

                var pin = new Xamarin.Forms.Maps.Pin()
                {
                    Type = PinType.SavedPin,
                    Position = position,
                    Label = note.Text,
                };

                appMap.Pins.Add(pin);
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }

        private void StartPositioning()
        {
            CrossGeolocator.Current.PositionChanged += Locator_PositionChanged;

            this.GetLocation();
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            this.MoveMap(e.Position);
        }

        private async void GetLocation()
        {
            var locator = CrossGeolocator.Current;

            var position = await locator.GetPositionAsync();

            this.MoveMap(position);
        }

        private void MoveMap(Plugin.Geolocator.Abstractions.Position position)
        {
            var positionOnMap = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);

            var span = new Xamarin.Forms.Maps.MapSpan(positionOnMap, 0.5, 0.5);

            appMap.MoveToRegion(span);
        }
    }
}