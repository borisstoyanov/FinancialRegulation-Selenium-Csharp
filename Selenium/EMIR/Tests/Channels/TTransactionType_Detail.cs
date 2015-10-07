using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TTransactionTypes_Detail : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void TransactionType_ViewTransactionTypes()
        {
            storeResults = true;
            PO_TransactionTypesPopUp referenceDatas = PO_Dashboard.GoToTransactionTypePopUp();
            referenceDatas.CreateNewTransactionTypes()
                .Create();
            referenceDatas.VerifyTransactionTypesCreated();
            referenceDatas.ViewTransactionTypesDetails();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
