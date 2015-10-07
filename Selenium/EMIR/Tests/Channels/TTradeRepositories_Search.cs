using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TTradeRepositories_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
            PO_TradeRepositoriesPopUp referenceDatas = PO_Dashboard.GoToTradeRepositoriesPopUp();
            referenceDatas.CreateNewTradeRepositories()
                .Create();
            referenceDatas.VerifyTradeRepositoriesCreated();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void TradeRepository_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_TradeRepositoriesPopUp referenceDatas = new PO_TradeRepositoriesPopUp();
            referenceDatas.SearchTradeRepositories(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void TradeRepository_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_TradeRepositoriesPopUp referenceDatas = new PO_TradeRepositoriesPopUp();
            referenceDatas.SearchTradeRepositories(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void TradeRepository_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_TradeRepositoriesPopUp referenceDatas = new PO_TradeRepositoriesPopUp();
            referenceDatas.SearchTradeRepositories(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void TradeRepository_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_TradeRepositoriesPopUp referenceDatas = new PO_TradeRepositoriesPopUp();
            referenceDatas.SearchTradeRepositories(searchTerm);
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
