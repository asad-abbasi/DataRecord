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
        public ObservableCollection<Project> itemsList;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        Project copySelItem;
        int SelItemIndex=-1;
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                copySelItem = ((Project)e.SelectedItem).DeepCopy();
                listView.SelectedItem = null;

                //get index of sel item from viewmodel
                MainPageViewModel mainViewModel = ((MainPageViewModel)BindingContext);
                //pass this index to new SaveNewItem method to overwrite the updated selected item
                SelItemIndex = mainViewModel.DataItemList.IndexOf((Project)e.SelectedItem);
//                SelItemIndex = Project.DataItemList.IndexOf((Project)e.SelectedItem);

                await Navigation.PushAsync(new ProjectPage(copySelItem, App.PAGE_TYPE_UPDATE)); //update/display page
            }
        }

        async void OnNewButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProjectPage(null, App.PAGE_TYPE_NEW));    //new page

        }

        public void SaveNewItem(Project newItem, int pageType)
        {

            ((MainPageViewModel)BindingContext).SaveNewItemToList(newItem, pageType, SelItemIndex);
        }


 /*       protected override async void OnAppearing()
        {
            base.OnAppearing();
            itemsList = new ObservableCollection<Project>(await ((MainPageViewModel)BindingContext).Database.GetItemsAsync());
            Debug.WriteLine("Action: " + (this.itemsList[0]).Name);

 //           listView.ItemsSource = await ((MainPageViewModel)BindingContext).Database.GetItemsAsync();
            listView.ItemsSource = itemsList;
        }
*/    }


}