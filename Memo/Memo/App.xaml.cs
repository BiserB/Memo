using Memo.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Memo
{
    public partial class App : Application
    {
        private static MemoDb database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        public static MemoDb Database
        {
            get
            {
                if (database == null)
                {
                    database = new MemoDb(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Memo.sqlite"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
