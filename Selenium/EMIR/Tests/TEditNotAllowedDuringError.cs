using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirAutomation.Tests
{
    [TestClass]
    public class TEditNotAllowedDuringError : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();

        }

        [TestCategory("Send"), TestCategory("SendTrades"), TestCategory("SendDTCC"), TestMethod()]
        public void EditTrade_EditNotAllowedDuringError()
        {
            storeResults = true;
            ImportTrade.Trade("No");
            CreateImportFile.CreateDuplicateImportFileGenXML();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportGeneralXMLWith()
                .Import();
            importPage.VerifyFileIsUploaded();

            PO_EditEmirTransactionPage emirTransactionPage = PO_UTISearch.GoTo(Test.UTI + "ERR*", 50); 
            emirTransactionPage.VerifyEditingNotPossible();

            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
