using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.Configuration;

namespace mantis_tests
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }

    public class MySettings : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "SqlServer";
        public string DefaultDataProvider => "SqlServer";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "BugTracker",
                        ProviderName = "MySql.Data.MySqlClient",
                        ConnectionString = @"Server=localhost;Port=3306;Database=bugtracker;Uid=root;Pwd=;charset=utf8;Allow Zero Datetime = true"
                    };
            }
        }
    }
}