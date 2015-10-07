using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.System
{
    [TestClass]
    public class TTenants_ViewDelegatedOptions : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Tenant_ViewDelegatedOptions()
        {
            storeResults = true;
            PO_TenantsPopUp referenceDatas = PO_Dashboard.GoToTenantsPopUp();
            referenceDatas.CheckDelegationFlags();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
