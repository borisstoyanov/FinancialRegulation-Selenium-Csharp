using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.SystemTab
{
    [TestClass]
    public class TMTWorkQueueCategories_Search : Test
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

            PO_WorkQueueCategoriesPopUp workQCat = PO_Dashboard.GoToWorkQueueCategoriesPopUp();
            workQCat.CreateNewWorkQueueCategories()
                .Create();
            workQCat.VerifyWorkQueueCategoriesCreated();

            workQCat.Close();
            PO_UserAccountButton.LogOff();
            login.LoginWithSystemUserB();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTWorkQueueCategory_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_WorkQueueCategoriesPopUp workQ = PO_Dashboard.GoToWorkQueueCategoriesPopUp();
            workQ.SearchWorkQueueCategories(searchTerm);
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
