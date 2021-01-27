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
        bool userChioce;
        public ProjectPage(Project selectedItem, int pageType)
        {
            InitializeComponent();

            BindingContext = new ProjectViewModel(selectedItem, pageType);//set listview sel item to null after use in main page
            //if sel not null set an update flag for main page to call on property change

            PageType = pageType;

            if (EnableBackButtonOverride)
            {
                this.CustomBackButtonAction = async () =>
                {
                    var result = await this.DisplayAlert(null,
                        "Hey wait now! are you sure " +
                        "you want to go back?",
                        "Yes go back", "Nope");

                    if (result)
                    {
                        await Navigation.PopAsync(true);
                    }
                };

            }
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            OnSave();
        }
        async void OnCancleButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        protected new bool OnBackButtonPressed()
        {
            ProjectViewModel pViewModel = ((ProjectViewModel)BindingContext);
            if (!pViewModel.change)
            {
                return base.OnBackButtonPressed();
            }
            else
            {
                DisplayAlertDialog();
                if (userChioce)
                    return base.OnBackButtonPressed();
                else
                    OnSave();
                    return true;
            }
//            return true; 
        }

        async void DisplayAlertDialog()
        {
            userChioce = await DisplayAlert("Warning", "Changes will be discarded, do you want to continue ?", "Yes", "No");
            Debug.WriteLine("Answer: " + userChioce);
        }

        async void OnSave()
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
            //            Debug.WriteLine("Action: " + newItem.Id);
            //enable insert button
            newViewModel.insertDesc = true;
            //if user has left description fields empty remove the last item from the list
            if (newItem.dataItemDescList.Count > 0)
                if ((newItem.dataItemDescList[newItem.dataItemDescList.Count - 1]).Versions.Equals(" ") ||
                    (newItem.dataItemDescList[newItem.dataItemDescList.Count - 1]).CreatorName.Equals(" "))
                    newItem.dataItemDescList.Remove(newItem.dataItemDescList[newItem.dataItemDescList.Count - 1]);
            homePage.SaveNewItem(newItem, PageType);//some info to tell new or modified
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Gets or Sets the Back button click overriden custom action
        /// </summary>
        public Action CustomBackButtonAction { get; set; }

        public static readonly BindableProperty EnableBackButtonOverrideProperty =
               BindableProperty.Create(
               nameof(EnableBackButtonOverride),
               typeof(bool),
               typeof(ProjectPage),
               true);

        /// <summary>
        /// Gets or Sets Custom Back button overriding state
        /// </summary>
        public bool EnableBackButtonOverride
        {
            get
            {
                return (bool)GetValue(EnableBackButtonOverrideProperty);
            }
            set
            {
//                SetValue(EnableBackButtonOverrideProperty, value);
                SetValue(EnableBackButtonOverrideProperty, true);
            }
        }
    }
}