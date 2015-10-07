using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests
{
    [TestClass]
    public class TEditTrade : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportTrade.Trade("No");
        }

        [TestCategory("RegressionTesting"), TestMethod()]
        public void EditTrade_EditNotationAmount()
        {
            storeResults = true;
            PO_UTISearch.GoTo(Test.UTI, 50);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.EditNotationAmount("20");
            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestMethod()]
        public void EditTrade_EditCounterparty()
        {

            storeResults = true;
            PO_UTISearch.GoTo(Test.UTI, 50);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.EditCounterparty("Y", "Impendium");
            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestMethod()]
        public void EditTrade_EditProduct()
        {
            storeResults = true;
            PO_UTISearch.GoTo(Test.UTI, 50);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.EditProduct("Physical");
            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestMethod()]
        public void EditTrade_EditConfirmation()
        {
            storeResults = true;
            PO_UTISearch.GoTo(Test.UTI, 50);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.EditConfirmation("FAX");
            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestMethod()]
        public void EditTrade_EditClearing()
        {
            storeResults = true;
            PO_UTISearch.GoTo(Test.UTI, 50);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.EditClearing("Imp");
            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestMethod()]
        public void EditTrade_EditValuation()
        {
            storeResults = true;
            PO_UTISearch.GoTo(Test.UTI, 50);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.EditValuation("SExternal");
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
            Test.MarkTradeAsUsed();
        }
    }
}
