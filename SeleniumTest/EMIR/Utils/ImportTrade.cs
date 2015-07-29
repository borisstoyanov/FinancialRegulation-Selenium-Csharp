using AutomationUtilities.Browser;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using System;

namespace EmirAutomation.Utils
{
    internal class ImportTrade
    {
        internal static int CollateralId;

        internal static void Trade(String portfolioCode)
        {
            CreateImportFile.GenXML();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportGeneralXMLWith()
                .EditTradeNode("PortfolioCodeValue", Test.CollateralPortCode)
                .EditTradeNode("PortfolioCode", portfolioCode)
                .Import();
            Test.counterParty = "Impendium";  //REGIS position Counterparty
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend();
        }

        internal static void TradeWithCollateralTest(String portfolioCode)
        {
            CreateImportFile.GenXML();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportGeneralXMLWith()
                .EditTradeNode("PortfolioCodeValue", Test.CollateralPortCode)
                .EditTradeNode("PortfolioCode", portfolioCode)
                .SaveXML().Import();
            Test.counterParty = "Impendium";  //REGIS position Counterparty
            importPage.VerifyFileIsUploaded();
            CollateralId = SQLServerUtilities.GetCollateralId(Test.STI);
            GoToCollateralPage();
        }

        internal static bool GoToCollateralPage()
        {
            bool bRet = false;

            try
            {
                Browser.GoToPage("/EMIRCollateral/Edit?ID=" + CollateralId.ToString());
                bRet = true;
            }
            catch
            {

            }

            return bRet;
        }

        internal static string TREMIR_R010_Delegated_DTCC()
        {
            CreateImportFile.TREMIR_R010_Delegated_DTCC();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportTREMIRFileR010()
                .Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend();
            Test.counterParty = "KU2715";
            Test.counterPartyDelegated = "KU2788";
            return Test.tradeID;
        }

        internal static string TREMIR_R010_Delegated_REGIS()
        {

            CreateImportFile.TREMIR_R010_Delegated_REGIS();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportTREMIRFileR010()
                .Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend();
            Test.counterParty = "Impendium";
            Test.counterPartyDelegated = "549300SBVDKRZY45N027";
            return Test.tradeID;
        }

        internal static void TREMIR_R010_NonDelegated_DTCC()
        {
            CreateImportFile.TREMIR_R010_NonDelegated_DTCC();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportTREMIRFileR010()
                .Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 120);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend();
            Test.counterParty = "010TestCounterpartyClient2";
        }

        internal static void TestSecondTenant()
        {
            PO_UTISearch.GoToSecondTenantTest(Test.UTI);
        }

        internal static void TREMIR_R010_NonDelegated_REGIS()
        {
            CreateImportFile.TREMIR_R010_NonDelegated_REGIS();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportTREMIRFileR010()
                .Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 120);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend();
            Test.counterParty = "Impendium";
        }
    }
}
