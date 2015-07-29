using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationUtilities.PageObjects
{
    public class PO_SourceSettings_Details
    {
        public PO_SourceSettings_Details(string id)
        {
            try
            {
                Util.WaitForElementPresentByXPath("//h2[text()='Detail " + id + "']", 60);
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
