using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class MTBusinessataTab_ExtRefInTests : Test
    {
        bool storeResults = false;
        string searchTerm;
        PO_ExtRefIn_PopUp refIns;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantA_EMIRUser();
            
            refIns = PO_Dashboard.GoToExternalRefIns();
            PO_ExtRefIn_CreateRefIn createExtRefIn = refIns.ClickCreate();
            createExtRefIn.CreateExtRef("Valuation Source", "TREMIR");
            refIns.VerifyExtRefInIsCreated();
            refIns.ClosePopUp();
            PO_UserAccountButton.LogOff();
            login.LoginWithTenantB_EMIRUser01();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTEMIRExtRefIn_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            refIns = PO_Dashboard.GoToExternalRefIns();
            refIns.SearchForExtRefIn(searchTerm);
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
