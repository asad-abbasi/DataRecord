using MyProjects.Models;
using MyProjects.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProjects
{
    public partial class App : Application
    {
        public static int PAGE_TYPE_NEW = 1;
        public static int PAGE_TYPE_UPDATE = 0;
        public static long NEXT_INDEX = 0;
        public App()
        {
            InitializeComponent();
//        CurrentInfo = new DRItem();

            MainPage = new NavigationPage(new MainPage());
        }

        public Project CurrentInfo { private set; get; }

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
