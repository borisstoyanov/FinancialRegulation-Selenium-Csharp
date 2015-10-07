using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace EmirAutomation.Tests
{
    [TestClass]
    public class TEditCollateral : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportTrade.Trade("No");
        }

        [TestCategory("RegressionTesting"), TestMethod()]
        public void EditCollateral_EditCollateral()
        {
            storeResults = true;

            ImportCollateral.TREMIR_R003();
            Thread.Sleep(5000);
            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithRegularUser();

            PO_Dashboard dash = new PO_Dashboard();
            PO_Dashboard.GoTo();

            PO_EMIRQueue allTrades = PO_Dashboard.GoToEMIRConfiguredQueue("Awaiting Collateral");
            allTrades.SearchBySourceTradeID(Test.tradeID + "STI");
            
            // Click on result and edit the record
            allTrades.OpenFirstRecord();
            PO_EditEmirCollateralPage poCollaterals = new PO_EditEmirCollateralPage();
            poCollaterals.EditCollateral("200");

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
