using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Create(ProjectData project)
        {
            manager.Navigator.GoToManagementMenu();
            manager.ManagementMenu.GoToProjectMenu();
            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            driver.FindElement(By.XPath("//a[contains(@href, 'manage_proj_page.php')]")).Click();
        }

        public bool IsProjectExists(int projectIndex)
        {
            manager.Navigator.GoToManagementMenu();
            manager.ManagementMenu.GoToProjectMenu();
            //return IsElementPresent(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr["
            //  + projectIndex + "]/td"));
            return IsElementPresent(By.CssSelector("a[href*='manage_proj_edit_page.php"));
        }

        public void InitProjectCreation()
        {
            driver.FindElement(By.CssSelector("div.widget-toolbox.padding-8.clearfix"))
                .FindElement(By.XPath(".//button[@type='submit']")).Click();
        }

        public void Remove(ProjectData projectData)
        {
            SelectProject(projectData.Id);
            RemoveProject();
            SubmitProjectRemoval();
        }

        public void SelectProject(string id)
        {
            driver.FindElement(By.CssSelector("a[href$='manage_proj_edit_page.php?project_id=" + id + "']")).Click();
        }

        public void RemoveProject()
        {
            driver.FindElement(By.CssSelector("form#project-delete-form")).FindElement(By.CssSelector("input[type='submit']")).Click();
        }

        public void SubmitProjectRemoval()
        {
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);

            driver.FindElement(By.CssSelector("select#project-status"))
                .FindElement(By.CssSelector("option[value='" + project.Status + "']")).Click();

            if (project.InheritGlobal == "0")
                driver.FindElement(By.CssSelector("span.lbl")).Click();

            driver.FindElement(By.CssSelector("select#project-view-state"))
                .FindElement(By.CssSelector("option[value='" + project.ViewState + "']")).Click();

            Type(By.Id("project-description"), project.Description);
        }

        public void SubmitProjectCreation()
        {
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
        }
    }
}
