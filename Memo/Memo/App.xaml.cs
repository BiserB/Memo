using Memo.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.WindowsAzure.MobileServices;
using Memo.Common;

namespace Memo
{
    public partial class App : Application
    {
        private static MemoDb database;
        private static MobileServiceClient mobileService;

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

        public static MobileServiceClient MobileService
        {
            get
            {
                if (mobileService == null)
                {
                    mobileService = new MobileServiceClient(AppConst.AzureWebApp);
                }
                return mobileService;
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
