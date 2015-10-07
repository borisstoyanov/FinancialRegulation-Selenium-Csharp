using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationUtilities.PageObjects.BicPO
{
    public class PO_BIC_Details
    {
        public PO_BIC_Details()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//h2[text()='Detail " + Test.extRef +"']", 60);
            }
            catch (NotOnTheExpectedPageException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }
    }
}
