using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ReferenceDataTab
{
    [TestClass]
    public class TCurrencies_Edit : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Currency_EditCurrencies()
        {
            storeResults = true;
            PO_CurrencyPopUp referenceDatas = PO_Dashboard.GoToCurrenciesPopUp();
            referenceDatas.CreateNewCurrency()
                .Create();
            referenceDatas.VerifyCurrencyCreated();
            referenceDatas.EditCurrency()
                .SetCurrencyField("Currency_Name", "TA" + Util.GetRandomID())
                .Save();
            referenceDatas.VerifyCurrencyEdited();
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
