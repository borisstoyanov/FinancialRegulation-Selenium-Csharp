using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TExtRefIn_EditExtRefIn : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void TC14459_EMIRExtRefIn_Edit_ChangeSourceSystem()
        {
            storeResults = true;
            PO_ExtRefIn_PopUp manageRefIns = PO_Dashboard.GoToExternalRefIns();
            PO_ExtRefIn_CreateRefIn createExtRefIn = manageRefIns.ClickCreate();
            createExtRefIn.CreateExtRef("Valuation Source", "TREMIR");
            manageRefIns.VerifyExtRefInIsCreated();
            manageRefIns.EditRefIn()
                .SelectField(ExtRefIns.EMIRExtRefIn_EMIRSourceSystem, "LIFFE")
                .Save();
            manageRefIns.VerifyExtRefInIsEdited();
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
