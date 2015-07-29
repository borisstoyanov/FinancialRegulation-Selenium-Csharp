using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TTraderepositoryAccounts_Create : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void TradeRepositoryAccount_CreateTradeRepositoryAccounts()
        {
            storeResults = true;
            PO_TradeRepositoryAccountsPopUp tradeRepo = PO_Dashboard.GoToTradeRepositoryAccountsPopUp();
            tradeRepo.CreateNewTradeRepositoryAccounts()
                .Create();
            tradeRepo.VerifyTradeRepositoryAccountsCreated();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
