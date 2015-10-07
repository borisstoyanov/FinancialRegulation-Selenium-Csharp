using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.ActionsButton.Import;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemitAutomation.Utils;

namespace RemitAutomation.Tests.Actions.ImportOrder
{
    [TestClass]
    public class TImportOrder_GenXML : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsREMITUser();
        }

        [TestCategory("Import"), TestCategory("ActionsUI"), TestCategory("ImportTrade"), TestMethod()]
        public void ImportOrder_GenXML()
        {
            storeResults = true;
            CreateImportFile.GenXMLChained();
            PO_Dashboard.GoToImportOrdersManualSource();
            PO_ImportManualOrdersSource importPage = new PO_ImportManualOrdersSource();
            importPage.ImportREMITGeneralXMLWith()
                .SaveXML().Import();
            importPage.VerifyFileIsUploaded();
            PO_UTISearch.GoTo(Test.UTI, 100);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifyReadyToSend(15);
            Test.result = "Passed";
        }

        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
