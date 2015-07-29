using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using System;

namespace MTAutomation.Utils
{
    public class MTUtils
    {
        public static String ImportTrade(String portfolioCode)
        {
            CreateImportFile.CreateNewGenericXML();
            PO_Dashboard.GoToImportTradeManualSource();
            PO_ImportManualTradeSource importPage = new PO_ImportManualTradeSource();
            importPage.ImportGeneralXMLWith()
                .EditTradeNode("PortfolioCodeValue", Test.CollateralPortCode)
                .EditTradeNode("PortfolioCode", portfolioCode)
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 50);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend();
            return Test.tradeID;
        }

        public static void ImportCollateral()
        {
            CreateImportFile.Collateral_GenXML_NonDelegated();
            PO_Dashboard.GoToImportCollateralManualSource();
            PO_ImportManualCollateralSource importPage = new PO_ImportManualCollateralSource();
            importPage.ImportCollateralGenericXML()
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.GoToCollateralSection();
            emirTransactionPage.VerifyCollateralAndValuationFileIsImported(60);
        }

        internal static string SetTradeId()
        {
            return Test.tradeID = Util.GetRandomID();
        }
    }
}
