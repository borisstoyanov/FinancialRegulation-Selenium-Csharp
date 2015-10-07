using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests
{
    [TestClass]
    public class TSourcesInbound : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("RegressionTesting"), TestMethod()]
        public void Sources_ViewInbound()
        {
            storeResults = true;
            PO_InboundSourcesPopUp sources = PO_InboundSourcesPopUp.GoToInboundSources();
            string searchTerm = PO_InboundSourcesPopUp.GetFirstSource();
            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();
            PO_InboundSourcesPopUp.GoToInboundSources();
            PO_InboundSourcesPopUp.SearchForSource(searchTerm);
            PO_InboundSourcesPopUp.CheckNoEntries();
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
