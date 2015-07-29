using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.WorkQ
{
    [TestClass]
    public class TWorkQListNavigationButtonsTests : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("WorkQs"), TestMethod()]
        public void WorkQ_SearchResultNavigation_ClickNext()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue allTrades = dash.DailyTrades().Invalid().RepairRequiredQueue();
            allTrades.ClickNext();
            Test.result = "Passed";
        }

        [TestCategory("WorkQs"), TestMethod()]
        public void WorkQ_SearchResultNavigation_ClickBack()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue allTrades = dash.DailyTrades().Invalid().RepairRequiredQueue();
            allTrades.ClickBack();
            Test.result = "Passed";
        }
        [TestCategory("WorkQs"), TestMethod()]
        public void WorkQ_SearchResultNavigation_ClickLast()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue allTrades = dash.DailyTrades().Invalid().RepairRequiredQueue();
            allTrades.ClickLast();
            Test.result = "Passed";
        }
        [TestCategory("WorkQs"), TestMethod()]
        public void WorkQ_SearchResultNavigation_ClickFirst()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue allTrades = dash.DailyTrades().Invalid().RepairRequiredQueue();
            allTrades.ClickFirst();
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
