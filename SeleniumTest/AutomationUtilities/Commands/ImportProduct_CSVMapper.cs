using AutomationUtilities.PageObjects.ImportManualSourcePO;
using AutomationUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationUtilities.Commands
{
    public class ImportProduct_CSVImporter
    {
        public ImportProduct_CSVImporter FindReplaceElement(String find, String replace)
        {
            CSVEditor.FindReplaceElement(find, replace);
            return this;
        }

        public void Import()
        {
            PO_ImportProductManualSource.SelectFile(Test.absolutePathToImportFile);
            PO_ImportProductManualSource.clickImport();
        }
    }
}
