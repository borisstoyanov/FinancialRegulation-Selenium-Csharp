using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.Maintanance.BusinessData.ProdContractSer;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemitAutomation.Tests.Products.ProductContractSeries
{
    [TestClass]
    public class TProductContractSeries_SearchTests : Test
    {
        string searchTerm;
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
            PO_ProductContractSeriesPopUp prodCon = PO_Dashboard.GoToProductContractSer();
            prodCon.CreateNewProduct()
                .Create();
            prodCon.VerifyProductSeriesIsCreated();
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void ProductSer_SearchingEndsWithAsterisk()
        {
            storeResults = true;
            searchTerm = Test.extRef.Remove(Test.extRef.Length - 3) + "*";
            PO_ProductContractSeriesPopUp prodCon = new PO_ProductContractSeriesPopUp();
            prodCon.SearchForProductSeries(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void ProductSer_SearchingStartsWithAsterisk()
        {
            storeResults = true;
            searchTerm = "*" + Test.extRef.Substring(1);
            PO_ProductContractSeriesPopUp prodCon = new PO_ProductContractSeriesPopUp();
            prodCon.SearchForProductSeries(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void ProductSer_SearchingEndsAndStartsWithAsterisk()
        {
            storeResults = true;
            string substracted = "*" + Test.extRef.Substring(1);
            searchTerm = substracted.Remove(substracted.Length - 2) + "*";
            PO_ProductContractSeriesPopUp prodCon = new PO_ProductContractSeriesPopUp();
            prodCon.SearchForProductSeries(searchTerm);
            Util.CheckIfTextPresented(Test.extRef);
            Test.result = "Passed";
        }

        [TestCategory("BusinessDataTab"), TestCategory("Maintenance"), TestCategory("RegressionTesting"), TestMethod()]
        public void ProductSer_SearchingFullName()
        {
            storeResults = true;
            searchTerm = Test.extRef;
            PO_ProductContractSeriesPopUp prodCon = new PO_ProductContractSeriesPopUp();
            prodCon.SearchForProductSeries(searchTerm+"*");
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
