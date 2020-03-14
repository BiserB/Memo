using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

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
        }
    }
}