using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.SystemTab
{
    [TestClass]
    public class TMTEntityLocks_SearchEntityLockType : Test
    {
        PO_EntityLocksPopUp entityLocks;

        string countMsg;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithSystemUser();

            entityLocks = PO_Dashboard.GoToEntityLocksPopUp();
            countMsg = entityLocks.GetEntityLockCountMsg();
            entityLocks.Close();

            PO_UserAccountButton.LogOff();
            login.LoginWithSystemUserB();
            entityLocks = PO_Dashboard.GoToEntityLocksPopUp();
        }
        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTEntityLocks_SearchingEntityLockTypeFullName()
        {
            if (string.Compare(countMsg, entityLocks.GetEntityLockCountMsg()) == 0)
            {
                Test.result = "Passed";
            }
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
