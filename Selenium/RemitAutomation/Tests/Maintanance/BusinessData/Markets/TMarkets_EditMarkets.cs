using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.Markets;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemitAutomation.Tests.Maintanance.BusinessData.Markets
{
    [TestClass]
    public class TMarkets_EditMarkets : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsREMITUser();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void REMIT_Market_EditMarket()
        {
            storeResults = true;
            PO_MarketsPopUp markets = PO_Dashboard.GoToMarkets();
            markets.CreateMarket()
                .Save();
            markets.VerifyMarketCreated();
            markets.EditMarket()
                .SetField(MarketFields.Market_ExternalId1, "ext1")
                .Save();
            markets.VerifyMarketIsEdited();
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
