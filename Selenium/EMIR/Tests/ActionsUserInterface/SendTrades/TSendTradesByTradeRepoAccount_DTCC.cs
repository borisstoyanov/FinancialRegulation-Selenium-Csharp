using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.SendPO;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace EmirAutomation.Tests.ActionsUserInterface.SendTrades
{
    [TestClass]
    public class TSendTradesByTradeRepoAccount_DTCC : Test
    {
        string tradeID1;
        string tradeID2;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            tradeID1 = ImportPosition.TREMIR_R001_Delegated_DTCC();
            tradeID2 = ImportTrade.TREMIR_R010_Delegated_DTCC();
        }

        [TestCategory("Send"), TestCategory("ActionsUI"), TestCategory("SendPosition"), TestCategory("SendDTCC"), TestMethod()]
        public void SendTradeByTradeRepoAccount_DTCC()
        {
            storeResults = true;
            PO_SendTradesByTradeRepo sendTrades = PO_Dashboard.GoToSendTradesByTradeRepo();
            sendTrades.SelectTradeRepo(TargetSettings_SendByTradeRepo.TradeRepo_DTCC);
            sendTrades.CheckIfTradeAvailableForSending(tradeID1 + "STI", 10, TargetSettings_SendByTradeRepo.TradeRepo_DTCC);
            sendTrades.CheckIfTradeAvailableForSending(tradeID2 + "STI", 10, TargetSettings_SendByTradeRepo.TradeRepo_DTCC);
            sendTrades.Send();
            sendTrades.VerifySendingByTargetSetting(TargetSettings_SendByTradeRepo.TradeRepo_DTCC);
            Test.result = "Passed";


        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
