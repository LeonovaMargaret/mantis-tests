using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Mapping;

namespace mantis_tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "name")]
        public string Name { get; set; } = "";

        [Column(Name = "status")]
        public string Status { get; set; } = "10";

        [Column(Name = "inherit_global")]
        public string InheritGlobal { get; set; } = "0";

        [Column(Name = "view_state")]
        public string ViewState { get; set; } = "10";

        [Column(Name = "description")]
        public string Description { get; set; } = "";

        public ProjectData() { }

        public ProjectData(string name)
        {
            Name = name;
        }
        public static List<ProjectData> GetAll()
        {
            LinqToDB.Data.DataConnection.DefaultSettings = new MySettings();

            using (BugTrackerDB db = new BugTrackerDB())
            {
                return (from p in db.Projects select p).ToList();
            }
        }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
    }
}
