using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_Operations_EditRoles
    {
        public PO_Operations_EditRoles()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//select[@id='SelectedUnrelated']", 15);
                Browser.Browser.ClickByID("add");
                Thread.Sleep(1000);
                Browser.Browser.ClickByID("submitselected");
                Thread.Sleep(1000);
            }
            catch (NotOnTheExpectedPageException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }
    }
}
