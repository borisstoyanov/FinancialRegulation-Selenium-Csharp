using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests
{
    [TestClass]
    public class TSourcesResponse : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("RegressionTesting"), TestMethod()]
        public void Sources_ViewResponse()
        {
            storeResults = true;
            PO_ResponseSourcesPopUp sources = PO_ResponseSourcesPopUp.GoToResponseSources();
            string searchTerm = PO_ResponseSourcesPopUp.GetFirstSource();
            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();
            PO_ResponseSourcesPopUp.GoToResponseSources();
            PO_ResponseSourcesPopUp.SearchForSource(searchTerm);
            PO_ResponseSourcesPopUp.CheckNoEntries();
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
