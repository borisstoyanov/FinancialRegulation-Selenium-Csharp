using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.Audit;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.Responses
{
    [TestClass]
    public class TREGIS_Responses : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportPosition.TREMIR_R001_NonDelegated_REGIS();
        }

        [TestCategory("Responses"), TestMethod()]
        public void ResponsesNotVisible_CrossTenant_REGIS()
        {
            storeResults = true;

            Send.SendTrade(TargetSettings_SendTrades.SendRegisTRNewPositions);

            EmirUtils.VerifyEmirConfirmed();

            PO_AuditResponsesPopUp responses = PO_Dashboard.GoToAuditResponses();
            string reference = responses.GetLatestResponse();

            PO_UserAccountButton.LogOff();

            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();

            PO_Dashboard.GoToAuditResponses();

            responses.CheckIfRefernceIsNotVisible(reference);

            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
