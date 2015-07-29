using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using System.Threading;
using MTAutomation.Utils;

namespace AutomationUtilities.Utils
{
    internal class ImportCollateral
    {
        internal static void ImportNewCollateralGenXMLByUTI()
        {
            CreateImportFile.Collateral_GenXML_ByUTI();
            PO_Dashboard.GoToImportCollateralManualSource();
            PO_ImportManualCollateralSource importColPage = new PO_ImportManualCollateralSource();
            importColPage.ImportCollateralGenericXML()
                .SaveXML().Import();
            importColPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 120);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.GoToCollateralSection();
            Thread.Sleep(3000);
            emirTransactionPage.VerifyCollateralAndValuationFileIsImported(60);
        }

        internal static void GenXML_Delegated()
        {
            CreateImportFile.Collateral_GenXML_Delegated();
            PO_Dashboard.GoToImportCollateralManualSource();
            PO_ImportManualCollateralSource importPage = new PO_ImportManualCollateralSource();
            importPage.ImportCollateralGenericXML()
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.GoToCollateralSection();
            emirTransactionPage.VerifyDelegatedCollateralReadyToSend(60);
        }

        internal static void TestSecondTenant()
        {
            PO_UTISearch.GoToSecondTenantTest(Test.UTI);
        }

        internal static void GenXML_NonDelegated()
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

        internal static void GenXML_ByPortfolioCode()
        {
            CreateImportFile.Collateral_GenXML_ByPortfolioCode();
            PO_Dashboard.GoToImportCollateralManualSource();
            PO_ImportManualCollateralSource importPage = new PO_ImportManualCollateralSource();
            importPage.ImportCollateralGenericXML()
                .EditCollateralNode("CollateralPortfolioCodeValue", Test.CollateralPortCode)
                .EditCollateralNode("CollateralPortfolioCode", "Yes")
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 60);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.GoToCollateralSection();
            Thread.Sleep(3000);
            emirTransactionPage.VerifyCollateralAndValuationFileIsImported(60);
        }

        internal static void TREMIR_R003()
        {
            Thread.Sleep(10000);
            CreateImportFile.Collateral_TREMIR_R003();
            PO_Dashboard.GoToImportCollateralManualSource();
            PO_ImportManualCollateralSource importPage = new PO_ImportManualCollateralSource();
            importPage.ImportCollateralTREMIR().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 120);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.GoToCollateralSection();
            Thread.Sleep(3000);
            emirTransactionPage.VerifyCollateralAndValuationFileIsImported(60);
        }
    }
}
