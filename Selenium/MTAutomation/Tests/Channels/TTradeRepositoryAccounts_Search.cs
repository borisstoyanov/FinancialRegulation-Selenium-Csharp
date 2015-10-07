using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TMTTradeRepositoryAccounts_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithSystemUser();

            PO_TradeRepositoryAccountsPopUp referenceDatas = PO_Dashboard.GoToTradeRepositoryAccountsPopUp();
            referenceDatas.CreateNewTradeRepositoryAccounts()
                .Create();
            referenceDatas.VerifyTradeRepositoryAccountsCreated();

            referenceDatas.Close();
            PO_UserAccountButton.LogOff();
            login.LoginWithSystemUserB();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTTradeRepositoryAccount_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_TradeRepositoryAccountsPopUp referenceDatas = PO_Dashboard.GoToTradeRepositoryAccountsPopUp();
            referenceDatas.SearchTradeRepositoryAccounts(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
