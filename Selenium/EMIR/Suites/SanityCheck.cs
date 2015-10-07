using EmirAutomation.Tests.ActionsUserInterface.ImportTrades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace EmirAutomation.Suites
{
    public class SanityCheck
    {
        
        public static IEnumerable Suite
        {
            get
            {
                ArrayList suite = new ArrayList();
                suite.Add(new TImportPosition_TREMIR_R001_DelegatedAndNonDelegated_DTCC());
                suite.Add(new TImportTrade_TREMIR_R010_Delegated_REGIS());
                return suite;
            }
        }
    }
}
