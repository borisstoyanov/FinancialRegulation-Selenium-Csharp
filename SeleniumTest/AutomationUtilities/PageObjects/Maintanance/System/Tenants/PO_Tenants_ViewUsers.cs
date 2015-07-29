using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationUtilities.PageObjects
{
    public class PO_Tenants_ViewUsers
    {
        public PO_Tenants_ViewUsers()
        {

            try
            {
                Util.WaitForElementPresentByXPath("//h2[text()='View Users for Tenant ']", 60);
   //             Browser.Browser.ClickByXPath("//a[text()='Close']");
            }
            catch (NotOnTheExpectedPageException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");

            }
        }
    }
}
