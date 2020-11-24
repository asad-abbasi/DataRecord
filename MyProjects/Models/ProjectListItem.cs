using System;
using System.Collections.Generic;
using System.Text;

namespace MyProjects.Models
{
    public class ProjectListItem
    {
        public string Versions{ set; get; }
        public string CreatorName { set; get; }

        public ProjectListItem()
        { }
        public ProjectListItem(string Versions, string CreatorName)
        {
            this.Versions = string.Copy(Versions);
            this.CreatorName = string.Copy(CreatorName);
        }
    }
}
