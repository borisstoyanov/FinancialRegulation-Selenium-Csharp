using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace EmirAutomation.Tests.ActionsUserInterface.ImportTrades
{
    [TestClass]
    public class TMTImportTrade_TREMIR : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportTrade"), TestMethod()]
        public void MTImportTrade_TREMIR_R010()
        {
            storeResults = true;
            ImportTrade.TREMIR_R010_NonDelegated_DTCC();

            Thread.Sleep(3000);
            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();
            ImportTrade.TestSecondTenant();
            Thread.Sleep(3000);
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
