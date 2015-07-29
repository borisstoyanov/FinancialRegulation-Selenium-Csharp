using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.SystemTab
{
    [TestClass]
    public class TSystemActionTypes_Search : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
            PO_ActionTypesPopUp referenceDatas = PO_Dashboard.GoToSystemActionTypesPopUp();
            referenceDatas.CreateNewActionType()
                .Create();
            referenceDatas.VerifyActionTypeCreated();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void ActionType_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_ActionTypesPopUp referenceDatas = new PO_ActionTypesPopUp();
            referenceDatas.SearchActionType(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void ActionType_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_ActionTypesPopUp referenceDatas = new PO_ActionTypesPopUp();
            referenceDatas.SearchActionType(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void ActionType_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_ActionTypesPopUp referenceDatas = new PO_ActionTypesPopUp();
            referenceDatas.SearchActionType(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void ActionType_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_ActionTypesPopUp referenceDatas = new PO_ActionTypesPopUp();
            referenceDatas.SearchActionType(searchTerm);
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
