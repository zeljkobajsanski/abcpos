using System;
using System.IO;
using AbcPos.Core.Interfaces;
using AbcPos.Core.Repository;

namespace AbcPos.Kasa
{
    public class LocalDatabasePath
    {
        private static string _applicationDirectory;
        private static string _database;
        private static string _databaseCopy;

        public static void Init()
        {
            _applicationDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ABCPos");
            if (!Directory.Exists(_applicationDirectory))
            {
                Directory.CreateDirectory(_applicationDirectory);
            }
            _database = Path.Combine(_applicationDirectory, "DB.sdf");
            _databaseCopy = Path.Combine(_applicationDirectory, "DB_1.sdf");
        }

        public static ILocalRepository GetLocalRepostiory()
        {
            return new LocalRepository("Data Source=" + _database);
        }

        public static ILocalRepository GetLocalCopyRepostiory()
        {
            return new LocalRepository("Data Source=" + _databaseCopy);
        }

        public static string GetDatabaseCopyPath()
        {
            return _databaseCopy;
        }

        public static void SwapDatabases()
        {
            File.Copy(_databaseCopy, _database, true);
        }
    }
}