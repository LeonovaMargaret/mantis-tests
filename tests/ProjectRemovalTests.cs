using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        {
            int removedIndex = 0;

            if (!app.ProjectManagement.IsProjectExists(removedIndex))
            {
                ProjectData project = new ProjectData("TestRemovalName123")
                {
                    Status = "30",
                    InheritGlobal = "1",
                    ViewState = "50",
                    Description = "TestRemovalDescription"
                };
                app.ProjectManagement.Create(project);
            }

            List<ProjectData> oldProjects = ProjectData.GetAll();
            
            app.ProjectManagement.Remove(oldProjects[removedIndex]);

            List<ProjectData> newProjects = ProjectData.GetAll();
            oldProjects.RemoveAt(removedIndex);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
