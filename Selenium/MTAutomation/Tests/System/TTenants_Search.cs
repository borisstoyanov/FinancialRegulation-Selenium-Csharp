using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.SystemTab
{
    [TestClass]
    public class TMTTenants_Search : Test
    {
        PO_TenantsPopUp tenentspopup;

        string countMsg;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithSystemUser();

            tenentspopup = PO_Dashboard.GoToTenantsPopUp();
            countMsg = tenentspopup.GetTenantsCountMsg();
            tenentspopup.Close();

            PO_UserAccountButton.LogOff();
            login.LoginWithSystemUserB();
            tenentspopup = PO_Dashboard.GoToTenantsPopUp();
        }

        [TestCategory("SystemTab"), TestCategory("Maintenance"), TestMethod()]
        public void MTTenants_SearchingFullName()
        {
            if (string.Compare(countMsg, tenentspopup.GetTenantsCountMsg()) == 0)
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
