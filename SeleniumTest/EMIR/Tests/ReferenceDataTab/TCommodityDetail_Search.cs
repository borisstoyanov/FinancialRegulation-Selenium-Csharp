using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ReferenceDataTab
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
            Test.LoginAsSystemUser();
            PO_CommodityDetail_PopUp referenceDatas = PO_Dashboard.GoToCommodityDetailsPopUp();
            referenceDatas.CreateNewComDetails()
                .Create();
            referenceDatas.VerifyComDetailCreated();
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRCommodityDetail_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_ReferenceDatasPopUp referenceDatas = new PO_ReferenceDatasPopUp();
            referenceDatas.SearchReferenceData(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRCommodityDetail_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_ReferenceDatasPopUp referenceDatas = new PO_ReferenceDatasPopUp();
            referenceDatas.SearchReferenceData(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRCommodityDetail_SearchingEndsAndStartsWithAsterisk()
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
        public void EMIRCommodityDetail_SearchingFullName()
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
