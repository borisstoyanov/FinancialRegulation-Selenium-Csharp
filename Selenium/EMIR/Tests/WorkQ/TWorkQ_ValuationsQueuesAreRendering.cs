using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationUtilities.Tests.WorkQ
{
    [TestClass]
    public class TDashboard_WorkQ_ValuationsQueuesAreRendering : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Valuations_Valid_ReadyQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue readyQueue = dash.DailyValuations().Valid().ReadyQueue();
            readyQueue.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Valuations_Valid_AwaitingParentConfirmationQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue awaiting = dash.DailyValuations().Valid().AwaitingParentConfirmationQueue();
            awaiting.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Valuations_Valid_ReportedQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue reported = dash.DailyValuations().Valid().ReportedQueue();
            reported.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Valuations_Valid_EmirConfirmedQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue confirmed = dash.DailyValuations().Valid().ConfirmedQueue();
            confirmed.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Valuations_InProgress_AwaitingQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue awaiting = dash.DailyValuations().InProgress().AwaitingQueue();
            awaiting.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Valuations_InProgress_UnmatchedQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue unmached = dash.DailyValuations().InProgress().UnmachedQueue();
            unmached.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Valuations_InValid_RepairQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue repair = dash.DailyValuations().Invalid().RepairRequiredQueue();
            repair.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Valuations_InValid_RejectedQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue rejected = dash.DailyValuations().Invalid().RejectedQueue();
            rejected.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Valuations_InValid_OtherQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue other = dash.DailyValuations().Invalid().OtherQueue();
            other.CheckResultTableAppears();
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
