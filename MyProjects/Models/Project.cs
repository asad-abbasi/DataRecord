using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

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
    }
}
