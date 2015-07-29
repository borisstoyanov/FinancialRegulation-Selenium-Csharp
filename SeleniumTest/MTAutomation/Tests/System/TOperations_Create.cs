using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MTAutomation.Tests.SystemTab
{
    [TestClass]
    public class TMTOperations_Create : Test
    {
        PO_OperationsPopUp operationsPopUp;

        bool storeResults = false;
        string countMsg;

        [TestInitialize]
        public void SetUp()
        {
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithSystemUser();

            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();

            operationsPopUp = PO_Dashboard.GoToOperationsPopUp();
            countMsg = operationsPopUp.GetOperationsCountMsg();
            operationsPopUp.Close();

            PO_UserAccountButton.LogOff();
            login.LoginWithSystemUserB();
            operationsPopUp = PO_Dashboard.GoToOperationsPopUp();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTOperation_CreateOperation()
        {
            if (string.Compare(countMsg, operationsPopUp.GetOperationsCountMsg()) == 0)
            {
                Test.result = "Passed";
            }
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
