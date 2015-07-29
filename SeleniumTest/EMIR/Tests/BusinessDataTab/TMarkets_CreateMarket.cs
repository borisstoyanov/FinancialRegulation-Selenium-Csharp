using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.Markets;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TMarkets_CreateMarket : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Market_CreateMarket()
        {
            storeResults = true;
            PO_MarketsPopUp markets = PO_Dashboard.GoToMarkets();
            markets.CreateMarket()
                .Save();
            markets.VerifyMarketCreated();
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
