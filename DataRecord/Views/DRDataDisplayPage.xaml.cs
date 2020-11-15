﻿using System;
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

namespace DataRecord.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DRDataDisplayPage : ContentPage
    {
        public DRDataDisplayPage()
        {
            InitializeComponent();
            BindingContext = new DRDataDisplayViewModel();
        }


        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
//                Debug.WriteLine("Action: " + SelectedItem.ElementAt(0).Versions);
                await Navigation.PushAsync(new DRDetailPage((DRItem)e.SelectedItem));
            }
        }
   }
}