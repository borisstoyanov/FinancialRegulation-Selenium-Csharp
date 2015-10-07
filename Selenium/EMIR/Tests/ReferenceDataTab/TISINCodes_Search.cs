using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.Maintanance.ReferenceData.ISINCodes;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ReferenceDataTab
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
            Test.LoginAsSystemUser();
            PO_ISINCodes_PopUp isinCode = PO_Dashboard.GoToISINCodesPopUp();
            isinCode.CreateNewISINCode()
                .Create();
            isinCode.VerifyISINCodeCreated();
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void ISINCode_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_ISINCodes_PopUp isinCode = new PO_ISINCodes_PopUp();
            isinCode.SearchISINCode(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void ISINCode_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_ISINCodes_PopUp isinCode = new PO_ISINCodes_PopUp();
            isinCode.SearchISINCode(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void ISINCode_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_ISINCodes_PopUp isinCode = new PO_ISINCodes_PopUp();
            isinCode.SearchISINCode(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void ISINCode_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_ISINCodes_PopUp isinCode = new PO_ISINCodes_PopUp();
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
