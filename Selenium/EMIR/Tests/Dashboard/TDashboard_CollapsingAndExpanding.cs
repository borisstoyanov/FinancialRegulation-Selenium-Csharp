using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationUtilities.Tests.Dashboard
{
    [TestClass]
    public class TDashboard_CollapsingAndExpanding: Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();

        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_CollapseTradesMenuItem()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            dash.DailyTrades().CollapseSection();
            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_CollapseCollateralMenuItem()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            dash.DailyCollateral().CollapseSection();
            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_CollapseValuationMenuItem()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            dash.DailyValuations().CollapseSection();
            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_ExpandTradesMenuItem()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            dash.DailyTrades().CollapseSection();
            dash.DailyTrades().ExpandSection();
            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_ExpandCollateralMenuItem()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            dash.DailyCollateral().CollapseSection();
            dash.DailyCollateral().ExpandSection();
            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_ExpandValuationMenuItem()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            dash.DailyValuations().CollapseSection();
            dash.DailyValuations().ExpandSection();
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
