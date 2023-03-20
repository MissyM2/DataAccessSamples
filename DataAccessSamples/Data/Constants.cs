using System;
namespace DataAccessSamples.Data
{
    public static class Constants
    {
        public const string DatabaseFilename = "MembersAppDB.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // The file is encrypted and inaccessible while the device is locked.
            SQLite.SQLiteOpenFlags.ProtectionComplete |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
