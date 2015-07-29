using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.WorkQ
{
    [TestClass]
    public class TWorkQSearchByUTI : Test
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
        public void WorkQ_SearchByUTI()
        {
            storeResults = true;
            PO_Dashboard.GoTo();
            PO_EMIRQueue allTrades = PO_Dashboard.GoToEMIRConfiguredQueue("EMIR All Trades");
            allTrades.SearchByTradeID(Test.tradeID +"STI");
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
