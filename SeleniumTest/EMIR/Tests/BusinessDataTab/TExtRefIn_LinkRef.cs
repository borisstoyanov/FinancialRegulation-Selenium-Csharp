using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.ExtRefInOut;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationUtilities.Tests.BusinessDataTab
{
    [TestClass]
    public class TExtRefIn_LinkRef : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            PO_ExtRefIn_PopUp createRefIns = PO_Dashboard.GoToExternalRefIns();
            PO_ExtRefIn_CreateRefIn createExtRefIn = createRefIns.ClickCreate();
            createExtRefIn.CreateExtRef("Valuation Source", "TREMIR");
            createRefIns.VerifyExtRefInIsCreated();
            createRefIns.ClosePopUp();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestCategory("Nightly"), TestMethod()]
        public void TC14460_EMIRExtRefIn_LinkRef()
        {
            storeResults = true;
            PO_ManageExtRefIn manageRefIn = PO_Dashboard.GoToManageRefIns();
            manageRefIn.LinkRefIn("Valuation Source", "In House");
            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            PO_Dashboard dash = login.LoginWithIEMIRUser2();
            PO_StaticMappingsAwaitingApproval approvalQueue = dash.GoToStaticMappingsAwaitingApproval();
            approvalQueue.ApproveStaticMapping(Test.extRef);
            PO_Dashboard.LogOff();
            login.LoginWithRegularUser();
            PO_ExtRefIn_PopUp createRefIns = PO_Dashboard.GoToExternalRefIns();
            createRefIns.SetTypeSelectField("Search_EMIRExtRefTypeSearch", "Valuation Source");
            createRefIns.SearchForExtRefIn(Test.extRef);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
