using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public static List<ProjectData> GetAllProjects (AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projectData = 
                client.mc_projects_get_user_accessible(account.Username, account.Password);

            ProjectData pr = new ProjectData();
            List<ProjectData> project = new List<ProjectData>();

            foreach(Mantis.ProjectData data in projectData)
            {
                pr.Id = (data.id).ToString();
                pr.Name = data.name;
                pr.Status = (data.status.id).ToString();
                if (data.inherit_global == true)
                    pr.InheritGlobal = "1";
                else
                    pr.InheritGlobal = "0";
                pr.ViewState = (data.view_state.id).ToString();
                pr.Description = data.description;

                project.Add(pr);
            }

            return project;
        }

        public void CreateNewProject (AccountData account, ProjectData projectData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData project = new Mantis.ProjectData();

            project.name = projectData.Name;
            project.status = new Mantis.ObjectRef();
            project.status.id = projectData.Status;
            if (projectData.InheritGlobal == "1")
                project.inherit_global = true;
            else
                project.inherit_global = false;
            project.view_state = new Mantis.ObjectRef();
            project.view_state.id = projectData.ViewState;
            project.description = projectData.Description;

            client.mc_project_add(account.Username, account.Password, project);

            driver.Navigate().Refresh();
        }
    }
}
