using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace EmirAutomation.Tests.ActionsUserInterface.ImportColAndVal
{
    [TestClass]
    public class TMTImportColl_GenericXML_ByPortfolioCode : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportTrade.Trade("Yes");
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportCollateral"), TestMethod()]
        public void MTImportColl_GenXML_ByPortfolioCode()
        {
            storeResults = true;
            ImportCollateral.GenXML_ByPortfolioCode();

            Thread.Sleep(3000);
            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();
            ImportCollateral.TestSecondTenant();
            Thread.Sleep(3000);
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
