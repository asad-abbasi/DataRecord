using System;
using System.IO;

namespace MyProjects
{
    public static class Constants
    {
        public const string DatabaseFilename = "ProjectDB.db3";

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
