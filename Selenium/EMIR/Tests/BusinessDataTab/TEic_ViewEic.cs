using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.Maintanance.BusinessData.EicCodes;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TEic_ViewEic : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();            
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EICCode_ViewEIC()
        {
            storeResults = true;
            PO_EICPopUp eic = PO_Dashboard.GoToEICPopUp();
            eic.CreateNewEicCode()
                .CreateEIC("Delivery Zone (Y-code)")
                .Create();
            eic.VerifyEicCodeCreated();
            eic.ViewEicCodeDetails();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
