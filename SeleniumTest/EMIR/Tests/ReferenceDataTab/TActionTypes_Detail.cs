using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ReferenceDataTab
{
    [TestClass]
    public class TActionTypes_Detail : Test
    {
        bool storeResults = false;


        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void ActionType_ViewActionType()
        {
            storeResults = true;
            PO_ReferenceDatasPopUp referenceDatas = PO_Dashboard.GoToActionTypesPopUp();
            referenceDatas.CreateNewReferenceData()
                .Create();
            referenceDatas.VerifyReferenceDataCreated();
            referenceDatas.ViewReferenceDataDetails();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
