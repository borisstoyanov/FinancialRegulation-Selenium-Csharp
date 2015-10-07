using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TCounterParties_SearchByBIC : Test
    {
        bool storeResults = false;
        string searchTerm;
        PO_CounterParties_PopUp cp;
        string bic;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            bic = EmirUtils.CreateBicCode();
            cp = PO_Dashboard.GoToCounterPartiesPopUp();
            cp.CreateNewCounterParty()
                .SetBicCode(bic)
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
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Counterparty_SearchByBIC()
        {
            storeResults = true;
            searchTerm =bic.Remove(bic.Length - 2);
            cp = new PO_CounterParties_PopUp();
            cp.SearchCPByBic(searchTerm);
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
