using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationUtilities.Tests.Dashboard
{
    [TestClass]
    public class TDashboard_ClickHomeRegulationButton : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();

        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestMethod()]
        public void Dashboard_ClickHomeRegulationButton()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            dash.ClickHomeRegulationButton();
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
