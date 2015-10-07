using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace MTAutomation.Tests.SendTrades
{
    [TestClass]
    public class TSendPositionsToDTCC : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            ImportPosition.TREMIR_R001_NonDelegated_DTCC();
        }

        [TestCategory("Send"), TestCategory("ActionsUI"), TestCategory("SendPosition"), TestCategory("ShortSend"), TestCategory("Nightly"), TestCategory("SendDTCC"), TestMethod()]
        public void TC14490_SendPosition_DTCC()
        {
            storeResults = true;
            Send.SendTrade(TargetSettings_SendTrades.SendDTCCOTCPositionNewRecords);
            EmirUtils.VerifyEmirConfirmed();

            PO_UserAccountButton.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();
            PO_SendTradesByTargetSetting sendTradesPage = PO_Dashboard.GoToSendTradesByTargetSetting();
            sendTradesPage.SelectTargetSEtting(TargetSettings_SendTrades.SendDTCCOTCPositionNewRecords);
            Util.CheckIfTextNotPresented(Test.UTI);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
