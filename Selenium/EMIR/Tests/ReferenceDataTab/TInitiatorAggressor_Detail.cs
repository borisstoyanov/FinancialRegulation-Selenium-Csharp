using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.ReferenceData.InitiatorAggressor;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ReferenceDataTab
{
    [TestClass]
    public class TInitiatorAggressor_Detail : Test
    {
        bool storeResults = false;


        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void InitiatorAggressor_ViewValuationType()
        {
            storeResults = true;
            PO_InitiatorAggressorPopUp referenceData = PO_Dashboard.GoToInitiatorAggressorPopUp();
            referenceData.CreateNewReferenceData()
                .Create();
            referenceData.VerifyReferenceDataCreated();
            referenceData.ViewReferenceDataDetails();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
