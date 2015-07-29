using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.SystemTab
{
    [TestClass]
    public class TSystemActionTypes_Edit : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void ActionType_EditActionType()
        {
            storeResults = true;
            PO_ActionTypesPopUp referenceDatas = PO_Dashboard.GoToSystemActionTypesPopUp();
            referenceDatas.CreateNewActionType()
                .Create();
            referenceDatas.VerifyActionTypeCreated();
            referenceDatas.EditActionType()
                .Save();
            referenceDatas.VerifyActionTypeEdited();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
