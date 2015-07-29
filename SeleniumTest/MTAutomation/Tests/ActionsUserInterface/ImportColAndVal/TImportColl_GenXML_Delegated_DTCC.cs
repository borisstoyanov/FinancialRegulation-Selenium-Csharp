using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ActionsUserInterface.ImportColAndVal
{
    [TestClass]
    public class TMTImportColl_GenXML_Delegated_DTCC : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportTrade.TREMIR_R010_Delegated_DTCC();

        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportCollateral"), TestMethod()]
        public void MTImportColl_GenXML_Delegated_DTCC()
        {
            storeResults = true;
            ImportCollateral.GenXML_Delegated();

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
