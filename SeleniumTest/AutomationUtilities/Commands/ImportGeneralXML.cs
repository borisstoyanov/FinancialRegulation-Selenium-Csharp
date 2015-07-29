using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using System;
using System.Configuration;

namespace AutomationUtilities.Commands
{
    public class ImportGeneralXML
    {
        XMLEditor xmlEditor = new XMLEditor(Test.absolutePathToImportFile);

        public ImportGeneralXML EditTradeNode(string node, string value)
        {
            String xmlNS = null; 
            string regulation = ConfigurationManager.AppSettings["regulation"];
            switch (regulation)
            {
                case "REMIT":
                    xmlNS = "http://www.acer.europa.eu/REMIT/REMITTable1_V1.xsd";
                    break;

                case "EMIR":
                    xmlNS = "http://www.impendiumsystems.com/2012/emirreporting";
                    break;
            }

            xmlEditor.EditTradeNode(node, value, xmlNS);
            return this;
        }




        public void Import()
        {
            PO_ImportManualTradeSource.SelectFile(Test.absolutePathToImportFile);
            PO_ImportManualTradeSource.clickImport();
        }

        public ImportGeneralXML SaveXML()
        {
            xmlEditor.SaveChangedXML();
            return this;

        }

        public ImportGeneralXML EditTradeNode(string parentNode, string childNode, string value)
        {
            xmlEditor.EditTradeNode(parentNode, childNode, value, "http://www.acer.europa.eu/REMIT/REMITTable1_V1.xsd");
            return this;
        }
    }
}
