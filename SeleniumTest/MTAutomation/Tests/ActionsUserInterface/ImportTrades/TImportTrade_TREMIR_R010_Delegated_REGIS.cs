using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace EmirAutomation.Tests.ActionsUserInterface.ImportTrades
{
    [TestClass]
    public class TMTImportTrade_TREMIR_R010_Delegated_REGIS : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportTrade"), TestMethod()]
        public void MTImportTrade_TREMIR_R010_Delegated_REGIS()
        {
            storeResults = true;
            ImportTrade.TREMIR_R010_Delegated_REGIS();

            PO_Dashboard.LogOff();
            Thread.Sleep(3000);
            PO_LoginPage login = new PO_LoginPage();
            Thread.Sleep(3000);
            login.LoginWithTenantB_EMIRUser01();
            Thread.Sleep(3000);
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
