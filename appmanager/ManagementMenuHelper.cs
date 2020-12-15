using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void GoToProjectMenu()
        {
            driver.FindElements(By.CssSelector("ul.nav.nav-tabs.padding-18 li"))[2].Click();
        }
    }
}
