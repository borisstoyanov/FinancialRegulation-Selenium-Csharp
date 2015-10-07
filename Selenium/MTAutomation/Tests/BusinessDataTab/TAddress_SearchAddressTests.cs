using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.BusinessDataTab.BusinessDataTab
{
    [TestClass]
    public class TMTBusinessataTab_AddressTests : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantA_EMIRUser();

            PO_AddessesPopUp addresses = PO_Dashboard.GoToAddressesPopUp();
            addresses.CreateNewAddress()
                .Create();
            addresses.VerifyAddressCreated();
            addresses.Close();

            PO_UserAccountButton.LogOff();
            login.LoginWithTenantB_EMIRUser01();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTAddress__SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_AddessesPopUp address = PO_Dashboard.GoToAddressesPopUp();
            address.SearchAddress(searchTerm);
            Util.CheckIfTextNotPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
