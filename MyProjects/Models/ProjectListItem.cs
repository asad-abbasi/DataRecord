using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;
using SQLitePCL;

namespace MyProjects.Models
{
    public class ProjectListItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        [ForeignKey(typeof(Project))]
        public int ProjectId { set; get; }
        public string Versions{ set; get; }
        public string CreatorName { set; get; }
        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Project project { set; get; }
        public ProjectListItem()
        { }
        public ProjectListItem(int Id, int ProjectId, string Versions, string CreatorName)
        {
            this.Id = Id;
            this.ProjectId = ProjectId;
            this.Versions = string.Copy(Versions);
            this.CreatorName = string.Copy(CreatorName);
        }
    }
}
