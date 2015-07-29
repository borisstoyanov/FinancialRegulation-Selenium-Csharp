using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class MTBusinessataTab_CounterPartiesTests : Test
    {
        bool storeResults = false;
        string searchTerm;
        PO_CounterParties_PopUp cp;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantA_EMIRUser();
            cp = PO_Dashboard.GoToCounterPartiesPopUp();
            cp.CreateNewCounterParty()
                .Create();
            cp.VerifyCounterPartyIsCreated();
            cp.ClosePopUp();
            PO_Dashboard.LogOff();
            login = new PO_LoginPage();
            PO_Dashboard dash = login.LoginWithIEMIRUser2();
            PO_StaticEntitiesAwaitingApproval approvalQueue = dash.GoToStaticEntitiesAwaitingApproval();
            approvalQueue.ApproveStaticEntitie(Test.extRef);
            PO_Dashboard.LogOff();
            login.LoginWithTenantB_EMIRUser01();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTCounterparty_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            cp = PO_Dashboard.GoToCounterPartiesPopUp();
            cp.SearchCP(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
