using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationUtilities.PageObjects.Maintanance.ReferenceData.ISINCodes
{
    public class PO_ISINCodes_Details
    {
        public PO_ISINCodes_Details(string id)
        {
            try
            {
                Util.WaitForElementVisibleByXPath("//h2[contains(text(),'" + id + "')]", 5);
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
