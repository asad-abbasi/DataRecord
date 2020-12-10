using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using SQLiteNetExtensions;
using SQLitePCL;
using SQLiteNetExtensions.Attributes;
using SQLite;

namespace MyProjects.Models
{
    public class Project
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        public string Name { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public string Description { set; get; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<ProjectListItem> dataItemDescList { get; set; }// = new ObservableCollection<ProjectListItem>();

        public Project DeepCopy()
        {
            Project other = (Project)this.MemberwiseClone();
            other.dataItemDescList = new ObservableCollection<ProjectListItem>();

            int count = this.dataItemDescList.Count;
            if (count >= 0)
            {
                for (int index = 0; index < count; index++)
                {
                    Debug.WriteLine("Action: " + (this.dataItemDescList[index]).Versions);
                    other.dataItemDescList.Add(new ProjectListItem((this.dataItemDescList[index]).Versions,
                                                                    (this.dataItemDescList[index]).CreatorName));
                }
            }
            return other;

        }
    }
}


//[TextBlob("DescBlobbed")]
//public string DescBlobbed { set; get; }
