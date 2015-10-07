using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationUtilities.Tests.Dashboard
{
    [TestClass]
    public class TDashboard_SearchTests : Test
    {
        bool storeResults = false;
        string searchTerm;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportTrade.Trade("No");
            PO_Dashboard.GoTo();
            
        }

        [TestCategory("RegressionTesting"), TestCategory("SearchTrade"), TestCategory("Dashboard"), TestMethod()]
        public void TC15254_Dashboard_SearchTrade_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.STI.Remove(Test.STI.Length - 3) + "*";
            PO_SearchResult result = PO_UTISearch.SearchFor(searchTerm);
            result.VerifyResult();
            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("SearchTrade"), TestCategory("Dashboard"), TestMethod()]
        public void Dashboard_SearchTrade_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.STI.Substring(1);
            PO_SearchResult result = PO_UTISearch.SearchFor(searchTerm);
            result.VerifyResult();
            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("SearchTrade"), TestCategory("Dashboard"), TestMethod()]
        public void Dashboard_SearchTrade_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.STI.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_SearchResult result = PO_UTISearch.SearchFor(searchTerm);
            result.VerifyResult();
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
