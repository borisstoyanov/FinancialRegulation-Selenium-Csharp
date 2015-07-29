using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTAutomation.Utils;

namespace MTAutomation.Tests
{
    [TestClass]
    public class TTradesNotVisibleForDifferentRegulations : Test
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
            login.LoginWithTenantA_REMITUser();
        }

        [TestMethod]
        public void TradesNotVisibleForDifferentRegulations()
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
