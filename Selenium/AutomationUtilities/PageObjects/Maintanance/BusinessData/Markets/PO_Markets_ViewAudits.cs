using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutomationUtilities.PageObjects.Markets
{
    public class PO_Markets_ViewAudits
    {
        public PO_Markets_ViewAudits()
        {
            try
            {
                Util.WaitForElementVisibleByXPath("//h2[contains(text(),'" + Test.extRef + "')]", 15);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }
    }
}
