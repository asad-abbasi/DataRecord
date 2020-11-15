using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DataRecord.ViewModels;
using System.Diagnostics;
using DataRecord.Models;
using System.Collections.ObjectModel;
using DataRecord.Views;

namespace DataRecord.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }


        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
//                Debug.WriteLine("Action: " + SelectedItem.ElementAt(0).Versions);
                await Navigation.PushAsync(new ProjectPage((Project)e.SelectedItem));
            }
        }
   }
}