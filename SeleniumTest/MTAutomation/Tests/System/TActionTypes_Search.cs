using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.SystemTab
{
    [TestClass]
    public class TMTSystemActionTypes_Search : Test
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

            PO_ActionTypesPopUp referenceDatas = PO_Dashboard.GoToSystemActionTypesPopUp();
            referenceDatas.CreateNewActionType()
                .Create();
            referenceDatas.VerifyActionTypeCreated();

            referenceDatas.Close();
            PO_UserAccountButton.LogOff();
            login.LoginWithSystemUserB();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTActionType_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_ActionTypesPopUp referenceDatas = PO_Dashboard.GoToSystemActionTypesPopUp();
            referenceDatas.SearchActionType(searchTerm);
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
