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

        Project copySelItem;// = new Project();
        int SelItemIndex;
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                //               Debug.WriteLine("Action: " + SelectedItem.ElementAt(0).Versions);
               Debug.WriteLine("Action: " + (((Project)(e.SelectedItem)).dataItemDescList[0]).Versions);

//                copySelItem = ((Project)e.SelectedItem).ShallowCopy();
                listView.SelectedItem = null;

                //get index of sel item from viewmodel
                MainPageViewModel mainViewModel = ((MainPageViewModel)BindingContext);
                //pass this index to new SaveNewItem method to overwrite the updated selected item
                SelItemIndex = mainViewModel.DataItemList.IndexOf((Project)e.SelectedItem);

//                await Navigation.PushAsync(new ProjectPage(copySelItem, App.PAGE_TYPE_UPDATE)); //update/display page
                await Navigation.PushAsync(new ProjectPage((Project)e.SelectedItem, App.PAGE_TYPE_UPDATE)); //update/display page
            }
        }

        async void OnNewButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProjectPage(null, App.PAGE_TYPE_NEW));    //new page

        }

        public void SaveNewItem(Project newItem, int pageType)//not  dn
        {

            ((MainPageViewModel)BindingContext).SaveNewItemToList(newItem, pageType);
        }
    }
}