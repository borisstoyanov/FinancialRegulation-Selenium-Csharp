using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.Maintanance.ReferenceData.ISINCodes;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.BusinessDataTab.ReferenceDataTab
{
    [TestClass]
    public class TISINCodes_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantA_EMIRUser();
            PO_ISINCodes_PopUp isinCode = PO_Dashboard.GoToISINCodesPopUp();
            isinCode.CreateNewISINCode()
                .Create();
            isinCode.VerifyISINCodeCreated();
            isinCode.Close();
            PO_UserAccountButton.LogOff();
            login.LoginWithTenantB_EMIRUser01();
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTISINCode_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_ISINCodes_PopUp isinCode = PO_Dashboard.GoToISINCodesPopUp();
            isinCode.SearchISINCode(searchTerm);
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
