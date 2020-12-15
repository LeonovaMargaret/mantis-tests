using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            //List<ProjectData> oldProjects = ProjectData.GetAll();
            AccountData account = new AccountData("administrator", "root");
            List<ProjectData> oldProjects = APIHelper.GetAllProjects(account);

            ProjectData project = new ProjectData("TestName123")
            {
                Status = "10",
                InheritGlobal = "0",
                ViewState = "10",
                Description = "TestDescription"
            };

            app.ProjectManagement.Create(project);

            //List<ProjectData> newProjects = ProjectData.GetAll();
            List<ProjectData> newProjects = APIHelper.GetAllProjects(account);

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
