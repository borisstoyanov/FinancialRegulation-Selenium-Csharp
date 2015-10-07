using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace MTAutomation.Tests.BusinessDataTab
{
    [TestClass]
    public class MTBusinessataTab_ProductsTests : Test
    {
        bool storeResults = false;
        string searchTerm;
        PO_ProductsPopUp product;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.InitiateBrowser();
            PO_LoginPage login = new PO_LoginPage();
            login.LoginWithTenantA_EMIRUser();

            product = PO_Dashboard.GoToProducts();
            product.CreateNewProduct()
                .Create();
            product.VerifyProductIsCreated();
            product.CloseWindow();
            PO_Dashboard.LogOff();

            login = new PO_LoginPage();
            PO_Dashboard dash = login.LoginWithIEMIRUser2();
            PO_StaticEntitiesAwaitingApproval approvalQueue = dash.GoToStaticEntitiesAwaitingApproval();
            approvalQueue.ApproveStaticEntitie(Test.extRef);
            PO_Dashboard.LogOff();
            
            login.LoginWithTenantB_EMIRUser01();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void MTroduct_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            Thread.Sleep(3000);
            product = PO_Dashboard.GoToProducts();
            product.SearchForProduct(searchTerm);
            Util.CheckIfTextNotPresented(Test.extRef);

            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
