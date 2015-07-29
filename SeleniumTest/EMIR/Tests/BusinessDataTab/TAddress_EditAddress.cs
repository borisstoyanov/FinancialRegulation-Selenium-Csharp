using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TAddress_EditAddress:Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Address_EditAddress()
        {
            storeResults = true;
            PO_AddessesPopUp addresses = PO_Dashboard.GoToAddressesPopUp();
            addresses.CreateNewAddress()
                .Create();
            addresses.VerifyAddressCreated();
            addresses.EditAddress()
                .SetAddressField(AddressesFieldIDs.Address_Line3, Util.GetRandomID())
                .Save();
            addresses.VerifyAddressEdited();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
