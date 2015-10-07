using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.NavigationPO;
using System.Threading;
using MTAutomation.Utils;

namespace AutomationUtilities.Utils
{
    internal class ImportValuation
    {
        internal static void ImportValuation_TREMIR_R002()
        {
            CreateImportFile.Valuation_TREMIR_R002();
            PO_Dashboard.GoToImportValuationManualSource();
            PO_ImportManualValuationSource importPage = new PO_ImportManualValuationSource();
            importPage.ImportValuationTREMIR_R002()
                .Import();
            importPage.VerifyFileIsUploaded();
            Thread.Sleep(3000);
            PO_UTISearch.GoTo(Test.UTI, 120);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.GoToValuationSection();
            Thread.Sleep(3000);
            emirTransactionPage.VerifyCollateralAndValuationFileIsImported(60);
        }


        internal static void GenXML()
        {
            CreateImportFile.Valuation_GenXML();
            PO_Dashboard.GoToImportValuationManualSource();
            PO_ImportManualValuationSource importPage = new PO_ImportManualValuationSource();
            importPage.ImportValuationGenericXML()
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 120);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.GoToValuationSection();
            emirTransactionPage.VerifyCollateralAndValuationFileIsImported(60);
        }

        internal static void GenXML_Delegated()
        {
            CreateImportFile.Valuation_GenXML_Delegated();
            PO_Dashboard.GoToImportValuationManualSource();
            PO_ImportManualValuationSource importPage = new PO_ImportManualValuationSource();
            importPage.ImportValuationGenericXML()
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 50);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.GoToValuationSection();
            emirTransactionPage.VerifyDelegatedValuationFileIsImported(60);
        }

        internal static void TestSecondTenant()
        {
            PO_UTISearch.GoToSecondTenantTest(Test.UTI);
        }

        internal static void ImportValuation_TREMIR_R002_NonDelegated()
        {
            CreateImportFile.Valuation_TREMIR_R002_NonDelegated_DTCC();
            PO_Dashboard.GoToImportValuationManualSource();
            PO_ImportManualValuationSource importPage = new PO_ImportManualValuationSource();
            importPage.ImportValuationTREMIR_R002()
                .FindReplaceElement("549300346EFUPFCXJT79", Test.counterParty)
                .Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 50);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.GoToValuationSection();
            emirTransactionPage.VerifyCollateralAndValuationFileIsImported(60);
        }
    }
}
