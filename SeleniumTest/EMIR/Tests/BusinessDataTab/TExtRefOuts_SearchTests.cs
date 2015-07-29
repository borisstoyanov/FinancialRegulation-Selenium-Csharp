using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TExtRefOuts_SearchTests : Test
    {
        bool storeResults = false;
        string searchTerm;
        PO_ExtRefOut_PopUp refOut;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            refOut = PO_Dashboard.GoToExternalRefOuts();
            PO_ExtRefOut_CreateRefOut createExtRefOut = refOut.ClickCreate();
            createExtRefOut.CreateExtRef("Country", "DTCC");
            refOut.VerifyExtRefOutIsCreated();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefOut_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            refOut.SearchForExtRefOut(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefOut_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            refOut.SearchForExtRefOut(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefOut_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            refOut.SearchForExtRefOut(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefOut_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            refOut.SearchForExtRefOut(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefOut_SearchingEndsWithAsterisk_ByRef()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            refOut.SearchForExtRefOut_ByReference(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefOut_SearchingStartsWithAsterisk_ByRef()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            refOut.SearchForExtRefOut_ByReference(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefOut_SearchingEndsAndStartsWithAsterisk_ByRef()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            refOut.SearchForExtRefOut_ByReference(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefOut_SearchingFullName_ByRef()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            refOut.SearchForExtRefOut_ByReference(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefOut_SearchingByTodayDate()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            refOut.SelectTodayDateAndSearch();
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefOut_SearchType()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            refOut.SetTypeSelectField("Search_EMIRExtRefTypeSearch", "Country");
            refOut.SearchForExtRefOut(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefOut_SearchTradeRepository()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            refOut.SetTypeSelectField("Search_TradeRepositorySearch", "DTCC");
            refOut.SearchForExtRefOut(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefOut_SearchRegulation()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            refOut.SetTypeSelectField("Search_RegulationSearch", "EMIR");
            refOut.SearchForExtRefOut(searchTerm);
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
