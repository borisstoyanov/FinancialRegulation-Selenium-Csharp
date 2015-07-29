using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ActionsUserInterface.ImportTrades
{
    [TestClass]
    public class TMTImportTrade_TREMIR_R010_NonDelegated_Regis : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportTrade"), TestMethod()]
        public void MTImportTrade_TREMIR_R010_NonDelegated_REGIS()
        {
            storeResults = true;
            ImportTrade.TREMIR_R010_NonDelegated_REGIS();

            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();
            ImportTrade.TestSecondTenant();
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
