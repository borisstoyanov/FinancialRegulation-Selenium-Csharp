using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TExtRefOut_EditRefOut : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EMIRExtRefOut_Edit_ChangeTradeRepo()
        {
            storeResults = true;
            PO_ExtRefOut_PopUp manageRefOuts = PO_Dashboard.GoToExternalRefOuts();
            PO_ExtRefOut_CreateRefOut createExtRefIn = manageRefOuts.ClickCreate();
            createExtRefIn.CreateExtRef("Country", "DTCC");
            manageRefOuts.VerifyExtRefOutIsCreated();
            manageRefOuts.EditRefOut()
                .SelectField(ExtRefOut.EMIRExtRefOut_TradeRepository, "CME")
                .Save();
            manageRefOuts.VerifyExtRefOutIsEdited();
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
