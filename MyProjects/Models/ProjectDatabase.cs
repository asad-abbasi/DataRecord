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
        public static int PAGE_TYPE_NEW = 1;
        public static int PAGE_TYPE_UPDATE = 0;
        public static long NEXT_INDEX = 0;

        private static SQLiteConnection _database = null;
 
        public static void Load()
        {
            _database = new SQLiteConnection(Constants.DatabasePath);
//           _database.DropTable<Project>();
//            if (!_database.TableMappings.Any(m => m.MappedType.Name == typeof(Project).Name))
            {
                if (_database.CreateTable<Project>()==0)
                {
                    _database.DropTable<ProjectListItem>();
                }
            }
 //           if (!_database.TableMappings.Any(m => m.MappedType.Name == typeof(ProjectListItem).Name))
            {
                if (_database.CreateTable<ProjectListItem>() == 0)
                    AddTestDataToDB();
            }

        }

        static void AddTestDataToDB()
        {
            Project dataItem1 = new Project();
            dataItem1.dataItemDescList = new ObservableCollection<ProjectListItem>();
            dataItem1.Name = "Adding Machine";
            dataItem1.DateCreated = DateTime.Now.Date;
            dataItem1.DateModified = DateTime.Now.Date;
            dataItem1.Description = "Machine that can add its input to the previous sum. Numbers should be less than 5 digits, floating point numbers are also possible";
            dataItem1.dataItemDescList.Add(new ProjectListItem {Versions = "Ver 1.2.2", CreatorName = "Jhon" });
            SaveItem(dataItem1, PAGE_TYPE_NEW);

            dataItem1.Name = "Adding Machine 2";
            dataItem1.DateCreated = DateTime.Now.Date;
            dataItem1.DateModified = DateTime.Now.Date;
            dataItem1.Description = "Machine that can add its input to the previous sum. Numbers should be less than 5 digits, floating point numbers are also possible";

            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 6.2.2", CreatorName = "Jhon" });
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 6.2.2", CreatorName = "CHaun" });
            SaveItem(dataItem1, PAGE_TYPE_NEW);

            dataItem1.Name = "Date Storage Machine";
            dataItem1.DateCreated = DateTime.Now.Date;
            dataItem1.DateModified = DateTime.Now.Date;
            dataItem1.Description = "Machine that can add its input to the previous sum. Numbers should be less than 5 digits, floating point numbers are also possible";
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Jane" });
            SaveItem(dataItem1, PAGE_TYPE_NEW);

            dataItem1.Name = "Paitient Record Keeping";
            dataItem1.DateCreated = DateTime.Now.Date;
            dataItem1.DateModified = DateTime.Now.Date;
            dataItem1.Description = "Machine that can add its input to the previous sum. Numbers should be less than 5 digits, floating point numbers are also possible";
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 3.2.2", CreatorName = "Laurin" });
            SaveItem(dataItem1, PAGE_TYPE_NEW);

            dataItem1.Name = "Grossary Store Inventory Record Management Program";
            dataItem1.DateCreated = DateTime.Now.Date;
            dataItem1.DateModified = DateTime.Now.Date;
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 4.2.2", CreatorName = "Jhon" });
            dataItem1.Description = "Machine that can add its input to the previous sum. Numbers should be less than 5 digits, floating point numbers are also possible";
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 4.2.2", CreatorName = "Lina" });
            SaveItem(dataItem1, PAGE_TYPE_NEW);

            dataItem1.Name = "Photo Editing software";
            dataItem1.DateCreated = DateTime.Now.Date;
            dataItem1.DateModified = DateTime.Now.Date;
            dataItem1.Description = "Machine that can add its input to the previous sum. Numbers should be less than 5 digits, floating point numbers are also possible";
            dataItem1.dataItemDescList.Add(new ProjectListItem { Versions = "Ver 5.2.2", CreatorName = "Hina" });
            SaveItem(dataItem1, PAGE_TYPE_NEW);
        }


        public static List<Project> GetItems()
        {
            return _database.GetAllWithChildren<Project>().ToList();
        }
 /*       public Project GetItem(int Id)
        {
            return Database.GetWithChildren<Project>(Id);
        }
 */
        public Project GetItem(int id)
        {
            return _database.GetWithChildren<Project>(id, recursive: true);
        }

        public static void SaveItem(Project item, int pageType)
        {
            if (pageType == PAGE_TYPE_NEW)
            {
                _database.InsertWithChildren(item, recursive: true);
            }
            else
            {
                _database.Update(item);
                _database.Update(new ProjectListItem()
                {
                    Versions = item.dataItemDescList[item.dataItemDescList.Count - 1].Versions,
                    CreatorName = item.dataItemDescList[item.dataItemDescList.Count - 1].CreatorName
                } );
                ProjectListItem pl = item.dataItemDescList[item.dataItemDescList.Count - 1];
                _database.Insert(pl);
                _database.UpdateWithChildren(item);
            }
        }

        public static void DeleteItem(Project item)
        {
            _database.Delete(item, recursive: true);
        }

    }
}
