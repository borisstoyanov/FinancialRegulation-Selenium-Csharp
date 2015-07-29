using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ReferenceDataTab
{
    [TestClass]
    public class TCurrencies_Detail : Test
    {
        bool storeResults = false;


        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("ReferenceDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Currency_ViewCurrencie()
        {
            storeResults = true;
            PO_CurrencyPopUp referenceDatas = PO_Dashboard.GoToCurrenciesPopUp();
            referenceDatas.CreateNewCurrency()
                .Create();
            referenceDatas.VerifyCurrencyCreated();
            referenceDatas.ViewCurrencyDetails();
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
