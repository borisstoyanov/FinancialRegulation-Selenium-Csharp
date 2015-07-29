using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.SystemTab
{
    [TestClass]
    public class TWorkQueueCategories_Edit : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void WorkQueueCategory_EditWorkQueueCategories()
        {
            storeResults = true;
            PO_WorkQueueCategoriesPopUp workQ = PO_Dashboard.GoToWorkQueueCategoriesPopUp();
            workQ.CreateNewWorkQueueCategories()
                .Create();
            workQ.VerifyWorkQueueCategoriesCreated();
            workQ.EditWorkQueueCategories()
                .Save();
            workQ.Verify_WorkQueueCategoriesEdited();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
