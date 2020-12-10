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
    class ProjectDatabase
    {
/*        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
 */

        //changes made for one to many blobbed text 7-dec-20
/*        static readonly Lazy<SQLiteConnection> lazyInitializer = new Lazy<SQLiteConnection>(() =>
        {
            return new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
        });
 */
        
        static SQLiteConnection Database = new SQLiteConnection(Constants.DatabasePath);
        static bool initialized = false;

        public ProjectDatabase()
        {
            Initialize();
        }

        void Initialize()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Project).Name))
                {
                    Database.CreateTable<Project>();
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ProjectListItem).Name))
                {
                    Database.CreateTable<ProjectListItem>();
//                    Database.CreateTables(CreateFlags.None, typeof(ProjectListItem));
                }

                initialized = true;
            }
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
