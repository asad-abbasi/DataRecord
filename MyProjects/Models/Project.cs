using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;

namespace MyProjects.Models
{
    public class Project
    {
        public string ID { set; get; }
        public string Name { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public string Description { set; get; }
        /*      public string TechnicalSpecs { set; get; }
                public string VendorName { set; get; }
                public string ClientName { set; get; }
        */
        public ObservableCollection<ProjectListItem> dataItemDescList = new ObservableCollection<ProjectListItem>();

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
                    other.dataItemDescList.Add(new ProjectListItem((this.dataItemDescList[index]).Versions, (this.dataItemDescList[index]).CreatorName));
                }
            }
            return other;

        }
    }
}
