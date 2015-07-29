using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.ReferenceData.InitiatorAggressor;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ReferenceDataTab
{
    [TestClass]
    public class TInitiatorAggressor_Edit : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void InitiatorAggressor_EditInitiatorAggressor()
        {
            storeResults = true;
            PO_InitiatorAggressorPopUp referenceData = PO_Dashboard.GoToInitiatorAggressorPopUp();
            referenceData.CreateNewReferenceData()
                .Create();
            referenceData.VerifyReferenceDataCreated();

            var newName = "TA" + Util.GetRandomID();

            referenceData.EditReferenceData()
                .SetInitiatorAggressorField(ReferenceDataFieldIDs.Item_Name, newName)
                .SetInitiatorAggressorField(ReferenceDataFieldIDs.Item_Fixed_Name, newName)
                .Save();
            referenceData.VerifyReferenceDataEdited();
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
