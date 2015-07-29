using AutomationUtilities.Utils;
using System.Configuration;

namespace RemitAutomation.Utils
{
    class CreateImportFile
    {
        internal static void GenXMLOrder()
        {
            XMLEditor xmlEditor = new XMLEditor(ConfigurationManager.AppSettings["assemblyLocation"] + "\\testFiles\\Orders\\GenXML\\GenericXML_Order_.xml");
            xmlEditor.EditTradeNode("uniqueOrderIdentifier", Test.UTI, "http://www.acer.europa.eu/REMIT/REMITTable1_V1.xsd");
            xmlEditor.SaveXML("Order");
        }

        internal static void GenXMLTrade()
        {
            XMLEditor xmlEditor = new XMLEditor(ConfigurationManager.AppSettings["assemblyLocation"] + "\\testFiles\\Trades\\GenXML\\GenericXML_Trade_.xml");
            xmlEditor.EditTradeNode("uniqueTransactionIdentifier", "uniqueTransactionIdentifier", Test.UTI, "http://www.acer.europa.eu/REMIT/REMITTable1_V1.xsd");
            xmlEditor.SaveXML("Trade");
        }

        internal static void GenXMLChained()
        {
            XMLEditor xmlEditor = new XMLEditor(ConfigurationManager.AppSettings["assemblyLocation"] + "\\testFiles\\ChainedImportFile\\GenericXML_Chained_.xml");
            xmlEditor.EditTradeNode("uniqueTransactionIdentifier", "uniqueTransactionIdentifier", Test.UTI, "http://www.acer.europa.eu/REMIT/REMITTable1_V1.xsd");
            xmlEditor.EditTradeNode("uniqueOrderIdentifier", Test.UTI, "http://www.acer.europa.eu/REMIT/REMITTable1_V1.xsd");
            xmlEditor.SaveXML("Trade");
        }
    }
}
