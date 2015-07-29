using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationUtilities.PageObjects
{
    public class PO_Operations_Details
    {
        public PO_Operations_Details()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//a[text()='Operations']", 60);
            }
            catch (NotOnTheExpectedPageException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }
    }
}
