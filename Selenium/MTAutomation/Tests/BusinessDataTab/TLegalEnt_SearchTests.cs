using AutomationUtilities.PageObjects.LegalEntities;
using AutomationUtilities.PageObjects.BicPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomationUtilities.PageObjects;

namespace MTAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class MTBusinessataTab_LegalEntTests : Test
    {
        bool storeResults = false;
        string searchTerm;
        PO_LegalEntities legEnt;
        string bicCode;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantA_EMIRUser();

            bicCode = EmirUtils.CreateBicCode();
            legEnt = PO_Dashboard.GoToLegalEntities();
            legEnt.CreateLegalEntity(bicCode)
                .Save();
            legEnt.VerifyLegalEntityCreated();
            legEnt.Close();

            PO_UserAccountButton.LogOff();
            login.LoginWithTenantB_EMIRUser01();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTLegalEntity_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            legEnt = PO_Dashboard.GoToLegalEntities();
            legEnt.SearchForLegalEntity(searchTerm);
            Util.CheckIfTextNotPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
