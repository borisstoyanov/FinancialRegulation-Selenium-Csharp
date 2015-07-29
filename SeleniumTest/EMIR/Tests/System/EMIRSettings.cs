using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ReferenceDataTab
{
    [TestClass]
    public class EMIRSettings : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("SystemTab"), TestCategory("Maintenance"), TestMethod()]
        public void SetEMIRSettings()
        {
            storeResults = true;
            PO_EMIRSettings referenceData = PO_Dashboard.GoToEMIRSettingsPopUp();
            referenceData.SetBaseCurrency("USD")
                .SetCountryName("UNITED KINGDOM")
                .Save();
            referenceData.VerifyEMIRSettings();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
