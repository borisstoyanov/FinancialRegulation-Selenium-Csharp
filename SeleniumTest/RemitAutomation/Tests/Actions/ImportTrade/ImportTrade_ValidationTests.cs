using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemitAutomation.Utils;

namespace RemitAutomation.Tests.Actions.ImportOrder
{
    [TestClass]
    public class ImportTrade_ValidationTests : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsREMITUser();
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void TFieldValidationInput_Trade_GenXML_MissingSTI()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("uniqueTransactionIdentifier", "uniqueTransactionIdentifier", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15); 
            Test.result = "Passed";
        }

        //[TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void TFieldValidationInput_Trade_GenXML_Unlinked()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("actionType", "NewBorisUnlinked")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(15);
            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void TFieldValidationInput_Trade_GenXML_Price_Missing()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("priceDetails", "priceCurrency", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI + "*", 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyError(15);
            Test.result = "Passed";
        }
        
        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportTrade"), TestMethod()]
        public void TFieldValidationInput_Trade_GenXML_ActionCancel()
        {
            storeResults = true;
            CreateImportFile.GenXMLTrade();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportREMITGeneralXMLWith()
                .EditTradeNode("actionType", "C")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI+ "*", 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyError(15);
            Test.result = "Passed"; 
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
