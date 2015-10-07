using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ReferenceDataTab
{
    [TestClass]
    public class TLifecycleEvents_Create : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void LifecycleEvent_CreateLifecycleEvents()
        {
            storeResults = true;
            PO_ReferenceDatasPopUp referenceData = PO_Dashboard.GoToLifecycleEventsPopUp();
            referenceData.CreateNewReferenceData()
                .Create();
            referenceData.VerifyReferenceDataCreated();
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
