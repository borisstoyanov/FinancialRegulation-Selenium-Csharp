using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.SystemTab
{
    [TestClass]
    public class TMTSourceSystems_Search : Test
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

            PO_SourceSystemsPopUp referenceDatas = PO_Dashboard.GoToSourceSystemPopUp();
            referenceDatas.CreateNewSourceSystem()
                .Create();
            referenceDatas.VerifySourceSystemCreated();

            referenceDatas.Close();
            PO_UserAccountButton.LogOff();
            login.LoginWithSystemUserB();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTSourceSystem_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_SourceSystemsPopUp referenceDatas = PO_Dashboard.GoToSourceSystemPopUp();
            referenceDatas.SearchSourceSystem(searchTerm);
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
