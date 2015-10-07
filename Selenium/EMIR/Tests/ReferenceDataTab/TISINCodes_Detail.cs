using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.Maintanance.ReferenceData.ISINCodes;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ReferenceDataTab
{
    [TestClass]
    public class TISINCodes_Detail : Test
    {
        bool storeResults = false;


        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void ISINCode_ViewISINCode()
        {
            storeResults = true;
            PO_ISINCodes_PopUp isinCode = PO_Dashboard.GoToISINCodesPopUp();
            isinCode.CreateNewISINCode()
                .Create();
            isinCode.VerifyISINCodeCreated();
            isinCode.ViewISINCodeDetails();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
