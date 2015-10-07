using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.Maintanance.BusinessData.CounterParties;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TCounterParties_CheckIntragroupsNotPresent : Test
    {
        bool storeResults = false;
        PO_CounterParties_PopUp cp;

        [TestInitialize]
        public void SetUp()
        {
            
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Counterparty_IntragroupNotPresent()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
            cp = PO_Dashboard.GoToCounterPartiesPopUp();
            cp.CreateNewCounterParty()
                .Create();
            cp.VerifyCounterPartyIsCreated();
            cp.ClosePopUp();
            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            PO_Dashboard dash = login.LoginWithIEMIRUser2();
            PO_StaticEntitiesAwaitingApproval approvalQueue = dash.GoToStaticEntitiesAwaitingApproval();
            approvalQueue.ApproveStaticEntitie(Test.extRef);
            PO_Dashboard.LogOff();
            login.LoginWithRegularUser();
            PO_Dashboard.GoToCounterPartiesPopUp();

            PO_CounterParty_EditCP edit = cp.EditCounterParty();
            edit.VerifyIntragroupNotPresent();

        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
