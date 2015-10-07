using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_Tenants_EditUsers
    {
        public PO_Tenants_EditUsers()
        {

            try
            {
                //             Browser.Browser.ClickByXPath("//a[text()='Close']");
                Util.WaitForElementPresentByXPath("//select[@id='SelectedUnrelated']", 15);
                new SelectElement(Browser.Browser.Instance.FindElement(By.Id("SelectedUnrelated"))).SelectByText("Administrator1(Global)");
                Browser.Browser.ClickByID("add");
                Thread.Sleep(1000);
                Browser.Browser.ClickByID("submitselected");
                Thread.Sleep(1000);
               
                IAlert alert =  Browser.Browser.Instance.SwitchTo().Alert();
                alert.Accept();
            }
            catch (NotOnTheExpectedPageException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");

            }
        }
    }
}
