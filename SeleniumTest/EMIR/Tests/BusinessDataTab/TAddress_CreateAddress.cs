using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TAddress_CreateAddress:Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Address_CreateAddress()
        {
            storeResults = true;
            PO_AddessesPopUp addresses = PO_Dashboard.GoToAddressesPopUp();
            addresses.CreateNewAddress()
                .Create();
            addresses.VerifyAddressCreated();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
