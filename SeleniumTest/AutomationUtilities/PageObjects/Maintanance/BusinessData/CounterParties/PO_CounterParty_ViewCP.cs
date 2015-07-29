using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutomationUtilities.PageObjects.Maintanance.BusinessData.CounterParties
{
    public class PO_CounterParty_ViewCP
    {
        public PO_CounterParty_ViewCP()
        {
            try
            {
                Util.WaitForElementVisibleByXPath("//span[text()='Counterparties']", 60);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }

        public void VerifyIntragroupNotPresent()
        {
            Util.WaitForElementNotVisibleByXPath("Intragroup", 15);
        }
    }
}
