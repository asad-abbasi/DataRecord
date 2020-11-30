using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using MyProjects.Models;
using MyProjects.Views;
using System.Diagnostics;
using System.Linq;

namespace MyProjects.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Project> dataItemList = new ObservableCollection<Project>();
        Project currentItem;

        public MainPageViewModel()
        {
            AddNewDataItemCommand = new Command(/*asynv () await*/ AddNewDataItem /*() => !IsBussy*/);
            DeleteDataItemCommand = new Command<Project>(DeleteDataItem);

            AddNewDataItemToList();
        }

        public ObservableCollection<Project> DataItemList
        {
            set
            {
                dataItemList = value;
                OnPropertyChanged();
            }
            get { return dataItemList; }
        }
        public Project CurrentItem
        {
            set
            {
                currentItem = value;
                OnPropertyChanged();
            }
        }

        public void DeleteDataItemFromList(Project itemSelected)
        {
            dataItemList.Remove(itemSelected);
            OnPropertyChanged();
        }
        void AddNewDataItemToList()
        {
            Project dataItem1 = new Project();

            dataItem1.ID = "PR 01";
            dataItem1.Name = "Adding Machine";
            dataItem1.DateCreated = DateTime.Now.Date;
            dataItem1.DateModified = DateTime.Now.Date;
            dataItem1.dataItemDescList.Add(new ProjectListItem {Versions = "Ver 1.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 1.2.2", CreatorName = "CHaun" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 1.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 1.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 1.2.2", CreatorName = "Jhon" });
            dataItemList.Add(dataItem1);
//            Debug.WriteLine("IN Data View: " + dataItem1.dataItemDescList.ElementAt(0).Versions);

            Project dataItem2 = new Project();
            dataItem2.ID = "PR 06";
            dataItem2.Name = "Adding Machine";
            dataItem2.DateCreated = DateTime.Now.Date;
            dataItem2.DateModified = DateTime.Now.Date;
            dataItem2.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 6.2.2", CreatorName = "Jhon" });
            dataItem2.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 6.2.2", CreatorName = "CHaun" });
            dataItem2.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 6.2.2", CreatorName = "Jhon" });
            dataItem2.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 6.2.2", CreatorName = "Jhon" });
            dataItem2.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 6.2.2", CreatorName = "Jhon" });
            dataItemList.Add(dataItem2);
            Debug.WriteLine("IN Data View: " + dataItem2.dataItemDescList.ElementAt(0).Versions);

            Project dataItem6 = new Project();
            dataItem6.ID = "PR 02";
            dataItem6.Name = "Date Storage Machine";
            dataItem6.DateCreated = DateTime.Now.Date;
            dataItem6.DateModified = DateTime.Now.Date;
            dataItem6.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem6.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "CHaun" });
            dataItem6.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem6.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem6.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItemList.Add(dataItem6);

            Project dataItem3 = new Project();
            dataItem3.ID = "PR 03";
            dataItem3.Name = "Paitient Record Keeping";
            dataItem3.DateCreated = DateTime.Now.Date;
            dataItem3.DateModified = DateTime.Now.Date;
            dataItem3.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem3.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "CHaun" });
            dataItem3.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem3.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem3.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItemList.Add(dataItem3);

            Project dataItem4 = new Project();
            dataItem4.ID = "PR 04";
            dataItem4.Name = "Grossary Store Inventory Record Management Program";
            dataItem4.DateCreated = DateTime.Now.Date;
            dataItem4.DateModified = DateTime.Now.Date;
            dataItem4.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 4.2.2", CreatorName = "Jhon" });
            dataItem4.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 4.2.2", CreatorName = "CHaun" });
            dataItem4.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 4.2.2", CreatorName = "Jhon" });
            dataItem4.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 4.2.2", CreatorName = "Jhon" });
            dataItem4.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 4.2.2", CreatorName = "Jhon" });
            dataItemList.Add(dataItem4);

            Project dataItem5 = new Project();
            dataItem5.ID = "PR 05";
            dataItem5.Name = "Photo Editing software";
            dataItem5.DateCreated = DateTime.Now.Date;
            dataItem5.DateModified = DateTime.Now.Date;
            dataItem5.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 5.2.2", CreatorName = "Jhon" });
            dataItem5.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 5.2.2", CreatorName = "CHaun" });
            dataItem5.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 5.2.2", CreatorName = "Jhon" });
            dataItem5.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 5.2.2", CreatorName = "Jhon" });
            dataItem5.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 5.2.2", CreatorName = "Jhon" });
            dataItemList.Add(dataItem5);
            //            OnPropertyChanged();

        }
            
        void AddNewDataItem()
        {
            Debug.WriteLine("Action: New event");

        }
        void DeleteDataItem(Project dRItem)
        {
            dataItemList.Remove(dRItem);
        }

        public void SaveNewItemToList(Project newItem, int pageType, int updateItemIndex)
        {
            //if new item
            if (pageType == App.PAGE_TYPE_NEW)
            {
                dataItemList.Add(newItem);
                OnPropertyChanged();
            }
            else
            {
                dataItemList[updateItemIndex] = newItem;
                OnPropertyChanged();
            }
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
