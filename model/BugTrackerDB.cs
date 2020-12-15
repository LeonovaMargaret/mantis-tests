using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class BugTrackerDB : LinqToDB.Data.DataConnection
    {
        public BugTrackerDB() : base("BugTracker") { }

        public ITable<ProjectData> Projects { get { return GetTable<ProjectData>(); } }
    }
}
