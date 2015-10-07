using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationUtilities.PageObjects
{
    public class PO_Operations_ViewRoles
    {
        public PO_Operations_ViewRoles()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//h2[text()='View Roles for Operation: Above Clearing Threshold - Create']", 60);
            }
            catch (NotOnTheExpectedPageException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }
    }
}
