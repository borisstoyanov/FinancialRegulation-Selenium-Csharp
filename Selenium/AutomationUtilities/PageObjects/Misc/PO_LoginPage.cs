using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace AutomationUtilities.PageObjects
{
    public class PO_LoginPage
    {
        String expectedPage = "Login";
        String actualPage;

        public PO_LoginPage()
        {
            Browser.Browser.GoToLoginPage();
            try
            {
                actualPage = Browser.Browser.Instance.Title.ToString();
                if (!expectedPage.Equals(actualPage))
                {
                    throw new NotOnTheExpectedPageException(expectedPage, actualPage);
                }
            }
            catch (NotOnTheExpectedPageException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one. \nExpected this: " + e.getExpectedPage() + "\nbut got this: " + e.getActualPage());
                Test.TearDown(true);

            }

        }
        public PO_Dashboard LoginWithRegularUser()
        {
            Util.WaitForElementVisibleByXPath("//*[@id='User_Username']", 15);
            Browser.Browser.Instance.FindElement(By.Id("User_Username")).SendKeys("IEMIRUserAuto01");
            Browser.Browser.Instance.FindElement(By.Id("User_LoginPassword")).SendKeys("IEMIRUserAuto10!");
            Browser.Browser.ClickByID("Login");
            return new PO_Dashboard();
        }

        public PO_Dashboard LoginWithIEMIRUser2()
        {
            Browser.Browser.Instance.FindElement(By.Id("User_Username")).SendKeys("IEMIRUserQA1");
            Browser.Browser.Instance.FindElement(By.Id("User_LoginPassword")).SendKeys("IEMIRUserQA1!");
            Browser.Browser.ClickByID("Login");
            return new PO_Dashboard();
        }

        public PO_Dashboard LoginWithTenantA_EMIRUser()
        {
            Browser.Browser.Instance.FindElement(By.Id("User_Username")).SendKeys("IEMIRUserAuto01");
            Browser.Browser.Instance.FindElement(By.Id("User_LoginPassword")).SendKeys("IEMIRUserAuto10!");
            Browser.Browser.ClickByID("Login");
            return new PO_Dashboard();
        }

        public PO_Dashboard LoginWithTenantB_EMIRUser01()
        {
            Browser.Browser.Instance.FindElement(By.Id("User_Username")).SendKeys("IEMIRUserAuto01_TenantB");
            Browser.Browser.Instance.FindElement(By.Id("User_LoginPassword")).SendKeys("IEMIRUserAuto01_B!");
            Browser.Browser.ClickByID("Login");
            return new PO_Dashboard();
        }

        public PO_Dashboard LoginWithTenantB_EMIRUser02()
        {
            Browser.Browser.Instance.FindElement(By.Id("User_Username")).SendKeys("IEMIRUserAuto02_TenantB");
            Browser.Browser.Instance.FindElement(By.Id("User_LoginPassword")).SendKeys("IEMIRUserAuto02_TenantB!");
            Browser.Browser.ClickByID("Login");
            return new PO_Dashboard();
        }

        public PO_Dashboard LoginWithTenantA_REMITUser()
        {
            Browser.Browser.Instance.FindElement(By.Id("User_Username")).SendKeys("IREMITUserAuto01_A");
            Browser.Browser.Instance.FindElement(By.Id("User_LoginPassword")).SendKeys("IREMITUserAuto01_A!");
            Browser.Browser.ClickByID("Login");
            return new PO_Dashboard();
        }

        public PO_Dashboard LoginWithTenantB_REMITUser()
        {
            Browser.Browser.Instance.FindElement(By.Id("User_Username")).SendKeys("IREMITUserAuto01_B");
            Browser.Browser.Instance.FindElement(By.Id("User_LoginPassword")).SendKeys("IREMITUserAuto01_B!");
            Browser.Browser.ClickByID("Login");
            return new PO_Dashboard();
        }

        public PO_Dashboard LoginWithSystemUser()
        {
            Util.WaitForElementVisibleByXPath("//*[@id='User_Username']", 15);
            Browser.Browser.Instance.FindElement(By.Id("User_Username")).SendKeys("IEMIRUser3");
            Browser.Browser.Instance.FindElement(By.Id("User_LoginPassword")).SendKeys("IEMIRUser3@");
            Browser.Browser.ClickByID("Login");
            return new PO_Dashboard();
        }

        public PO_Dashboard LoginWithSystemUserB()
        {
            Util.WaitForElementVisibleByXPath("//*[@id='User_Username']", 15);
            Browser.Browser.Instance.FindElement(By.Id("User_Username")).SendKeys("IEMIRUser4");
            Browser.Browser.Instance.FindElement(By.Id("User_LoginPassword")).SendKeys("IEMIRUser4!@");
            Browser.Browser.ClickByID("Login");
            return new PO_Dashboard();
        }

        public PO_Dashboard LoginWithVladimirChernev()
        {
            Util.WaitForElementVisibleByXPath("//*[@id='User_Username']", 15);
            Browser.Browser.Instance.FindElement(By.Id("User_Username")).SendKeys("IEMIRVladimirChernev1");
            Browser.Browser.Instance.FindElement(By.Id("User_LoginPassword")).SendKeys("IEMIRVladimirChernev1!");
            Browser.Browser.ClickByID("Login");
            return new PO_Dashboard();
        }

        internal PO_Dashboard LoginWithREMITSysUser()
        {
            Util.WaitForElementVisibleByXPath("//*[@id='User_Username']", 15);
            Browser.Browser.Instance.FindElement(By.Id("User_Username")).SendKeys("IREMITUser3");
            Browser.Browser.Instance.FindElement(By.Id("User_LoginPassword")).SendKeys("iremituSER3@");
            Browser.Browser.ClickByID("Login");
            return new PO_Dashboard();
        }

        internal PO_Dashboard LoginWithREMITUser()
        {
            Util.WaitForElementVisibleByXPath("//*[@id='User_Username']", 15);
            Browser.Browser.Instance.FindElement(By.Id("User_Username")).SendKeys("RegisClient1-StandardUser1");
            Browser.Browser.Instance.FindElement(By.Id("User_LoginPassword")).SendKeys("RegisClient1-StandardUser1!");
            Browser.Browser.ClickByID("Login");
            return new PO_Dashboard();
        }
    }
}
