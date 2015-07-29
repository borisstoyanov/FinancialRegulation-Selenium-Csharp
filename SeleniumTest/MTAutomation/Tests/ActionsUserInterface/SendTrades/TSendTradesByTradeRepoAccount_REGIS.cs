using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.SendPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace MTAutomation.Tests.SendTrades
{
    [TestClass]
    public class TSendTradesByTradeRepoAccount_REGIS : Test
    {
        string tradeID1;
        string tradeID2;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            tradeID1 = ImportPosition.TREMIR_R001_Delegated_REGIS();
            tradeID2 = ImportTrade.TREMIR_R010_Delegated_REGIS();
        }

        [TestCategory("Send"), TestCategory("ActionsUI"), TestCategory("SendPosition"), TestCategory("SendREGIS"), TestMethod()]
        public void SendTradeByTradeRepoAccount_REGIS()
        {
            storeResults = true;
            PO_SendTradesByTradeRepo sendTrades = PO_Dashboard.GoToSendTradesByTradeRepo();
            sendTrades.SelectTradeRepo(TargetSettings_SendByTradeRepo.TradeRepo_REGIS);
            sendTrades.CheckIfTradeAvailableForSending(tradeID1 + "STI", 10, TargetSettings_SendByTradeRepo.TradeRepo_REGIS);
            sendTrades.CheckIfTradeAvailableForSending(tradeID2 + "STI", 10, TargetSettings_SendByTradeRepo.TradeRepo_REGIS);
            sendTrades.Send();
            sendTrades.VerifySendingByTargetSetting(TargetSettings_SendByTradeRepo.TradeRepo_REGIS);

            PO_UserAccountButton.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantB_EMIRUser01();
            PO_SendTradesByTargetSetting sendTradesPage = PO_Dashboard.GoToSendTradesByTargetSetting();
            sendTradesPage.SelectTargetSEtting(TargetSettings_SendByTradeRepo.TradeRepo_REGIS);
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
