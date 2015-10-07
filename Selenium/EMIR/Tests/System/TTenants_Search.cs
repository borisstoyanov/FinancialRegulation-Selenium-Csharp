using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ReferenceDataTab
{
    [TestClass]
    public class TTenants_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            PO_TenantsPopUp referenceDatas = PO_Dashboard.GoToTenantsPopUp();
            referenceDatas.CreateNewTenant()
                .Create();
            referenceDatas.VerifyTenantCreated();
        }

        [TestCategory("SystemTab"), TestCategory("Maintenance"), TestMethod()]
        public void Tenants_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_TenantsPopUp referenceDatas = new PO_TenantsPopUp();
            referenceDatas.SearchTenants(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("SystemTab"), TestCategory("Maintenance"), TestMethod()]
        public void Tenants_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_TenantsPopUp referenceDatas = new PO_TenantsPopUp();
            referenceDatas.SearchTenants(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("SystemTab"), TestCategory("Maintenance"), TestMethod()]
        public void Tenants_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_TenantsPopUp referenceDatas = new PO_TenantsPopUp();
            referenceDatas.SearchTenants(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("SystemTab"), TestCategory("Maintenance"), TestMethod()]
        public void Tenants_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_TenantsPopUp referenceDatas = new PO_TenantsPopUp();
            referenceDatas.SearchTenants(searchTerm);
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
