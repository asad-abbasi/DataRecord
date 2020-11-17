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

        Project selectedItem;
        ObservableCollection<ProjectListItem> descList;
        public ProjectPageViewModel(Project sel)
        {
            DeleteProjectDescCommand = new Command<ProjectListItem>(/*asynv () await*/ DeleteProjectDesc /*() => !IsBussy*/);
            descList = sel.dataItemDescList;
            selectedItem = sel;
            OnPropertyChanged();
        }
        public ProjectPageViewModel()
        {
        }

        public Command DeleteProjectDescCommand { private set; get; }

        public ObservableCollection<ProjectListItem> DescList
        {
            get { return descList; }
        }
        public Project SelectedItem
        {
            get { return selectedItem; }
        }

        void DeleteProjectDesc(ProjectListItem version)
        {
            Debug.WriteLine("Action: in delete");
            selectedItem.dataItemDescList.Remove(version);
        }
    }
}
