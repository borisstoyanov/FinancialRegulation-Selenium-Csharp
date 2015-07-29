using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.Audit;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.SystemTab
{
    [TestClass]
    public class TMTTradeAudit_SearchTests : Test
    {
        PO_AuditTradePopUp operationsPopUp;

        bool storeResults = false;
        string countMsg;

        [TestInitialize]
        public void SetUp()
        {
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantA_EMIRUser();
            Test.SetTestName(TestContext);

            operationsPopUp = PO_Dashboard.GoToAuditTrade();
            countMsg = operationsPopUp.GetAuditsCountMsg();

            PO_UserAccountButton.LogOff();
            login.LoginWithTenantB_EMIRUser01();
            operationsPopUp = PO_Dashboard.GoToAuditTrade();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void TMTTradeAudit_CountResponse()
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
