using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TTradeRepositories_Detail : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void TradeRepository_ViewTradeRepositories()
        {
            storeResults = true;
            PO_TradeRepositoriesPopUp referenceDatas = PO_Dashboard.GoToTradeRepositoriesPopUp();
            referenceDatas.CreateNewTradeRepositories()
                .Create();
            referenceDatas.VerifyTradeRepositoriesCreated();
            referenceDatas.ViewTradeRepositoriesDetails();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
