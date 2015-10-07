using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ActionsUserInterface.ImportTrades
{
    [TestClass]
    public class TImportTrade_TC20009 : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void TC20009_ImportTrade_PriceMultiplier_Zero()
        {
            CreateImportFile.GenXML();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportGeneralXMLWith()
                .EditTradeNode("PriceMult", "0")
                .SaveXML()
                .Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(90);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void TC20013_ImportTrade_PriceMultiplier_Valid()
        {
            CreateImportFile.GenXML();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportGeneralXMLWith()
                .EditTradeNode("PriceMult", "5")
                .SaveXML()
                .Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(90);
            Test.result = "Passed";

        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void TC19954_ImportTrade_TransactionRefN_null()
        {
            CreateImportFile.GenXML();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportGeneralXMLWith()
                .EditTradeNode("TransactionReferenceNumber", "")
                .SaveXML()
                .Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(90);
            Test.result = "Passed";

        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
