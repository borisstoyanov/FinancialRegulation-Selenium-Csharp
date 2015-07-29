using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.ActionsButton.Manage;
using AutomationUtilities.PageObjects.ExtRefInOut;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{   [TestClass]
    public class TExtRefIn_PromoteRefIn : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            PO_LoginPage login = new PO_LoginPage();
            PO_Dashboard dash = login.LoginWithTenantB_EMIRUser01(); 
            PO_ExtRefIn_PopUp createRefIns = PO_Dashboard.GoToExternalRefIns();
            PO_ExtRefIn_CreateRefIn createExtRefIn = createRefIns.ClickCreate();
            createExtRefIn.CreateExtRef("Valuation Source", "TREMIR");
            createRefIns.VerifyExtRefInIsCreated();
            createRefIns.ClosePopUp();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestCategory("Nightly"), TestMethod()]
        public void EMIRExtRefIn_Promote()
        {
            storeResults = true;
            PO_ManageExtRefIn manageRefIn = PO_Dashboard.GoToManageRefIns();
            manageRefIn.LinkRefIn("Valuation Source", "In House");
            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            PO_Dashboard dash = login.LoginWithTenantB_EMIRUser02();
            PO_StaticMappingsAwaitingApproval approvalQueue = dash.GoToStaticMappingsAwaitingApproval();
            approvalQueue.ApproveStaticMapping(Test.extRef);
            PO_Dashboard.LogOff();
            login.LoginWithSystemUser();
            PO_ExtRefIns_Promote promote = PO_Dashboard.GoToExternalRefInsPromote();
            promote.PromoteExtRefIn("AutomationTenant_B", "Valuation Source", Test.extRef);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
