using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.LegalEntities;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TLegalEnt_Edit : Test
    {
        bool storeResults = false;
        string bicCode;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
            bicCode = EmirUtils.CreateBicCode();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void LegalEntity_Edit()
        {
            storeResults = true;
            PO_LegalEntities legEnt = PO_Dashboard.GoToLegalEntities();
            legEnt.CreateLegalEntity(bicCode)
                .Save();
            legEnt.VerifyLegalEntityCreated();
            legEnt.EditLegalEntities()
                .SetField(LegalEntityFields.LegalEntity_Disclaimer, "Disclamer")
                .Save();
            legEnt.VerifyLegalEntityIsEdited();
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
