using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using System;

namespace AutomationUtilities.Commands
{
    public class ImportCollateralTREMIR
    {
        public ImportCollateralTREMIR FindReplaceElement(String find, String replace)
        {
            CSVEditor.FindReplaceElement(find, replace);
            return this;
        }

        public void Import()
        {
            PO_ImportManualTradeSource.SelectFile(Test.absolutePathToImportFile);
            PO_ImportManualTradeSource.SelectSourceSettingValueContaining(TargetSettings_Import.TREMIR_R003_Collateral);
            PO_ImportManualTradeSource.clickImport();
        }
    }
}
