using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.Audit;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.SystemTab
{
    [TestClass]
    public class TMTOutboundAudit_SearchTests : Test
    {
        PO_AuditOutboundPopUp operationsPopUp;

        bool storeResults = false;
        string countMsg;

        [TestInitialize]
        public void SetUp()
        {
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantA_EMIRUser();
            Test.SetTestName(TestContext);

            operationsPopUp = PO_Dashboard.GoToAuditOutbound();
            countMsg = operationsPopUp.GetAuditsCountMsg();

            PO_UserAccountButton.LogOff();
            login.LoginWithTenantB_EMIRUser01();
            operationsPopUp = PO_Dashboard.GoToAuditOutbound();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void TMTOutboundAudit_CountResponse()
        {
            if (string.Compare(countMsg, operationsPopUp.GetAuditsCountMsg()) == 0)
            {
                Test.result = "Passed";
            }
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
