using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ActionsUserInterface.ImportTrades
{
    [TestClass]
    public class TImportTrade_TC20014 : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportTrade"), TestCategory("RegressionTesting"), TestMethod()]
        public void TC20014_ImportTrade_EffectiveDate_InvalidInput()
        {
            CSVEditor.CreateNewTREMIR_R010("Positions\\TREMIR\\PRD_R001_TREMIR_NonDel_Regis.csv", "PRD_R001_");
            CSVEditor.FindReplaceElement("ChangeSTI", Test.UTI); PO_Dashboard.GoToImportTradeManualSource();
            CSVEditor.FindReplaceElement("EffDate", string.Empty);
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportTREMIRFileR001()
                .Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyStaticIssue(90);
            Test.result = "Passed";

        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
