using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationUtilities.Tests.Dashboard
{
    [TestClass]
    public class TDashboard_ClickAddConfiguredQueuePerTab : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();

        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_ConfiguredQueues_ValuationQs_ClickAdd()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            dash.ConfiguredQueue().ValuationQueues().GoToAddWorkQ();
            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_ConfiguredQueues_ApprovalQs_ClickAdd()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            dash.ConfiguredQueue().ApprovalQueues().GoToAddWorkQ();
            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_ConfiguredQueues_CollateralQs_ClickAdd()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            dash.ConfiguredQueue().CollateralQueues().GoToAddWorkQ();
            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_ConfiguredQueues_EmirQs_ClickAdd()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            dash.ConfiguredQueue().EmirQueues().GoToAddWorkQ();
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
