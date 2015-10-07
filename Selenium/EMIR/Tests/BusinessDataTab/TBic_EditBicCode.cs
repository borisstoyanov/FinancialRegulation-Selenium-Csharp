using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.BicPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TBic_EditBicCode: Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void BICCode_EditBIC()
        {
            storeResults = true;
            PO_BICPopUp bic = PO_Dashboard.GoToBICPopUp();
            bic.CreateNewBicCode()
                .Create();
            bic.VerifyBicCodeCreated();
            bic.EditBicCode()
                .SetBicCideField(BicFieldIDs.BICCode_BICType, "BicType")
                .Save();
            bic.VerifyBicCodeEdited();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
