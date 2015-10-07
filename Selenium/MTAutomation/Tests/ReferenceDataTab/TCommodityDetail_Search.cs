using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.BusinessDataTab.ReferenceDataTab
{
    [TestClass]
    public class TCommodityDetails_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantA_EMIRUser();
            PO_CommodityDetail_PopUp referenceDatas = PO_Dashboard.GoToCommodityDetailsPopUp();
            referenceDatas.CreateNewComDetails()
                .Create();
            referenceDatas.VerifyComDetailCreated();
            referenceDatas.Close();
            PO_UserAccountButton.LogOff();
            login.LoginWithTenantB_EMIRUser01();
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTEMIRCommodityDetail_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_CommodityDetail_PopUp referenceDatas = PO_Dashboard.GoToCommodityDetailsPopUp();
            referenceDatas.SearchCommodityDetail(searchTerm);
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
