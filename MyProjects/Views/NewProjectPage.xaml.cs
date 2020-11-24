using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyProjects.Models;
using MyProjects.Views;
using MyProjects.ViewModels;
using System.Diagnostics;

namespace MyProjects.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectPage : ContentPage
    {
        int PageType;
        public ProjectPage(Project selectedItem, int pageType)
        {
            InitializeComponent();

            BindingContext = new ProjectViewModel(selectedItem, pageType);//set listview sel item to null after use in main page
            //if sel not null set an update flag for main page to call on property change

            PageType = pageType;
        }

        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            // Get the MainPage that invoked this page. 
            NavigationPage navPage = (NavigationPage)Application.Current.MainPage; 
            IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack; 
            int lastIndex = navStack.Count - 1; 
            MainPage homePage = navStack[lastIndex] as MainPage;
            if (homePage == null) 
            {
                homePage = navStack[lastIndex - 1] as MainPage; 
            }
            // Transfer Information object to MainPage.
            ProjectViewModel newViewModel = ((ProjectViewModel)BindingContext);
            newViewModel.GetDataReady();

            Project newItem = newViewModel.NewItem;
            Debug.WriteLine("Action: " + newItem.ID);

            homePage.SaveNewItem(newItem, PageType);//some info to tell new or modified
            await Navigation.PopAsync();
        }
        async void OnCancleButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

/*        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitializeComponent();
        }
*/
    }
}