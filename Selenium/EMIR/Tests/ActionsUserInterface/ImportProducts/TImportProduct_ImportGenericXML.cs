using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.ImportManualSourcePO;
using AutomationUtilities.Utils;
using EmirAutomation.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutoamtion.Tests.ImportProducts
{
    [TestClass]
    public class TImportProduct_ImportGenericXML : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportProduct"), TestMethod()]
        public void TC14464_ImportProduct_CSVImporter()
        {
            storeResults = true;
            CreateImportFile.Product_CSVImporter();
            PO_ImportProductManualSource importProduct = PO_Dashboard.GoToImportProductManualSource();
            importProduct.ImportCSVImporter()
                .Import();
            importProduct.VerifyFileIsUploaded();
            PO_ProductsPopUp products = PO_Dashboard.GoToProducts();
            products.WaitForProductImport(30);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
