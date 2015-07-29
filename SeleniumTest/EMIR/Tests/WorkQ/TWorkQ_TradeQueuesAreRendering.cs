using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.WorkQ
{
    [TestClass]
    public class TDashboard_WorkQ_TradeQueuesAreRendering:Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_VerifyReadyQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue readyQueue = dash.DailyTrades().Valid().ReadyQueue();
            readyQueue.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_VerifyReportedQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue reported = dash.DailyTrades().Valid().ReportedQueue();
            reported.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_VerifyEmirConfirmedQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue confirmed = dash.DailyTrades().Valid().ConfirmedQueue();
            confirmed.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_VerifyRejectedQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue rejectedQueue = dash.DailyTrades().Invalid().RejectedQueue();
            rejectedQueue.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_VerifyRepairRequiredQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue repair = dash.DailyTrades().Invalid().RepairRequiredQueue();
            repair.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_VerifyOtherQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue other = dash.DailyTrades().Invalid().OtherQueue();
            other.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_VerifyConfirmationRequiredQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue confirmation = dash.DailyTrades().InProgress().ConfirmationRequiredQueue();
            confirmation.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_VerifyClearingRequiredQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue clearing = dash.DailyTrades().InProgress().ClearingRequiredQueue();
            clearing.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_VerifyAwaitingAutoReValidationQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue awaiting = dash.DailyTrades().InProgress().AwaitingAutoRevalidationQueue();
            awaiting.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
            Test.MarkTradeAsUsed();
        }
    }
}
