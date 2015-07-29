using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ActionsUserInterface.ImportTrades
{
    [TestClass]
    public class TImportTrade_GenXML_withStaticError_andFix : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportTrade"), TestMethod()]
        public void TC14634_ImportTrade_GenXML_withStaticError_andFix()
        {
            storeResults = true;
            CreateImportFile.GenXML();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportGeneralXMLWith()
                .EditTradeNode("Counterparty1ID", "")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStatusStaticIssues();
            emirTransactionPage.EditTradeAttributeWithAutocompletion("Counterparty", "10_Counterparty_Counterparty_ExternalDiv", "Impendium");
            emirTransactionPage.ValidateEditing();
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
