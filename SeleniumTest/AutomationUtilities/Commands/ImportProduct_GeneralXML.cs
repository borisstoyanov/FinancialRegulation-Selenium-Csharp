using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects.ImportManualSourcePO;
using AutomationUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationUtilities.Commands
{
    public class ImportProduct_GeneralXML
    {
        XMLEditor xmlEditor = new XMLEditor(Test.absolutePathToImportFile);
        public ImportProduct_GeneralXML EditProductNode(string node, string value)
        {
            xmlEditor.EditProductNode(node, value);
            return this;
        }

        public void Import()
        {
            PO_ImportProductManualSource.SelectFile(Test.absolutePathToImportFile);
            PO_ImportProductManualSource.SelectSourceSettingValueContaining(TargetSettings_Import.Product_GenricXML);
            PO_ImportProductManualSource.clickImport();
        }

        public ImportProduct_GeneralXML SaveXML()
        {
            xmlEditor.SaveChangedXML();
            return this;

        }
    }
}
