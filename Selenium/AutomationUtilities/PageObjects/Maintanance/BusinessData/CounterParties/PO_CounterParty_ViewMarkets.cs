using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutomationUtilities.PageObjects.CounterPartiesPO
{
    public class PO_CounterParty_ViewMarkets
    {
        public PO_CounterParty_ViewMarkets()
        {
            try
            {
                Util.WaitForElementVisibleByXPath("//h2[contains(text(),'" + Test.extRef + "')]", 60);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }
    }
}
