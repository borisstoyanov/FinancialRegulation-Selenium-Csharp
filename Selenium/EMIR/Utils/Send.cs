using AutomationUtilities.PageObjects;

namespace EmirAutomation.Utils
{
    internal class Send
    {
        internal static void SendTrade(string targetSettings_Send)
        {
            PO_SendTradesByTargetSetting sendTrades = PO_Dashboard.GoToSendTradesByTargetSetting();
            sendTrades.SelectTargetSEtting(targetSettings_Send);
            sendTrades.CheckIfAnyAvailableForSending(10, targetSettings_Send);
            sendTrades.Send();

        }

        internal static void SendCollateral(string targetSettings_SendCollateral)
        {
            PO_SendCollaterals sendTrades = PO_Dashboard.GoToSendCollateralsByTargetSetting();
            sendTrades.SelectTargetSEtting(targetSettings_SendCollateral);
            sendTrades.CheckIfAnyAvailableForSending(10, targetSettings_SendCollateral);
            sendTrades.Send();
            sendTrades.VerifySendingByTargetSetting(targetSettings_SendCollateral);
        }

        internal static void SendValuation(string targetSettings_SendValuation)
        {
            PO_SendValuations sendVal = PO_Dashboard.GoToSendValuationsByTargetSetting();
            sendVal.SelectTargetSEtting(targetSettings_SendValuation);
            sendVal.CheckIfAnyAvailableForSending(10, targetSettings_SendValuation);
            sendVal.Send();
            sendVal.VerifySendingByTargetSetting("DTCC OTC Valuation Update (EMIR, DTCC)");
        }
    }
}
