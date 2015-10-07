using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationUtilities.PageObjects
{
    public class PO_Currency_Details
    {
        public PO_Currency_Details(string id)
        {
            try
            {
                Browser.Browser.Instance.PageSource.Contains("Detail " + id);
                //                Util.WaitForElementPresentByXPath("//h2[text()='Detail " + id + "']", 60);
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
