using System;
using System.Text;

namespace AutomationUtilities.Utils
{
    public class TestResults
    {
        public String result;
        public String testName;
        public StringBuilder verificationErrors = new StringBuilder();

        public String build;
        public String  browserVersion;

        public String fileName;

        public String absolutePathToImportFile;

        public String tradeID;
        public DateTime date;
        public String testInstance;
        public static void SetLastSuccessfullTrade()
        {
            SQLServerUtilities.SetLastSuccessfullTradeImport();

        }
    }
}
