using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests
{
    [TestClass]
    public class TSourcesOutbound : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("RegressionTesting"), TestMethod()]
        public void Sources_ViewOutbound()
        {
            storeResults = true;
            PO_OutboundSourcesPopUp sources = PO_OutboundSourcesPopUp.GoToOutboundSources();
            string searchTerm = PO_OutboundSourcesPopUp.GetFirstSource();
            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();
            PO_OutboundSourcesPopUp.GoToOutboundSources();
            PO_OutboundSourcesPopUp.SearchForSource(searchTerm);
            PO_OutboundSourcesPopUp.CheckNoEntries();
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
