using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ActionsUserInterface.ImportColAndVal
{
    [TestClass]
    public class TMTImportVal_GenericXML : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportTrade.Trade("No");
            
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportValuation"), TestMethod()]
        public void MTImportVal_GenXML()
        {
            storeResults = true;
            ImportValuation.GenXML();

            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();
            ImportValuation.TestSecondTenant();
            PO_Dashboard.LogOff();

            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
            Test.MarkTradeAsUsed();
        }
    }
}
