using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TTradeRepositoryAccounts_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
            PO_TradeRepositoryAccountsPopUp referenceDatas = PO_Dashboard.GoToTradeRepositoryAccountsPopUp();
            referenceDatas.CreateNewTradeRepositoryAccounts()
                .Create();
            referenceDatas.VerifyTradeRepositoryAccountsCreated();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void TradeRepositoryAccount_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_TradeRepositoryAccountsPopUp referenceDatas = new PO_TradeRepositoryAccountsPopUp();
            referenceDatas.SearchTradeRepositoryAccounts(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void TradeRepositoryAccount_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_TradeRepositoryAccountsPopUp referenceDatas = new PO_TradeRepositoryAccountsPopUp();
            referenceDatas.SearchTradeRepositoryAccounts(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void TradeRepositoryAccount_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_TradeRepositoryAccountsPopUp referenceDatas = new PO_TradeRepositoryAccountsPopUp();
            referenceDatas.SearchTradeRepositoryAccounts(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void TradeRepositoryAccount_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_TradeRepositoryAccountsPopUp referenceDatas = new PO_TradeRepositoryAccountsPopUp();
            referenceDatas.SearchTradeRepositoryAccounts(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
