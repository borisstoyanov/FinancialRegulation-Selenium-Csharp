using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.SystemTab
{
    [TestClass]
    public class TEntityLocks_SearchEntityLockType : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            PO_EntityLocksPopUp referenceDatas = PO_Dashboard.GoToEntityLocksPopUp();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EntityLocks_SearchingEntityLockTypeEndsWithAsterisk()
        {
            string testType = "Counterparty";

            storeResults = true;
            searchTerm = testType.Remove(testType.Length - 3) + "*";
            PO_EntityLocksPopUp referenceDatas = new PO_EntityLocksPopUp();
            referenceDatas.SearchEntityLockType(searchTerm);
            Util.CheckIfTextPresented(testType);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EntityLocks_SearchingEntityLockTypeStartsWithAsterisk()
        {
            string testType = "Counterparty";

            storeResults = true;
            searchTerm = "*" + testType.Substring(1);
            PO_EntityLocksPopUp referenceDatas = new PO_EntityLocksPopUp();
            referenceDatas.SearchEntityLockType(searchTerm);
            Util.CheckIfTextPresented(testType);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EntityLocks_SearchingEntityLockTypeEndsAndStartsWithAsterisk()
        {
            string testType = "Counterparty";

            storeResults = true;
            string substracted = "*" + testType.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_EntityLocksPopUp referenceDatas = new PO_EntityLocksPopUp();
            referenceDatas.SearchEntityLockType(searchTerm);
            Util.CheckIfTextPresented(testType);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EntityLocks_SearchingEntityLockTypeFullName()
        {
            string testType = "Counterparty";

            storeResults = true;
            searchTerm = testType;
            PO_EntityLocksPopUp referenceDatas = new PO_EntityLocksPopUp();
            referenceDatas.SearchEntityLockType(searchTerm);
            Util.CheckIfTextPresented(testType);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
