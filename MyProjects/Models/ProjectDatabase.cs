using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using SQLiteNetExtensions;
using SQLitePCL;
using SQLiteNetExtensions.Attributes;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System.Diagnostics;

namespace MyProjects.Models
{
    public class ProjectDatabase
    {

        static SQLiteConnection Database = new SQLiteConnection(Constants.DatabasePath);
        static bool initialized = false;

        public ProjectDatabase()
        {
            Initialize();
        }

        void Initialize()
        {
 //           Database.DropTable<Project>();
 //           Database.DropTable<ProjectListItem>();
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Project).Name))
                {
                    if (Database.CreateTable<Project>()==0)
                    {
                        Database.DropTable<ProjectListItem>();
                        AddTestDataToDB();
                    }
//                    AddTestDataToDB();
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ProjectListItem).Name))
                {
                    Database.CreateTable<ProjectListItem>();
//                    Database.CreateTables(CreateFlags.None, typeof(ProjectListItem));
                }

                initialized = true;
            }
        }

        void AddTestDataToDB()
        {
            Project dataItem1 = new Project();
            dataItem1.dataItemDescList = new ObservableCollection<ProjectListItem>();
            dataItem1.Name = "Adding Machine";
            dataItem1.DateCreated = DateTime.Now.Date;
            dataItem1.DateModified = DateTime.Now.Date;
            dataItem1.Description = "Machine that can add its input to the previous sum. Numbers should be less than 5 digits, floating point numbers are also possible";
            dataItem1.dataItemDescList.Add(new ProjectListItem {Versions = "Ver 1.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 1.2.2", CreatorName = "CHaun" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 1.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 1.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 1.2.2", CreatorName = "Jhon" });
            
            SaveItem(dataItem1, App.PAGE_TYPE_NEW);

            dataItem1.Name = "Adding Machine 2";
            dataItem1.DateCreated = DateTime.Now.Date;
            dataItem1.DateModified = DateTime.Now.Date;
            dataItem1.Description = "Machine that can add its input to the previous sum. Numbers should be less than 5 digits, floating point numbers are also possible";
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 6.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 6.2.2", CreatorName = "CHaun" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 6.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 6.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 6.2.2", CreatorName = "Jhon" });
            SaveItem(dataItem1, App.PAGE_TYPE_NEW);

            dataItem1.Name = "Date Storage Machine";
            dataItem1.DateCreated = DateTime.Now.Date;
            dataItem1.DateModified = DateTime.Now.Date;
            dataItem1.Description = "Machine that can add its input to the previous sum. Numbers should be less than 5 digits, floating point numbers are also possible";
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "CHaun" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            SaveItem(dataItem1, App.PAGE_TYPE_NEW);

            dataItem1.Name = "Paitient Record Keeping";
            dataItem1.DateCreated = DateTime.Now.Date;
            dataItem1.DateModified = DateTime.Now.Date;
            dataItem1.Description = "Machine that can add its input to the previous sum. Numbers should be less than 5 digits, floating point numbers are also possible";
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "CHaun" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jhon" });
            SaveItem(dataItem1, App.PAGE_TYPE_NEW);

            dataItem1.Name = "Grossary Store Inventory Record Management Program";
            dataItem1.DateCreated = DateTime.Now.Date;
            dataItem1.DateModified = DateTime.Now.Date;
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 4.2.2", CreatorName = "Jhon" });
            dataItem1.Description = "Machine that can add its input to the previous sum. Numbers should be less than 5 digits, floating point numbers are also possible";
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 4.2.2", CreatorName = "CHaun" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 4.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 4.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 4.2.2", CreatorName = "Jhon" });
            SaveItem(dataItem1, App.PAGE_TYPE_NEW);

            dataItem1.Name = "Photo Editing software";
            dataItem1.DateCreated = DateTime.Now.Date;
            dataItem1.DateModified = DateTime.Now.Date;
            dataItem1.Description = "Machine that can add its input to the previous sum. Numbers should be less than 5 digits, floating point numbers are also possible";
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 5.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 5.2.2", CreatorName = "CHaun" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 5.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 5.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 5.2.2", CreatorName = "Jhon" });
            SaveItem(dataItem1, App.PAGE_TYPE_NEW);
        }


        public List<Project> GetItems()
        {
            return Database.GetAllWithChildren<Project>().ToList();
        }
 /*       public Project GetItem(int Id)
        {
            return Database.GetWithChildren<Project>(Id);
        }
 */
        public Project GetItem(int id)
        {
            return Database.GetWithChildren<Project>(id, recursive: true);
        }

        public void SaveItem(Project item, int pageType)
        {
            if (pageType == App.PAGE_TYPE_NEW)
            {
                Database.InsertWithChildren(item, recursive: true);
//                Database.Insert(item);
//                Database.InsertAll(item.dataItemDescList);
//                Database.UpdateWithChildren(item);
            }
            else
            {
                Database.Update(item);
                Database.Update(new ProjectListItem()
                {
                    Versions = item.dataItemDescList[item.dataItemDescList.Count - 1].Versions,
                    CreatorName = item.dataItemDescList[item.dataItemDescList.Count - 1].CreatorName
                } );
                ProjectListItem pl = item.dataItemDescList[item.dataItemDescList.Count - 1];
                Database.Insert(pl);
                Database.UpdateWithChildren(item);
            }
        }

        public void DeleteItem(Project item)
        {
            Database.Delete(item, recursive: true);
        }

    }
}
