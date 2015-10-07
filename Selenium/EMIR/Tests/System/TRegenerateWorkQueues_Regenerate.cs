using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.SystemTab
{
    [TestClass]
    public class TRegenerateWorkQueues_Regenerate : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void RegenerateWorkQueues_RegenerateWorkQueue()
        {
            storeResults = true;
            PO_RegenerateWorkQueuesPopUp referenceData = PO_Dashboard.GoToRegenerateWorkQueuesPopUp();
            referenceData.RegenerateWorkQueues();
            referenceData.VerifyWorkQueueGenerated();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
