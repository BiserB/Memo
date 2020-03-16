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
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        async void OnAddNoteClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNotePage() { BindingContext = new Note() });
        }

    }
}