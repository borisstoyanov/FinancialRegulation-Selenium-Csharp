using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.SystemTab
{
    [TestClass]
    public class TTenants_EditUsers : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void TenantUsers_EditUsers()
        {
            storeResults = true;
            PO_TenantsPopUp referenceDatas = PO_Dashboard.GoToTenantsPopUp();
            referenceDatas.EditTenantUsers();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
