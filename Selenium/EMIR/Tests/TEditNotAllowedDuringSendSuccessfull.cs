using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.WorkQ
{   
    [TestClass]
    public class TEditNotAllowedDuringSendSuccessfull : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();

        }

        [TestCategory("Send"), TestCategory("SendTrades"), TestCategory("SendDTCC"), TestMethod()]
        public void EditTrade_EditNotAllowedDuringSendSuccessfull()
        {
            storeResults = true;
            ImportTrade.TREMIR_R010_NonDelegated_DTCC();

            Send.SendTrade(TargetSettings_SendTrades.SendDTCCETDTradeNewRecords);

            PO_UTISearch.GoTo(Test.UTI, 50);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifySendSuccessfully(30);
            emirTransactionPage.VerifyEditingNotPossible();

            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
