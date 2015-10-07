using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.Markets;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class MTBusinessataTab_MarketsTests : Test
    {
        bool storeResults = false;
        string searchTerm;
        PO_MarketsPopUp markets;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantA_EMIRUser();

            markets = PO_Dashboard.GoToMarkets();
            markets.CreateMarket()
                .Save();
            markets.VerifyMarketCreated();
            markets.Close();
            PO_UserAccountButton.LogOff();
            login.LoginWithTenantB_EMIRUser01();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTMarket_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            markets = PO_Dashboard.GoToMarkets();
            markets.SearchForMarket(searchTerm);
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
