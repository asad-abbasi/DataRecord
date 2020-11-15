using MyProjects.Models;
using MyProjects.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyProjects
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
//        CurrentInfo = new DRItem();

        //            MainPage = new DRDataDisplayPage();
        MainPage = new NavigationPage(new MainPage());
            //            MainPage = new DRDetailPage();
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
