using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.BusinessDataTab.ReferenceDataTab
{
    [TestClass]
    public class TValuationSources_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantA_EMIRUser();
            PO_ReferenceDatasPopUp referenceDatas = PO_Dashboard.GoToValuationSourcesPopUp();
            referenceDatas.CreateNewReferenceData()
                .Create();
            referenceDatas.VerifyReferenceDataCreated();
            referenceDatas.Close();
            PO_UserAccountButton.LogOff();
            login.LoginWithTenantB_EMIRUser01();
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTValuationSource_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_ReferenceDatasPopUp referenceDatas = PO_Dashboard.GoToValuationSourcesPopUp();
            referenceDatas.SearchReferenceData(searchTerm);
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
