using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.Maintanance.BusinessData.EicCodes;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TEic_EditEicCode : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();            
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void EICCode_EditEIC()
        {
            storeResults = true;
            PO_EICPopUp eic = PO_Dashboard.GoToEICPopUp();
            eic.CreateNewEicCode()
                .CreateEIC("Delivery Zone (Y-code)")
                .Create();
            eic.VerifyEicCodeCreated();
            eic.EditEicCode()
                .SetEicCideField(EicFieldIDs.EICCode_LongName, "TALongName")
                .SelectField(EicFieldIDs.EICCode_EICCodeTypeID, "Party (X-code)")
                .Save();
            eic.VerifyEicCodeEdited();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
