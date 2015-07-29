using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.WorkQ
{
    [TestClass]
    public class TWorkQSortColumnsAsc : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void WorkQ_SortColumnAsc()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue allTrades = dash.DailyTrades().Invalid().RepairRequiredQueue();
            allTrades.SortColumnsAsc("Created Date");
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
