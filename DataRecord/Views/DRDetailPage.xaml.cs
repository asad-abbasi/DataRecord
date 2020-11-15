using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DataRecord.ViewModels;
using DataRecord.Models;
using DataRecord.Views;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace DataRecord.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class DRDetailPage : ContentPage
    {
        public ObservableCollection<DRItemDescription> CurrentItemDescList = new ObservableCollection<DRItemDescription>();

        public DRDetailPage()
        {
            InitializeComponent();
//            BindingContext = new DRDetailViewModel(CurrentItemDescList);
            //BindingContext = new DRDetailViewModel();

            //Debug.WriteLine("Action: " + selectedItem.ElementAt(0).Versions);
        }
        public DRDetailPage(DRItem selectedItem)
        {
            InitializeComponent();
//            CurrentItemDescList = selectedItem;
//            BindingContext = new DRDetailViewModel(CurrentItemDescList);
            BindingContext = new DRDetailViewModel(selectedItem);



            ///////////////////////////////////////////////////////////////////////////////////
            //                        BindingContext = new DRDetailViewModel();

            //            Debug.WriteLine("Action: " + selectedItem.ElementAt(0).Versions);
            //            listView.ItemsSource = CurrentItemDescList
            //                           .ToList();
            //            BindingContext = selectedItem;  should be the object received
        }
    }
}