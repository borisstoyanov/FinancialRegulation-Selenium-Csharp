using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutomationUtilities.PageObjects.ExtRefInOut
{
    public class PO_ExtRefOut_ViewDetails
    {
        public PO_ExtRefOut_ViewDetails()
        {
            try
            {
                Util.WaitForElementVisibleByXPath("//div[contains(text(),'" + Test.extRef + "')]", 15);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");

            }
        }
    }
}
