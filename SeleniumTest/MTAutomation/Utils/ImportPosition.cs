using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using System;
using MTAutomation.Utils;

namespace AutomationUtilities.Utils
{
    internal class ImportPosition
    {
        internal static String TREMIR_R001_Delegated_DTCC()
        {
            CreateImportFile.TREMIR_R001_Delegated_DTCC();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportTREMIRFileR001()
                .Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend();
            Test.counterParty = "KU2715";
            Test.counterPartyDelegated = "KU2788";
            return Test.tradeID;
        }

        internal static void TestSecondTenant()
        {
            PO_UTISearch.GoToSecondTenantTest(Test.UTI);
        }

        internal static string TREMIR_R001_Delegated_REGIS()
        {
            CreateImportFile.TREMIR_R001_Delegated_REGIS();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportTREMIRFileR001()
                .Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 120);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend();
            Test.counterParty = "Impendium";
            Test.counterPartyDelegated = "549300SBVDKRZY45N027";
            return Test.tradeID;
        }

        internal static void TREMIR_R001_NonDelegated_DTCC()
        {
            CreateImportFile.TREMIR_R001_NonDelegated_DTCC();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportTREMIRFileR001()
                .Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 120);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend();
            Test.counterParty = "010TestCounterpartyClient2";
        }

        internal static void TREMIR_R001_NonDelegated_REGIS()
        {
            CreateImportFile.TREMIR_R001_NonDelegated_REGIS();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportTREMIRFileR001()
                .Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 120);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend();
            Test.counterParty = "Impendium";

        }
    }
}
