using DataRecord.Models;
using DataRecord.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataRecord
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
//        CurrentInfo = new DRItem();

        //            MainPage = new DRDataDisplayPage();
        MainPage = new NavigationPage(new DRDataDisplayPage());
            //            MainPage = new DRDetailPage();
        }

        public DRItem CurrentInfo { private set; get; }

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
