using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class MTBusinessataTab_ExtRefOutsTests : Test
    {
        bool storeResults = false;
        string searchTerm;
        PO_ExtRefOut_PopUp refOut;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantA_EMIRUser();

            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            refOut = PO_Dashboard.GoToExternalRefOuts();
            PO_ExtRefOut_CreateRefOut createExtRefOut = refOut.ClickCreate();
            createExtRefOut.CreateExtRef("Country", "DTCC");
            refOut.VerifyExtRefOutIsCreated();
            refOut.ClosePopUp();
            PO_UserAccountButton.LogOff();
            login.LoginWithTenantB_EMIRUser01();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTEMIRExtRefOut_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            refOut = PO_Dashboard.GoToExternalRefOuts();
            refOut.SearchForExtRefOut(searchTerm);
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
