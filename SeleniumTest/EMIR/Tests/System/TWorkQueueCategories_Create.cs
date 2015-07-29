using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.System
{
    [TestClass]
    public class TWorkQueueCategories_Create : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void WorkQueueCategory_CreateWorkQCategory()
        {
            storeResults = true;
            PO_WorkQueueCategoriesPopUp workQ = PO_Dashboard.GoToWorkQueueCategoriesPopUp();
            workQ.CreateNewWorkQueueCategories()
                .Create();
            workQ.VerifyWorkQueueCategoriesCreated();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
