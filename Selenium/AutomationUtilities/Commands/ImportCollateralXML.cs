using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using System;

namespace AutomationUtilities.Commands
{
    public class ImportCollateralXML
    {
        XMLEditor xmlEditor = new XMLEditor(Test.absolutePathToImportFile);
        public ImportCollateralXML EditCollateralNode(String node, String value)
        {
            xmlEditor.EditCollateralNode(node, value);
            return this;
        }
        public void Import()
        {
            PO_ImportManualTradeSource.SelectFile(Test.absolutePathToImportFile);
            PO_ImportManualTradeSource.SelectSourceSettingValueContaining(TargetSettings_Import.GenXML_Collateral);
            PO_ImportManualTradeSource.clickImport();
        }

        public ImportCollateralXML SaveXML()
        {
            xmlEditor.SaveChangedXML();
            return this;
        }

    }
}
