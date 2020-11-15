using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using DataRecord.Models;
using DataRecord.Views;
using Xamarin.Forms;

namespace DataRecord.ViewModels
{
    class DRDetailViewModel : INotifyPropertyChanged
    {
//        DRItem currentItem;
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")//automaticlly call OnPropertyChanged with the name of the property that is called in
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ObservableCollection<DRItemDescription> descList;// = new ObservableCollection<DRItemDescription>();
//        public DRDetailViewModel(ObservableCollection<DRItemDescription> DataItemDescList)
        public DRDetailViewModel(DRItem selectedItem)
        {
            DeleteDataItemDescCommand = new Command(/*asynv () await*/ DeleteDataItemDesc /*() => !IsBussy*/);
            descList = selectedItem.dataItemDescList;
            OnPropertyChanged();
            //            AddNewDataItemDescToList();
            //            currentItem = selectedItem;
        }
        public DRDetailViewModel()
        {
        }

        public Command DeleteDataItemDescCommand { private set; get; }

        public ObservableCollection<DRItemDescription> DescList
        {
/*            set
            {
                DescList = value;
                OnPropertyChanged();
            }*/
            get { return DescList; }
        }

        void DeleteDataItemDesc()
        {
  //          Debug.WriteLine("Action: " + dataItemDescList[0].ID);

        }
    }
}
