using AutomationUtilities.PageObjects.LegalEntities;
using AutomationUtilities.PageObjects.BicPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomationUtilities.PageObjects;
using EmirAutomation.Utils;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TLegalEnt_SearchTests : Test
    {
        bool storeResults = false;
        string searchTerm;
        PO_LegalEntities legEnt;
        string bicCode;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
            bicCode = EmirUtils.CreateBicCode();
            legEnt = PO_Dashboard.GoToLegalEntities();
            legEnt.CreateLegalEntity(bicCode)
                .Save();
            legEnt.VerifyLegalEntityCreated();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void LegalEntity_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            legEnt = new PO_LegalEntities();
            legEnt.SearchForLegalEntity(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void LegalEntity_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            legEnt = new PO_LegalEntities();
            legEnt.SearchForLegalEntity(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void LegalEntity_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            legEnt = new PO_LegalEntities();
            legEnt.SearchForLegalEntity(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void LegalEntity_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            legEnt = new PO_LegalEntities();
            legEnt.SearchForLegalEntity(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void LegalEntity_SearchingEndsWithAsteriskByCompanyCode()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            legEnt = new PO_LegalEntities();
            legEnt.SearchForLegalEntityByCompanyCode(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void LegalEntity_SearchingStartsWithAsteriskByCompanyCode()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            legEnt = new PO_LegalEntities();
            legEnt.SearchForLegalEntityByCompanyCode(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void LegalEntity_SearchingEndsAndStartsWithAsteriskByCompanyCode()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            legEnt = new PO_LegalEntities();
            legEnt.SearchForLegalEntityByCompanyCode(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void LegalEntity_SearchingFullNameByCompanyCode()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            legEnt = new PO_LegalEntities();
            legEnt.SearchForLegalEntityByCompanyCode(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
