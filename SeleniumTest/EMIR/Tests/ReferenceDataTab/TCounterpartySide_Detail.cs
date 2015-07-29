using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ReferenceDataTab
{
    [TestClass]
    public class TCounterpartySides_Detail : Test
    {
        bool storeResults = false;


        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void CounterpartySide_ViewCounterpartySide()
        {
            storeResults = true;
            PO_ReferenceDatasPopUp referenceDatas = PO_Dashboard.GoToCounterpartySidesPopUp();
            referenceDatas.CreateNewReferenceData()
                .Create();
            referenceDatas.VerifyReferenceDataCreated();
            referenceDatas.ViewReferenceDataDetails();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
