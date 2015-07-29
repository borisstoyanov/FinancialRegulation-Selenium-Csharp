using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TCounterParty_CreateCounterparty : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void TC14456_Counterparty_CreateCP()
        {
            storeResults = true;
            PO_CounterParties_PopUp counterParties = PO_Dashboard.GoToCounterPartiesPopUp();
            counterParties.CreateNewCounterParty()
                .Create();
            counterParties.VerifyCounterPartyIsCreated();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
