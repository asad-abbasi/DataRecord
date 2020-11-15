using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProjects.ViewModels;
using System.Diagnostics;
using MyProjects.Models;
using System.Collections.ObjectModel;
using MyProjects.Views;

namespace MyProjects.Views
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