using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTAutomation.Utils;
using System.Threading;

namespace MTAutomation.Tests
{
    [TestClass]
    public class TCollateralNotVisisible : Test
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
            searchTerm = MTUtils.ImportTrade("No");
            MTUtils.ImportCollateral();
            PO_UserAccountButton.LogOff();
            login.LoginWithTenantB_EMIRUser01();
        }

        [TestCategory("RegressionTesting"), TestMethod()]
        public void CollateralNotVisisible_CollateralNotVisisible()
        {
            storeResults = true;
            
            PO_Dashboard dash = new PO_Dashboard();
            PO_Dashboard.GoTo();

            PO_EMIRQueue allTrades = PO_Dashboard.GoToEMIRConfiguredQueue("Awaiting Collateral");
            allTrades.SearchBySourceTradeIDRecordNotFound(Test.tradeID + "STI");

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
