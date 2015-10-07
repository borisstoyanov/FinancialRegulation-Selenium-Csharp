using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.Dashboard
{
    [TestClass]
    public class TDashboard_CheckApplicationHistory : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestMethod()]
        public void Dashboard_CheckApplicationHistory()
        {
            storeResults = true;
            ImportTrade.Trade("no");
            PO_Dashboard.GoTo();
            PO_Dashboard dash = new PO_Dashboard();
            dash.CheckHistory();
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
