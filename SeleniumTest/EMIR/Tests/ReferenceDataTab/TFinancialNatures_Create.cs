using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ReferenceDataTab
{
    [TestClass]
    public class TFinancialNatures_Create : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void FinancialNature_CreateFinancialNatures()
        {
            storeResults = true;
            PO_ReferenceDatasPopUp referenceData = PO_Dashboard.GoToFinancialNaturesPopUp();
            referenceData.CreateNewReferenceData()
                .Create();
            referenceData.VerifyReferenceDataCreated();
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
