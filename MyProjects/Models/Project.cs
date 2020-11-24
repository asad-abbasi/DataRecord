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
/*      public string TechnicalSpecs { set; get; }
        public string VendorName { set; get; }
        public string ClientName { set; get; }
*/
        public ObservableCollection<ProjectListItem> dataItemDescList = new ObservableCollection<ProjectListItem>();

        public Project ShallowCopy()
        {
            Project other = (Project)this.MemberwiseClone();
            other.dataItemDescList = new ObservableCollection<ProjectListItem>();

            int count = this.dataItemDescList.Count;
            for (int index = 0; index < count; index++)
            {
                Debug.WriteLine("Action: " + this.ID);
                Debug.WriteLine("Action: " + (this.dataItemDescList[count]).Versions);
                other.dataItemDescList.Add(new ProjectListItem((this.dataItemDescList[0]).Versions, (this.dataItemDescList[count]).CreatorName));
                Debug.WriteLine("Action: " + (this.dataItemDescList[count]).Versions + "copied" + (other.dataItemDescList[0]).Versions);
            }

            return other;

        }
    }
}
