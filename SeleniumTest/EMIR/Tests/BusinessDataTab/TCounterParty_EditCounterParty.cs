using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TCounterParty_EditCounterParty : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void TC14457_Counterparty_EditCP_SetExternalID()
        {
            storeResults = true;
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            PO_CounterParties_PopUp counterParties = PO_Dashboard.GoToCounterPartiesPopUp();
            counterParties.CreateNewCounterParty().Create();
            counterParties.VerifyCounterPartyIsCreated();
            counterParties.ClosePopUp();
            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            PO_Dashboard dash = login.LoginWithIEMIRUser2();
            PO_StaticEntitiesAwaitingApproval approvalQueue = dash.GoToStaticEntitiesAwaitingApproval();
            approvalQueue.ApproveStaticEntitie(Test.extRef);
            PO_Dashboard.LogOff();
            login.LoginWithRegularUser();
            PO_Dashboard.GoToCounterPartiesPopUp();
            counterParties.EditCounterParty()
                .SetCounterPartyInputField(CounterPartyInputFields.Counterparty_ExternalId, Util.GetRandomID())
                .Save();
            counterParties.VerifyCounterPartyIsCreated();
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Counterparty_EditCPNonGenericFields_GlobalTenant()
        {
            storeResults = true;
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
            PO_CounterParties_PopUp counterParties = PO_Dashboard.GoToCounterPartiesPopUp();
            counterParties.CreateNewCounterParty().Create();
            counterParties.VerifyCounterPartyIsCreated();

            counterParties.ClosePopUp();
            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            PO_Dashboard dash = login.LoginWithVladimirChernev();
            PO_StaticEntitiesAwaitingApproval approvalQueue = dash.GoToStaticEntitiesAwaitingApproval();
            approvalQueue.ApproveStaticEntitie(Test.extRef);
            PO_Dashboard.LogOff();

            login.LoginWithSystemUser();
            PO_Dashboard.GoToCounterPartiesPopUp();
            counterParties.EditCounterParty()
                .SetCounterPartyInputField(CounterPartySelectFields.Counterparty_DelegatedValuation, "Yes")
                .Save();
            counterParties.VerifyCounterPartyIsCreated();
            
            counterParties.ClosePopUp();
            PO_Dashboard.LogOff();
            login.LoginWithVladimirChernev();
            dash.GoToStaticEntitiesAwaitingApproval();
            approvalQueue.ApproveStaticEntitie(Test.extRef);
            PO_Dashboard.LogOff();
            
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
