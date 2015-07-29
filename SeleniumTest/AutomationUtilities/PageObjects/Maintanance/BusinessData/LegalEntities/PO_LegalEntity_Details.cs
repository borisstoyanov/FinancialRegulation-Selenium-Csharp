using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutomationUtilities.PageObjects.LegalEntities
{
    public class PO_LegalEntity_Details
    {
        public PO_LegalEntity_Details()
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
