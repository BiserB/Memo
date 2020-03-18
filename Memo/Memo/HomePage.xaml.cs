using Memo.Models;
using Memo.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace Memo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        HomeVM viewModel;

        public HomePage()
        {
            InitializeComponent();

            On<Android>().Element.UnselectedTabColor = Xamarin.Forms.Color.LightGray;
            On<Android>().Element.SelectedTabColor = Xamarin.Forms.Color.White;

            this.viewModel = new HomeVM();

            this.BindingContext = this.viewModel;
        }
    }
}