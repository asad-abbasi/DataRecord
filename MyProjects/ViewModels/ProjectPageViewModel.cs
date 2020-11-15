using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using MyProjects.Models;
using MyProjects.Views;
using Xamarin.Forms;

namespace MyProjects.ViewModels
{
    class ProjectPageViewModel : INotifyPropertyChanged
    {
//        DRItem currentItem;
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")//automaticlly call OnPropertyChanged with the name of the property that is called in
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ObservableCollection<ProjectListItem> descList;// = new ObservableCollection<DRItemDescription>();
//        public DRDetailViewModel(ObservableCollection<DRItemDescription> DataItemDescList)
        public ProjectPageViewModel(Project selectedItem)
        {
            DeleteDataItemDescCommand = new Command(/*asynv () await*/ DeleteDataItemDesc /*() => !IsBussy*/);
            descList = selectedItem.dataItemDescList;
            OnPropertyChanged();
            //            AddNewDataItemDescToList();
            //            currentItem = selectedItem;
        }
        public ProjectPageViewModel()
        {
        }

        public Command DeleteDataItemDescCommand { private set; get; }

        public ObservableCollection<ProjectListItem> DescList
        {
/*            set
            {
                descList = value;
                OnPropertyChanged();
            }*/
            get { return descList; }
        }

        void DeleteDataItemDesc()
        {
  //          Debug.WriteLine("Action: " + dataItemDescList[0].ID);

        }
    }
}
