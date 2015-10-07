using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using System;

namespace AutomationUtilities.Commands
{
    public class ImportTREMIRFile
    {
        public ImportTREMIRFile FindReplaceElement(String find, String replace)
        {
            CSVEditor.FindReplaceElement(find, replace);
            return this;
        }

        public void Import()
        {
            PO_ImportManualTradeSource.SelectFile(Test.absolutePathToImportFile);
            PO_ImportManualTradeSource.clickImport();
        }
    }
}
