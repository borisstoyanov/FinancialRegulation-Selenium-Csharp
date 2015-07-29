using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTAutomation.Utils;

namespace MTAutomation.Tests.MultiTenancy
{
    [TestClass]
    public class TTradesNotVisibleForDifferentTenants : Test
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
            PO_UserAccountButton.LogOff();
            login.LoginWithTenantB_EMIRUser01();
        }

        [TestMethod]
        public void TradeFromTenantANotVisibleWithTenantB()
        {
            storeResults = true;
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifiTradeNotReachable(Test.tradeID);
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
