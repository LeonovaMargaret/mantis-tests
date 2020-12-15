using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Id("username"), account.Username);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            Type(By.Id("password"), account.Password);
            driver.FindElement(By.CssSelector("span.lbl.padding-6")).Click();
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("li.grey.open")).Click();
                driver.FindElement(By.CssSelector("a[href*='logout_page.php']")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("span.user-info"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUserName() == account.Username;
        }

        public string GetLoggedUserName()
        {
            return driver.FindElement(By.CssSelector("span.user-info")).Text;
        }
    }
}
