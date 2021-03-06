﻿using MyProjects.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace MyProjects.ViewModels
{
    class ProjectViewModel : INotifyPropertyChanged
    {
        Project newItem = new Project();
        ObservableCollection<ProjectListItem> descList;
        DateTime minCreatedDate, maxCreatedDate, maxModifiedDate;
        string version, cName;
        bool enable=false;
        public bool insertDesc=true;
        int PageType;
        public bool change=false;

        //pageType = 0, if display/update page
        //pageType = 1, if new page
        public ProjectViewModel(Project sel, int type)//item selected
        {
            minCreatedDate = new DateTime(1995, 01, 20).Date;
            maxCreatedDate = DateTime.Now.Date;
            maxModifiedDate = DateTime.Now.Date;

            PageType = type;
            if (sel != null)//display/update
            {
                descList = sel.dataItemDescList;
                newItem = sel;
            }
            else
                descList = new ObservableCollection<ProjectListItem>();

            if (PageType == ProjectDatabase.PAGE_TYPE_UPDATE)
                enable = false;
            else
                enable = true;

            InsertNewDescCommand = new Command(OnInsertDesc, () => insertDesc);
            DeleteProjectDescCommand = new Command<ProjectListItem>(OnDeleteDesc) ;
            OnPropertyChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public Project NewItem
        {
            //set code is not used
            set
            {
                //not sure about this
                newItem = value;
                OnPropertyChanged();
            }
            get { return newItem; }
        }

        public string Version
        {
            set
            {
                version = value;
                OnPropertyChanged();
            }
            get { return version; }
        }
        public string CName
        {
            set
            {
                cName = value;
                OnPropertyChanged();
            }
            get { return cName; }
        }
        public DateTime MinCreatedDate
        {
            get { return minCreatedDate; }
        }
        public DateTime MaxCreatedDate
        {
            get { return maxCreatedDate; }
        }
        public DateTime MaxModifiedDate
        {
            get { return maxModifiedDate; }
        }
        public bool Enable
        {
            set
            { }
            get { return enable; }
        }
        public ObservableCollection<ProjectListItem> DescList
        {
            set
            {
                descList = value;
            }
            get { return descList; }
        }

        //not sure about this
        public void GetDataReady()
        {
            if (PageType == ProjectDatabase.PAGE_TYPE_NEW)
            {
//                newItem.ID = "PR." + App.NEXT_INDEX;
//                App.NEXT_INDEX++;
                newItem.DateCreated = DateTime.Now;
                newItem.DateModified = DateTime.Now;
            }
            else
            {
                newItem.DateModified = DateTime.Now;
            }

            newItem.dataItemDescList = descList;
            OnPropertyChanged(nameof(NewItem));
        }
        void OnInsertDesc()
        {
            insertDesc = false;
            descList.Add(new ProjectListItem { Versions = " ", CreatorName = " " });
            ((Command)InsertNewDescCommand).ChangeCanExecute();
            change = true;
        }
        void RefreshCanExecutes()
        {
            ((Command)InsertNewDescCommand).ChangeCanExecute();
        }

        void OnDeleteDesc(ProjectListItem delItem)
        {
            descList.Remove(delItem);
            if (delItem.Versions.Equals(" ") ||
                delItem.CreatorName.Equals(" "))
                insertDesc = true;
            ((Command)InsertNewDescCommand).ChangeCanExecute();
            change = true;
        }
        public Command InsertNewDescCommand { private set; get; }
        public Command DeleteProjectDescCommand { private set; get; }
        

    }
}
