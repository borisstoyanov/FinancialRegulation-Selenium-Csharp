using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TExtRefIn_SearchTests : Test
    {
        bool storeResults = false;
        string searchTerm;
        PO_ExtRefIn_PopUp refIns;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            refIns = PO_Dashboard.GoToExternalRefIns();
            PO_ExtRefIn_CreateRefIn createExtRefIn = refIns.ClickCreate();
            createExtRefIn.CreateExtRef("Valuation Source", "TREMIR");
            refIns.VerifyExtRefInIsCreated();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefIn_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            refIns.SearchForExtRefIn(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }
        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefIn_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            refIns.SearchForExtRefIn(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefIn_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            refIns.SearchForExtRefIn(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefIn_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            refIns.SearchForExtRefIn(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefIn_SearchingType()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            refIns.SetTypeSelectField("Search_EMIRExtRefTypeSearch","Valuation Source");
            refIns.SearchForExtRefIn(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefIn_SearchingSourceSystem()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            refIns.SetTypeSelectField("Search_EMIRSourceSystemSearch", "TREMIR");
            refIns.SearchForExtRefIn(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefIn_SearchingEndsWithAsterisk_ByRef()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            refIns.SearchForExtRefIn_ByReference(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefIn_SearchingStartsWithAsterisk_ByRef()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            refIns.SearchForExtRefIn_ByReference(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefIn_SearchingEndsAndStartsWithAsterisk_ByRef()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            refIns.SearchForExtRefIn_ByReference(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefIn_SearchingFullName_ByRef()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            refIns.SearchForExtRefIn_ByReference(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefIn_SearchingByTodayDate()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            refIns.SelectTodayDateAndSearch();
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
