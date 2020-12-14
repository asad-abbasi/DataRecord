using MyProjects.Models;
using MyProjects.Views;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProjects
{
    public partial class App : Application
    {
        public static int PAGE_TYPE_NEW = 1;
        public static int PAGE_TYPE_UPDATE = 0;
        public static long NEXT_INDEX = 0;
        static ProjectDatabase database;

    public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
        public static ProjectDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ProjectDatabase();
                }
                return database;
            }

        }

/*        protected void GetDatabase()
        {

            database = new ProjectDatabase();
            DataItemList = new ObservableCollection<Project>();
            Project.DataItemList = new ObservableCollection<Project>(database.GetItems());
        }
*/
        protected override void OnStart()
        {
//            GetDatabase();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
