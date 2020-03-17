using Memo.Models;
using Memo.ViewModels;
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
    public partial class HomePage : TabbedPage
    {
        HomeVM viewModel;

        public HomePage()
        {
            InitializeComponent();

            this.viewModel = new HomeVM();

            this.BindingContext = this.viewModel;
        }
    }
}