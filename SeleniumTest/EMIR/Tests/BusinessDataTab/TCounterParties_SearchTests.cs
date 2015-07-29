using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TCounterParties_SearchTests : Test
    {
        bool storeResults = false;
        string searchTerm;
        PO_CounterParties_PopUp cp;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
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
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Counterparty_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            cp = new PO_CounterParties_PopUp();
            cp.SearchCP(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Counterparty_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            cp = new PO_CounterParties_PopUp();
            cp.SearchCP(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Counterparty_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            cp = new PO_CounterParties_PopUp();
            cp.SearchCP(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Counterparty_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            cp = new PO_CounterParties_PopUp();
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
