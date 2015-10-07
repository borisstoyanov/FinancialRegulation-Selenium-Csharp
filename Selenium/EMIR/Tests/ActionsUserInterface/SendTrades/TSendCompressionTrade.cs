using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace EmirAutomation.Tests.ActionsUserInterface.SendTrades
{
    [TestClass]
    public class TSendCompressionTrade : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("Send"), TestCategory("ActionsUI"), TestCategory("SendCompression"), TestCategory("Nightly"), TestMethod()]
        public void TC14497_SendCompression()
        {
            storeResults = true;
            CreateImportFile.TREMIR_R010_CompressionFile();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importCompression = new PO_ImportManualTradeSource();
            importCompression.ImportTREMIRFileR010()
                .Import();
            importCompression.VerifyFileIsUploaded();


            PO_UTISearch.GoTo(Test.UTI, 50);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend();

            PO_SendTradesByTargetSetting sendTrades = PO_Dashboard.GoToSendTradesByTargetSetting();
            sendTrades.SelectTargetSEtting("Send RegisTR New Trades (EMIR, REGIS-TR)");
            sendTrades.Send();
            sendTrades.VerifySendingByTargetSetting("Send RegisTR New Trades (EMIR, REGIS-TR)");

            PO_UTISearch.GoTo(Test.UTI, 50);
            emirTransactionPage.VerifyReadyToSend(180);

            PO_Dashboard.GoToSendTradesByTargetSetting();
            sendTrades.SelectTargetSEtting("Send RegisTR Cancel Trades (EMIR, REGIS-TR)");
            sendTrades.Send();
            sendTrades.VerifySendingByTargetSetting("Send RegisTR Cancel Trades (EMIR, REGIS-TR)");

            PO_UTISearch.GoTo(Test.UTI, 50);
            emirTransactionPage.VerifySendSuccessfully(30);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
