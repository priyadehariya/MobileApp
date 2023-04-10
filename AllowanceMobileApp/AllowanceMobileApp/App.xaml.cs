using AllowanceMobileApp.Model;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace AllowanceMobileApp
{
    public partial class App : Application
    {
        static DatabaseSQ database;

        // Create the database connection as a singleton.
        public static DatabaseSQ Database
        {
            get
            {
                if (database == null)
                {
                    string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DatabaseSQ.db3");
                    database = new DatabaseSQ(dbpath);
                }
                return database;
            }
        }

        public static NavigationPage AllowancePage { get; set; }

        public App()
        {
            InitializeComponent();
           
          

            MainPage = new MainPage();
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
