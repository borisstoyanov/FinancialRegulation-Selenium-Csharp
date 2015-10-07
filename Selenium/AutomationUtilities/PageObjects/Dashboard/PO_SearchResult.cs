using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;

namespace AutomationUtilities.PageObjects.NavigationPO
{
    public class PO_SearchResult
    {
        public PO_SearchResult()
        {

            Util.CheckIfOneOfElementsPresented("//*[contains(@id,'EMIRTransactionView')]", "//div[@id='multipleRecords']", 100);
        }
    
        public void VerifyResult()
        {
            Util.CheckIfOneOfElementsPresented("//*[contains(@id,'EMIRTransactionView')]", "//div[@id='multipleRecords']", 100);
            if (Util.IsElementVisible(By.Id("utiNoRecordsFound")))
            {
                Test.verificationErrors.Append("No Records found!");
                Assert.Fail("No Records found!");
            }
        }
    }
}
