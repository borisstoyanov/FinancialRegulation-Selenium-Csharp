using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.WorkQ
{
    [TestClass]
    public class TWorkQ_CollateralQueuesAreRendering : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Collateral_Valid_ReadyQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue readyQueue = dash.DailyCollateral().Valid().ReadyQueue();
            readyQueue.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Collateral_Valid_AwaitingParentConfirmationQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue awaiting = dash.DailyCollateral().Valid().AwaitingParentConfirmationQueue();
            awaiting.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Collateral_Valid_ReportedQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue reported = dash.DailyCollateral().Valid().ReportedQueue();
            reported.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Collateral_Valid_EmirConfirmedQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue confirmed = dash.DailyCollateral().Valid().ConfirmedQueue();
            confirmed.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Collateral_InProgress_AwaitingQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue awaiting = dash.DailyCollateral().InProgress().AwaitingQueue();
            awaiting.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Collateral_InProgress_UnmatchedQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue unmached = dash.DailyCollateral().InProgress().UnmachedQueue();
            unmached.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Collateral_InValid_RepairQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue repair = dash.DailyCollateral().Invalid().RepairRequiredQueue();
            repair.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Collateral_InValid_RejectedQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue rejected = dash.DailyCollateral().Invalid().RejectedQueue();
            rejected.CheckResultTableAppears();
            result = "Passed";
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void Dashboard_WorkQ_Collateral_InValid_OtherQ()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            PO_EMIRQueue other = dash.DailyCollateral().Invalid().OtherQueue();
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
