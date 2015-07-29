using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.WorkQ
{
    [TestClass]
    public class TWorkQSearchByEmirReference : Test
    {
        bool storeResults = false;
        
        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportTrade.Trade("No");
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void WorkQ_SearchByEmirReference()
        {
            storeResults = true;

            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue readyQueue = dash.DailyTrades().Valid().ReadyQueue();
            readyQueue.GetEmirReference(Test.tradeID + "STI");
            readyQueue.SearchByEmirReference(Test.TransactionReference);
            PO_Dashboard.GoTo();
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
