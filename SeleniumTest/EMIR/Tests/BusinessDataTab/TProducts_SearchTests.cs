using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class TProducts_SearchTests : Test
    {
        bool storeResults = false;
        string searchTerm;
        PO_ProductsPopUp product;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
            product = PO_Dashboard.GoToProducts();
            product.CreateNewProduct()
                .Create();
            product.VerifyProductIsCreated();
            product.CloseWindow();
            PO_Dashboard.LogOff();
            PO_LoginPage login = new PO_LoginPage();
            PO_Dashboard dash = login.LoginWithIEMIRUser2();
            PO_StaticEntitiesAwaitingApproval approvalQueue = dash.GoToStaticEntitiesAwaitingApproval();
            approvalQueue.ApproveStaticEntitie(Test.extRef);
            PO_Dashboard.LogOff();
            Test.LoginAsRegularUser();
            PO_Dashboard.GoToProducts();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Product_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            product = new PO_ProductsPopUp();
            product.SearchForProduct(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);

            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Product_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            product = new PO_ProductsPopUp();
            product.SearchForProduct(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);

            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Product_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            product = new PO_ProductsPopUp();
            product.SearchForProduct(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);

            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void Product_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            product = new PO_ProductsPopUp();
            product.SearchForProduct(searchTerm);
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
