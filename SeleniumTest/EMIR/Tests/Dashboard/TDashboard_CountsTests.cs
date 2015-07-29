using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationUtilities.Tests.Dashboard
{
    [TestClass]
    public class TDashboard_CountsTests : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_VerifyInvalidCountsSum()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            int rejected = dash.DailyTrades()
                .Invalid()
                .GetRejectedCount();
            int repair = dash.DailyTrades()
                .Invalid().GetRepairRequiredCount();
            int other = dash.DailyTrades().Invalid().GetOtherCount();

            Assert.IsTrue(rejected + repair + other == dash.DailyTrades().Invalid().GetTotal());

            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void TC14623_Dashboard_VerifyInProgressCountsSum()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();
            
            int revalidation = dash.DailyTrades()
                .InProgress()
                .GetAwaitingAutoRevalidationCount();
            int cleaningRequired = dash.DailyTrades()
                .InProgress().GetClearingRequiredCount();
            int confirmationRequired = dash.DailyTrades().InProgress().GetConfirmationRequiredCount();

            Assert.IsTrue(revalidation + cleaningRequired + confirmationRequired == dash.DailyTrades().InProgress().GetTotal());

            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_VerifyValidCountsSum()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();

            int ready = dash.DailyTrades()
                .Valid()
                .GetReadyCount();
            int reported = dash.DailyTrades()
                .Valid().GetReported();
            int confirmed = dash.DailyTrades().Valid().GetConfirmed();

            Assert.IsTrue(ready + reported + confirmed == dash.DailyTrades().Valid().GetTotal());

            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestCategory("Test"), TestMethod()]
        public void Dashboard_VerifyTradesSum()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();

            int valid = dash.DailyTrades().Valid().GetTotal();

            int inProgress = dash.DailyTrades().InProgress().GetTotal();
                
            int invalid = dash.DailyTrades().Invalid().GetTotal();

            Assert.IsTrue(valid + inProgress + invalid == dash.DailyTrades().GetTotal());

            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_VerifyCollateralSum()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();

            int valid = dash.DailyCollateral().Valid().GetTotal();

            int inProgress = dash.DailyCollateral().InProgress().GetTotal();

            int invalid = dash.DailyCollateral().Invalid().GetTotal();

            Assert.IsTrue(valid + inProgress + invalid == dash.DailyCollateral().GetTotal());

            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_VerifyCollateralValidCountsSum()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();

            int ready = dash.DailyCollateral().Valid().GetReadyCount();
            int reported = dash.DailyCollateral().Valid().GetReported();
            int confirmed = dash.DailyCollateral().Valid().GetConfirmed();
            int awaiting = dash.DailyCollateral().Valid().GetAwaitingParentConfirmationCount();

            Assert.IsTrue(ready + awaiting + reported + confirmed == dash.DailyCollateral().Valid().GetTotal());

            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_VerifyCollateralInprogressCountsSum()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();

            int awaiting = dash.DailyCollateral().InProgress().GetAwaitingCount();
            int unmatched = dash.DailyCollateral().InProgress().GetUnmatchedCount();

            Assert.IsTrue(awaiting + unmatched == dash.DailyCollateral().InProgress().GetTotal());

            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_VerifyCollateralInvalidCountsSum()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();

            int repair = dash.DailyCollateral().Invalid().GetRepairRequiredCount();
            int rejected = dash.DailyCollateral().Invalid().GetRejectedCount();
            int other = dash.DailyCollateral().Invalid().GetOtherCount();

            Assert.IsTrue(repair + rejected + other == dash.DailyCollateral().Invalid().GetTotal());

            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_VerifyValuationsSum()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();

            int valid = dash.DailyValuations().Valid().GetTotal();

            int inProgress = dash.DailyValuations().InProgress().GetTotal();

            int invalid = dash.DailyValuations().Invalid().GetTotal();

            int total = dash.DailyValuations().GetTotal();

            Assert.IsTrue(valid + inProgress + invalid == total);

            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_VerifyValuationsValidCountsSum()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();

            int ready = dash.DailyValuations()
                .Valid()
                .GetReadyCount();
            int reported = dash.DailyValuations()
                .Valid().GetReported();
            int confirmed = dash.DailyValuations().Valid().GetConfirmed();
            int awaiting = dash.DailyValuations().Valid().GetAwaitingParentConfirmationCount();


            Assert.IsTrue(ready + awaiting + reported + confirmed == dash.DailyValuations().Valid().GetTotal());

            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_VerifyValuationsInprogressCountsSum()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();

            int awaiting = dash.DailyValuations().InProgress().GetAwaitingCount();
            int unmatched = dash.DailyValuations().InProgress().GetUnmatchedCount();

            Assert.IsTrue(awaiting + unmatched == dash.DailyValuations().InProgress().GetTotal());

            Test.result = "Passed";
        }

        [TestCategory("RegressionTesting"), TestCategory("Dashboard"), TestCategory("WorkQs"), TestMethod()]
        public void Dashboard_VerifyValuationsInvalidCountsSum()
        {
            storeResults = true;
            PO_Dashboard dash = new PO_Dashboard();

            int repair = dash.DailyValuations().Invalid().GetRepairRequiredCount();
            int rejected = dash.DailyValuations().Invalid().GetRejectedCount();
            int other = dash.DailyValuations().Invalid().GetOtherCount();

            Assert.IsTrue(repair + rejected + other == dash.DailyValuations().Invalid().GetTotal());

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
