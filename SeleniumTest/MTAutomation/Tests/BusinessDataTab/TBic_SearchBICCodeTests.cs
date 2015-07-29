using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomationUtilities.Utils;
using AutomationUtilities.PageObjects.BicPO;
using AutomationUtilities.PageObjects;

namespace MTAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TMTBusinessataTab_BICTests : Test
    {
        bool storeResults = false;
        string searchTerm;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantA_EMIRUser();

            PO_BICPopUp bic = PO_Dashboard.GoToBICPopUp();
            bic.CreateNewBicCode()
                .Create();
            bic.VerifyBicCodeCreated();
            bic.Close();

            PO_UserAccountButton.LogOff();
            login.LoginWithTenantB_EMIRUser01();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTBICCode_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_BICPopUp bic = PO_Dashboard.GoToBICPopUp();
            bic.SearchBicCodeByName(searchTerm);
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
