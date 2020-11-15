using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace DataRecord.Models
{
    public class DRItem
    {
        public string ID { set; get; }
        public string Name { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }

        public ObservableCollection<DRItemDescription> dataItemDescList = new ObservableCollection<DRItemDescription>();
    }
}
