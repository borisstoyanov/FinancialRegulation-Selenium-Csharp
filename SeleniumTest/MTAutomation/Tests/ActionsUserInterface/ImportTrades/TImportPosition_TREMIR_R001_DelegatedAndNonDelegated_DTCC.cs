using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ActionsUserInterface.ImportTrades
{
    [TestClass]
    public class TMTImportPosition_TREMIR_R001_DelegatedAndNonDelegated_DTCC : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportPosition"), TestMethod()]
        public void MTImportPosition_TREMIR_R001_Delegated_DTCC()
        {
            storeResults = true;
            ImportPosition.TREMIR_R001_Delegated_DTCC();

            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();
            ImportPosition.TestSecondTenant();
            PO_Dashboard.LogOff();

            Test.result = "Passed";
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportPosition"), TestMethod()]
        public void MTImportPosition_TREMIR_R001_NonDelegated_DTCC()
        {
            storeResults = true;
            ImportPosition.TREMIR_R001_NonDelegated_DTCC();

            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();
            ImportPosition.TestSecondTenant();
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
