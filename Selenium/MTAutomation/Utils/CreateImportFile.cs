using AutomationUtilities.Utils;
using System.Configuration;

namespace MTAutomation.Utils
{
    class CreateImportFile
    {
        internal static void CreateNewGenericXML()
        {
            MTUtils.SetTradeId();
            XMLEditor xmlEditor = new XMLEditor(ConfigurationManager.AppSettings["testFilesLocation"] + "\\Trades\\GenXML\\GenericXML_Client_Direct_Boris_1_Coll.xml");
            xmlEditor.EditTradeNode("SourceTradeID", Test.tradeID + "STI", "http://www.impendiumsystems.com/2012/emirreporting");
            xmlEditor.EditTradeNode("UniqueTradeID", Test.tradeID + "UTI", "http://www.impendiumsystems.com/2012/emirreporting");
            xmlEditor.EditTradeNode("TransactionReferenceNumber", Test.tradeID, "http://www.impendiumsystems.com/2012/emirreporting");
            xmlEditor.SaveXML("");
        }

        internal static void Collateral_GenXML_NonDelegated()
        {
            XMLEditor xmlEditor = new XMLEditor(ConfigurationManager.AppSettings["testFilesLocation"] + "\\Collateral\\GenXML\\EMIRCollateral_UTI.xml");
            xmlEditor.EditCollateralNode("CollateralDate", Test.testdate);
            xmlEditor.EditCollateralNode("CollateralValue", "6464");
            xmlEditor.EditCollateralNode("SourceTradeID", Test.STI);
            xmlEditor.EditCollateralNode("UniqueTradeID", Test.UTI);
            xmlEditor.EditCollateralNode("CollateralCounterparty", Test.counterParty);
            xmlEditor.SaveXML("");
        }

        internal static void Collateral_GenXML_ByUTI()
        {
            XMLEditor xmlEditor = new XMLEditor(ConfigurationManager.AppSettings["testFilesLocation"] + "\\Collateral\\GenXML\\EMIRCollateral_UTI.xml");
            xmlEditor.EditCollateralNode("CollateralDate", Test.testdate);
            xmlEditor.EditCollateralNode("CollateralValue", "6464");
            xmlEditor.EditCollateralNode("SourceTradeID", Test.STI);
            xmlEditor.EditCollateralNode("UniqueTradeID", Test.UTI);
            xmlEditor.EditCollateralNode("CollateralCounterparty", Test.counterParty);

            xmlEditor.SaveXML("");
        }

        internal static void Collateral_GenXML_Delegated()
        {
            XMLEditor xmlEditor = new XMLEditor(ConfigurationManager.AppSettings["testFilesLocation"] + "\\Collateral\\GenXML\\EMIRCollateral_Test_Delegated_Collateral.xml");
            xmlEditor.EditCollateralNode("CollateralDate", Test.testdate);
            xmlEditor.EditCollateralNode("CollateralValue", "6464");
            xmlEditor.EditCollateralNode("SourceTradeID", Test.STI);
            xmlEditor.EditCollateralNode("UniqueTradeID", Test.UTI);
            xmlEditor.EditCollateralNode("CollateralCounterparty", Test.counterPartyDelegated);
            xmlEditor.SaveXML("");
        }

        internal static void Collateral_GenXML_ByPortfolioCode()
        {
            XMLEditor xmlEditor = new XMLEditor(ConfigurationManager.AppSettings["testFilesLocation"] + "\\Collateral\\GenXML\\EMIRCollateral_PortfolioCode.xml");
            xmlEditor.EditCollateralNode("CollateralDate", Test.testdate);
            xmlEditor.EditCollateralNode("CollateralValue", "6464");
            xmlEditor.EditCollateralNode("CollateralCounterparty", Test.counterParty);
            xmlEditor.SaveXML("");
        }

        internal static void Collateral_TREMIR_R003()
        {
            CSVEditor.CreateNewTREMIR_R010("Collateral\\TREMIR\\SIM_R003_TREMIR_KNICX_1_28_009_NonDelegated.csv", "SIM_R003");
            CSVEditor.FindReplaceElement("ChangeUTI", Test.STI);
            CSVEditor.FindReplaceElement("1000000079", Test.CollateralPortCode);
            CSVEditor.FindReplaceElement("2014-08-27", Test.testdate);
            CSVEditor.FindReplaceElement("549300346EFUPFCXJT79", Test.counterParty);
        }

        internal static void TREMIR_R001_Delegated_DTCC()
        {
            CSVEditor.CreateNewTREMIR_R010("Positions\\TREMIR\\PRD_R001_TREMIR_Del_DTCC.csv", "PRD_R001_");
            CSVEditor.FindReplaceElement("ChangeSTI", Test.UTI);
            CSVEditor.FindReplaceElement("EffDate", Test.testdate);
        }

        internal static void TREMIR_R001_Delegated_REGIS()
        {
            CSVEditor.CreateNewTREMIR_R010("Positions\\TREMIR\\PRD_R001_TREMIR_Del_Regis.csv", "PRD_R001_");
            CSVEditor.FindReplaceElement("ChangeSTI", Test.UTI);
            CSVEditor.FindReplaceElement("EffDate", Test.testdate);
        }

        internal static void TREMIR_R001_NonDelegated_DTCC()
        {
            CSVEditor.CreateNewTREMIR_R010("Positions\\TREMIR\\PRD_R001_TREMIR_NonDel_DTCC.csv", "PRD_R001_");
            CSVEditor.FindReplaceElement("ChangeSTI", Test.UTI);
            CSVEditor.FindReplaceElement("EffDate", Test.testdate);
        }

        internal static void TREMIR_R001_NonDelegated_REGIS()
        {
            CSVEditor.CreateNewTREMIR_R010("Positions\\TREMIR\\PRD_R001_TREMIR_NonDel_Regis.csv", "PRD_R001_");
            CSVEditor.FindReplaceElement("ChangeSTI", Test.UTI);
            CSVEditor.FindReplaceElement("EffDate", Test.testdate);
        }

        internal static void GenXML()
        {
            XMLEditor xmlEditor = new XMLEditor(ConfigurationManager.AppSettings["testFilesLocation"] + "\\Trades\\GenXML\\GenericXML_Client_Direct_Boris_1_Coll.xml");
            xmlEditor.EditTradeNode("SourceTradeID", Test.STI, "http://www.impendiumsystems.com/2012/emirreporting");
            xmlEditor.EditTradeNode("UniqueTradeID", Test.UTI, "http://www.impendiumsystems.com/2012/emirreporting");
            xmlEditor.EditTradeNode("TransactionReferenceNumber", Test.tradeID, "http://www.impendiumsystems.com/2012/emirreporting");
            xmlEditor.SaveXML("");
        }

        internal static void TREMIR_R010_Delegated_DTCC()
        {
            CSVEditor.CreateNewTREMIR_R010("Trades\\TREMIR\\PRD_R010_TREMIR_Delegated_DTCC.csv", "PRD_R010_");
            CSVEditor.FindReplaceElement("ChangeSTI", Test.UTI);
            CSVEditor.FindReplaceElement("EffDate", Test.testdate);
        }

        internal static void TREMIR_R010_Delegated_REGIS()
        {
            CSVEditor.CreateNewTREMIR_R010("Trades\\TREMIR\\PRD_R010_TREMIR_Delegated_REGIS.csv", "PRD_R010_");
            CSVEditor.FindReplaceElement("ChangeSTI", Test.UTI);
            CSVEditor.FindReplaceElement("EffDate", Test.testdate);
        }

        internal static void TREMIR_R010_NonDelegated_DTCC()
        {
            CSVEditor.CreateNewTREMIR_R010("Trades\\TREMIR\\PRD_R010_TREMIR_NonDelegated_DTCC.csv", "PRD_R010_");
            CSVEditor.FindReplaceElement("ChangeSTI", Test.UTI);
            CSVEditor.FindReplaceElement("EffDate", Test.testdate);
        }

        internal static void TREMIR_R010_NonDelegated_REGIS()
        {
            CSVEditor.CreateNewTREMIR_R010("Trades\\TREMIR\\PRD_R010_TREMIR_NonDelegated_REGIS.csv", "PRD_R010_");
            CSVEditor.FindReplaceElement("ChangeSTI", Test.UTI);
            CSVEditor.FindReplaceElement("EffDate", Test.testdate);
        }

        internal static void Valuation_TREMIR_R002()
        {
            CSVEditor.CreateNewTREMIR_R010("Valuation\\TREMIR\\SIM_R002_TREMIR.csv", "SIM_R002");
            CSVEditor.FindReplaceElement("ChangeSTI", Test.UTI);
            CSVEditor.FindReplaceElement("2014-09-16", Test.testdate);
            CSVEditor.FindReplaceElement("HV8S8PAHJ173N2DHDM73", Test.counterParty);
        }

        internal static void Valuation_GenXML()
        {
            XMLEditor xmlEditor = new XMLEditor(ConfigurationManager.AppSettings["testFilesLocation"] + "\\Valuation\\GenXML\\Boris_DTCC_ETD_Valuation.xml");
            xmlEditor.EditValuationNode("SourceTradeID", Test.STI);
            xmlEditor.EditValuationNode("UniqueTradeID", Test.UTI);
            xmlEditor.EditValuationNode("ValuationDate", Test.testdate);
            xmlEditor.EditValuationNode("ValuationCounterparty", Test.counterParty);
            xmlEditor.SaveXML("");
        }

        internal static void Valuation_GenXML_Delegated()
        {
            XMLEditor xmlEditor = new XMLEditor(ConfigurationManager.AppSettings["testFilesLocation"] + "\\Valuation\\GenXML\\Regis_ETD_DelegatedValuation.xml");
            xmlEditor.EditValuationNode("SourceTradeID", Test.STI);
            xmlEditor.EditValuationNode("UniqueTradeID", Test.UTI);
            xmlEditor.EditValuationNode("ValuationDate", Test.testdate);
            xmlEditor.EditValuationNode("ValuationCounterparty", Test.counterPartyDelegated);
            xmlEditor.SaveXML("");
        }

        internal static void Valuation_TREMIR_R002_NonDelegated_DTCC()
        {
            CSVEditor.CreateNewTREMIR_R010("Valuation\\TREMIR\\SIM_R002_TREMIR_NonDelegated_DTCC.csv", "SIM_R002");
            CSVEditor.FindReplaceElement("ChangeSTI", Test.UTI);
            CSVEditor.FindReplaceElement("2014-09-16", Test.testdate);
            CSVEditor.FindReplaceElement("HV8S8PAHJ173N2DHDM73", Test.counterParty);
        }

        internal static void TREMIR_R010_CompressionFile()
        {
            CSVEditor.CreateNewTREMIR_R010("Trades\\TREMIR\\PRD_R010_TREMIR_Compression.csv", "PRD_R010_");
            CSVEditor.FindReplaceElement("TransactionDate", Test.testdate);
            CSVEditor.FindReplaceElement("ChangeUTI", Test.UTI);
            CSVEditor.FindReplaceElement("ChangeSTI", Test.STI);
            CSVEditor.FindReplaceElement("EffDate", Test.testdate);
        }

        internal static void Product_CSVImporter()
        {
            CSVEditor.CreateNewTREMIR_R010("Products\\CSVImporter\\ProductUploadCSVTemplates.csv", "PRD");
            CSVEditor.FindReplaceElement("BorisProductName", Test.extRef = "TA" + Util.GetRandomID());
            CSVEditor.FindReplaceElement("321321312", Test.extRef);
        }
    }
}
