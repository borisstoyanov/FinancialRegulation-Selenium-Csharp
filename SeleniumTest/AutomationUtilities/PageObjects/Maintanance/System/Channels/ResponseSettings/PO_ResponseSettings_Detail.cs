using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationUtilities.PageObjects
{
    public class PO_ResponseSettings_Details
    {
        public PO_ResponseSettings_Details(string id)
        {
            try
            {
                // Util.WaitForElementVisibleByXPath("//a[text()='Response Settings']", 60);
                Util.WaitForElementPresentByXPath("//h2[text()='Detail " + id + " (EMIR, DTCC)']", 60);
            }
            catch (NotOnTheExpectedPageException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
            Util.CheckIfTextPresented(Test.extRef);
        }
    }
}
