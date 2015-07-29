using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ReferenceDataTab
{
    [TestClass]
    public class TFinancialNatures_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            PO_ReferenceDatasPopUp referenceDatas = PO_Dashboard.GoToFinancialNaturesPopUp();
            referenceDatas.CreateNewReferenceData()
                .Create();
            referenceDatas.VerifyReferenceDataCreated();
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void FinancialNature_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_ReferenceDatasPopUp referenceDatas = new PO_ReferenceDatasPopUp();
            referenceDatas.SearchReferenceData(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void FinancialNature_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_ReferenceDatasPopUp referenceDatas = new PO_ReferenceDatasPopUp();
            referenceDatas.SearchReferenceData(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void FinancialNature_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_ReferenceDatasPopUp referenceDatas = new PO_ReferenceDatasPopUp();
            referenceDatas.SearchReferenceData(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void FinancialNature_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_ReferenceDatasPopUp referenceDatas = new PO_ReferenceDatasPopUp();
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
