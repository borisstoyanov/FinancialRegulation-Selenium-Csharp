using System;
using System.Configuration;
using System.Xml;

namespace AutomationUtilities.Utils
{
    public class XMLEditor
    { 

        public static XmlDocument xmlDoc = new XmlDocument();

       
        public XMLEditor(string file)
        {
            xmlDoc.Load(file);
        }

        public void EditCollateralNode( String nodeName, String value)
        {
            XmlNode node = GetXmlNode( nodeName, xmlDoc, "http://www.impendiumsystems.com/2012/emircollateral");
            node.InnerText = value;
            
           
        }

        public void EditTradeNode( String nodeName, String value, String xmlns)
        {
            XmlNode node = GetXmlNode(nodeName, xmlDoc, xmlns);
            node.InnerText = value;
            

        }

          XmlNode GetXmlNode( String nodeName, XmlDocument xmlDoc, string xmlNS)
        {
            var xmlNsM = new XmlNamespaceManager(xmlDoc.NameTable);
            xmlNsM.AddNamespace("mirns", xmlNS);
            XmlNode node = xmlDoc.SelectSingleNode("//mirns:" + nodeName, xmlNsM);
            return node;
        }

          public void SaveXML(String prefix)
          {
              Test.fileName = "GenericXML_"+ prefix + Util.GetUniqueFileName("xml");
              xmlDoc.Save(Test.absolutePathToImportFile = ConfigurationManager.AppSettings["remoteLocation"] + Test.fileName);
          }

          public void SaveChangedXML()
          {
              xmlDoc.Save(Test.absolutePathToImportFile = ConfigurationManager.AppSettings["remoteLocation"] + Test.fileName);

          }

          public void EditValuationNode(string nodeName, string value)
          {
              XmlNode node = GetXmlNode(nodeName, xmlDoc, "http://www.impendiumsystems.com/2012/emirvaluation");
              node.InnerText = value;
          }

          public void EditProductNode(string nodeName, string value)
          {
              XmlNode node = GetXmlNode(nodeName, xmlDoc, "http://www.impendiumsystems.com/2012/emirproduct");
              node.InnerText = value;
          }

          public void SaveAs(string location)
          {
              xmlDoc.Save(location);
          }

          public void OrderNode(string nodeName, string value)
          {
              XmlNode node = GetXmlNode(nodeName, xmlDoc, "http://www.acer.europa.eu/REMIT/REMITTable1_V1.xsd");
              node.InnerText = value;
          }

          public void EditTradeNode(string nodeName, string childNode, string value, string xmlns)
          {
              XmlNamespaceManager nsmgr = new XmlNamespaceManager(new NameTable());
              nsmgr.AddNamespace("msb", xmlns);
              XmlNode node = xmlDoc.SelectSingleNode("//msb:"+nodeName+"/msb:"+childNode, nsmgr);
              node.InnerText = value;
          }
    }
}
