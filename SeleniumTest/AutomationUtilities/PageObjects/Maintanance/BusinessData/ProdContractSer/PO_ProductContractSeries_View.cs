using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AutomationUtilities.PageObjects.Maintanance.BusinessData.ProdContractSer
{
    public class PO_ProductContractSeries_View
    {
        public PO_ProductContractSeries_View()
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
