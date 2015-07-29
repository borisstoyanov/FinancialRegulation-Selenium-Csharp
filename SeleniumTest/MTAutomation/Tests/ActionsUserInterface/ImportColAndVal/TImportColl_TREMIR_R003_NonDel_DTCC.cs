using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ActionsUserInterface.ImportColAndVal
{
    [TestClass]
    public class TMTImportColl_TREMIR_R003_NonDel_DTCC : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportTrade.TREMIR_R010_NonDelegated_DTCC();
           
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportCollateral"), TestMethod()]
        public void MTImportColl_TREMIR_R003_NonDelegated_DTCC()
        {
            storeResults = true;
            ImportCollateral.GenXML_NonDelegated();

            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();
            ImportCollateral.TestSecondTenant();
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
