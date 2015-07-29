using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.SystemTab
{
    [TestClass]
    public class TSourceSystems_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
            PO_SourceSystemsPopUp referenceDatas = PO_Dashboard.GoToSourceSystemPopUp();
            referenceDatas.CreateNewSourceSystem()
                .Create();
            referenceDatas.VerifySourceSystemCreated();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void SourceSystem_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_SourceSystemsPopUp referenceDatas = new PO_SourceSystemsPopUp();
            referenceDatas.SearchSourceSystem(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void SourceSystem_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_SourceSystemsPopUp referenceDatas = new PO_SourceSystemsPopUp();
            referenceDatas.SearchSourceSystem(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void SourceSystem_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_SourceSystemsPopUp referenceDatas = new PO_SourceSystemsPopUp();
            referenceDatas.SearchSourceSystem(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void SourceSystem_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_SourceSystemsPopUp referenceDatas = new PO_SourceSystemsPopUp();
            referenceDatas.SearchSourceSystem(searchTerm);
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
