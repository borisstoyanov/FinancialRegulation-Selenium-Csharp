using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TCounterParties_CheckDelegatedFlags : Test
    {
        bool storeResults = false;
        PO_CounterParties_PopUp cp;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Counterparty_CheckDelegatedFlags()
        {
            storeResults = true;
            cp = PO_Dashboard.GoToCounterPartiesPopUp();
            cp.ViewDetails("000TestDelegatedCounterParty");
            Util.WaitForElementVisibleByXPath("//p[contains(text(), 'Delegated Collateral')]", 15);
            Util.WaitForElementVisibleByXPath("//p[contains(text(), 'Delegated Reporting')]", 15);
            Util.WaitForElementVisibleByXPath("//p[contains(text(), 'Delegated Valuation')]", 15);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
