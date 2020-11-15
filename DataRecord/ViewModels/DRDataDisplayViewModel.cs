using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using DataRecord.Models;
using DataRecord.Views;
using System.Diagnostics;
using System.Linq;

namespace DataRecord.ViewModels
{
    class DRDataDisplayViewModel : INotifyPropertyChanged
    {
        ObservableCollection<DRItem> dataItemList = new ObservableCollection<DRItem>();
        DRItem currentItem;

        public DRDataDisplayViewModel()
        {
            AddNewDataItemCommand = new Command(/*asynv () await*/ AddNewDataItem /*() => !IsBussy*/);
            DeleteDataItemCommand = new Command(DeleteDataItem);

            AddNewDataItemToList();
        }

        public ObservableCollection<DRItem> DataItemList
        {
            set
            {
                dataItemList = value;
                OnPropertyChanged();
            }
            get { return dataItemList; }
        }
        public DRItem CurrentItem
        {
            set
            {
                currentItem = value;
                OnPropertyChanged();
            }
        }

        public void DeleteDataItemFromList(DRItem itemSelected)
        {
            dataItemList.Remove(itemSelected);
            OnPropertyChanged();
        }
        void AddNewDataItemToList()
        {
            DRItem dataItem1 = new DRItem();

            dataItem1.ID = "PR 01";
            dataItem1.Name = "Adding Machine";
            dataItem1.DateCreated = DateTime.Now;
            dataItem1.DateModified = DateTime.Now;
            dataItem1.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 1.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 1.2.2", CreatorName = "CHaun" });
            dataItem1.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 1.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 1.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 1.2.2", CreatorName = "Jhon" });
            dataItemList.Add(dataItem1);
//            Debug.WriteLine("IN Data View: " + dataItem1.dataItemDescList.ElementAt(0).Versions);

            DRItem dataItem2 = new DRItem();
            dataItem2.ID = "PR 06";
            dataItem2.Name = "Adding Machine";
            dataItem2.DateCreated = DateTime.Now;
            dataItem2.DateModified = DateTime.Now;
            dataItem2.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 6.2.2", CreatorName = "Jhon" });
            dataItem2.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 6.2.2", CreatorName = "CHaun" });
            dataItem2.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 6.2.2", CreatorName = "Jhon" });
            dataItem2.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 6.2.2", CreatorName = "Jhon" });
            dataItem2.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 6.2.2", CreatorName = "Jhon" });
            dataItemList.Add(dataItem2);
            Debug.WriteLine("IN Data View: " + dataItem2.dataItemDescList.ElementAt(0).Versions);

            DRItem dataItem6 = new DRItem();
            dataItem6.ID = "PR 02";
            dataItem6.Name = "Date Storage Machine";
            dataItem6.DateCreated = DateTime.Now;
            dataItem6.DateModified = DateTime.Now;
            dataItem6.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem6.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 3.2.2", CreatorName = "CHaun" });
            dataItem6.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem6.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem6.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItemList.Add(dataItem6);

            DRItem dataItem3 = new DRItem();
            dataItem3.ID = "PR 03";
            dataItem3.Name = "Paitient Record Keeping";
            dataItem3.DateCreated = DateTime.Now;
            dataItem3.DateModified = DateTime.Now;
            dataItem3.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem3.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 3.2.2", CreatorName = "CHaun" });
            dataItem3.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem3.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem3.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItemList.Add(dataItem3);

            DRItem dataItem4 = new DRItem();
            dataItem4.ID = "PR 04";
            dataItem4.Name = "Grossary Store Inventory Record Management Program";
            dataItem4.DateCreated = DateTime.Now;
            dataItem4.DateModified = DateTime.Now;
            dataItem4.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 4.2.2", CreatorName = "Jhon" });
            dataItem4.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 4.2.2", CreatorName = "CHaun" });
            dataItem4.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 4.2.2", CreatorName = "Jhon" });
            dataItem4.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 4.2.2", CreatorName = "Jhon" });
            dataItem4.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 4.2.2", CreatorName = "Jhon" });
            dataItemList.Add(dataItem4);

            DRItem dataItem5 = new DRItem();
            dataItem5.ID = "PR 05";
            dataItem5.Name = "Photo Editing software";
            dataItem5.DateCreated = DateTime.Now;
            dataItem5.DateModified = DateTime.Now;
            dataItem5.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 5.2.2", CreatorName = "Jhon" });
            dataItem5.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 5.2.2", CreatorName = "CHaun" });
            dataItem5.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 5.2.2", CreatorName = "Jhon" });
            dataItem5.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 5.2.2", CreatorName = "Jhon" });
            dataItem5.dataItemDescList.Add(new DRItemDescription { Versions = "Ver 5.2.2", CreatorName = "Jhon" });
            dataItemList.Add(dataItem5);
            //            OnPropertyChanged();

        }

        void AddNewDataItem()
        {
            Debug.WriteLine("Action: New event");

        }
        void DeleteDataItem()
        {
            dataItemList.Remove(currentItem);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = "")//automaticlly call OnPropertyChanged with the name of the property that is called in
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Command AddNewDataItemCommand { private set; get; }
        public Command DeleteDataItemCommand { private set; get; } 
     }
}
