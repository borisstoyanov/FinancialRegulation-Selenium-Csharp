using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutomationUtilities.Utils;
using AutomationUtilities.PageObjects.BicPO;
using AutomationUtilities.PageObjects;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TBic_SearchBICCodeTests : Test
    {
        bool storeResults = false;
        string searchTerm;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            PO_BICPopUp bic = PO_Dashboard.GoToBICPopUp();
            bic.CreateNewBicCode()
                .Create();
            bic.VerifyBicCodeCreated();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void BICCode_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_BICPopUp bic = new PO_BICPopUp();
            bic.SearchBicCodeByName(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void BICCode_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_BICPopUp bic = new PO_BICPopUp();
            bic.SearchBicCodeByName(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }
        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void BICCode_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_BICPopUp bic = new PO_BICPopUp();
            bic.SearchBicCodeByName(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }
        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void BICCode_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_BICPopUp bic = new PO_BICPopUp();
            bic.SearchBicCodeByName(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void BICCode_SearchingEndsWithAsteriskByBicCode()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_BICPopUp bic = new PO_BICPopUp();
            bic.SearchBicCodeByBicCode(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void BICCode_SearchingStartsWithAsteriskByBicCode()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_BICPopUp bic = new PO_BICPopUp();
            bic.SearchBicCodeByBicCode(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }
        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void BICCode_SearchingEndsAndStartsWithAsteriskByBicCode()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_BICPopUp bic = new PO_BICPopUp();
            bic.SearchBicCodeByBicCode(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }
        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void BICCode_SearchingFullNameByBicCode()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_BICPopUp bic = new PO_BICPopUp();
            bic.SearchBicCodeByBicCode(searchTerm);
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
