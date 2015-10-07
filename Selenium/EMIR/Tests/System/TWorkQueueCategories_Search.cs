using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.SystemTab
{
    [TestClass]
    public class TWorkQueueCategories_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            PO_WorkQueueCategoriesPopUp workQCat = PO_Dashboard.GoToWorkQueueCategoriesPopUp();
            workQCat.CreateNewWorkQueueCategories()
                .Create();
            workQCat.VerifyWorkQueueCategoriesCreated();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void WorkQueueCategory_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_WorkQueueCategoriesPopUp workQ = new PO_WorkQueueCategoriesPopUp();
            workQ.SearchWorkQueueCategories(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void WorkQueueCategory_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_WorkQueueCategoriesPopUp workQ = new PO_WorkQueueCategoriesPopUp();
            workQ.SearchWorkQueueCategories(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void WorkQueueCategory_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_WorkQueueCategoriesPopUp workQ = new PO_WorkQueueCategoriesPopUp();
            workQ.SearchWorkQueueCategories(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void WorkQueueCategory_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_WorkQueueCategoriesPopUp workQ = new PO_WorkQueueCategoriesPopUp();
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
