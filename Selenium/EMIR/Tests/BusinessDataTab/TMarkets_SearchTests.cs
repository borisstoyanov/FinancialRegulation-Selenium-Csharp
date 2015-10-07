using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.Markets;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TMarkets_SearchTests : Test
    {
        bool storeResults = false;
        string searchTerm;
        string mic;
        PO_MarketsPopUp markets;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            markets = PO_Dashboard.GoToMarkets();
            markets.CreateMarket()
                .Save();
            markets.VerifyMarketCreated();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Market_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            markets = new PO_MarketsPopUp();
            markets.SearchForMarket(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Market_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            markets = new PO_MarketsPopUp();
            markets.SearchForMarket(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Market_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            markets = new PO_MarketsPopUp();
            markets.SearchForMarket(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Market_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            markets = new PO_MarketsPopUp();
            markets.SearchForMarket(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Market_SearchingEndsWithAsteriskByMIC()
        {
            storeResults = true;
            mic = Test.extRef.Remove(Test.extRef.Length - 3);
            searchTerm = mic.Remove(mic.Length - 1) + "*";
            markets = new PO_MarketsPopUp();
            markets.SearchForMarketByMIC(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Market_SearchingStartsWithAsteriskByMIC()
        {
            storeResults = true;
            mic = Test.extRef.Remove(Test.extRef.Length - 3);
            searchTerm = "*" + mic.Substring(1);
            markets = new PO_MarketsPopUp();
            markets.SearchForMarketByMIC(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Market_SearchingEndsAndStartsWithAsteriskByMIC()
        {
            storeResults = true;
            mic = Test.extRef.Remove(Test.extRef.Length - 3);
            string substracted = "*" + mic.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 1) + "*";
            markets = new PO_MarketsPopUp();
            markets.SearchForMarketByMIC(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Market_SearchingFullNameByMIC()
        {
            storeResults = true;
            mic = Test.extRef.Remove(Test.extRef.Length - 3);
            searchTerm = mic;
            markets = new PO_MarketsPopUp();
            markets.SearchForMarketByMIC(searchTerm);
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
