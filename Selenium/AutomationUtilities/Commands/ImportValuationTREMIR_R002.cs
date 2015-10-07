using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using System;

namespace AutomationUtilities.Commands
{
    public class ImportValuationTREMIR_R002
    {
        public ImportValuationTREMIR_R002 FindReplaceElement(String find, String replace)
        {
            CSVEditor.FindReplaceElement(find, replace);
            return this;
        }

        public void Import()
        {
            PO_ImportManualTradeSource.SelectFile(Test.absolutePathToImportFile);
            PO_ImportManualTradeSource.SelectSourceSettingValueContaining(TargetSettings_Import.TREMIR_R002_Valuation);
            PO_ImportManualTradeSource.clickImport();
        }
    }
}
