using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmirAutomation.Tests.ChannelsTab
{
    [TestClass]
    public class TTransactionTypes_Edit : Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsSystemUser();
        }

        [TestCategory("System"), TestCategory("Maintenance"), TestCategory("Channels"), TestCategory("RegressionTesting"), TestMethod()]
        public void TransactionType_EditTransactionTypes()
        {
            storeResults = true;
            PO_TransactionTypesPopUp referenceDatas = PO_Dashboard.GoToTransactionTypePopUp();
            referenceDatas.CreateNewTransactionTypes()
                .Create();
            referenceDatas.VerifyTransactionTypesCreated();
            referenceDatas.EditTransactionTypes()
                .Save();
            referenceDatas.VerifyTransactionTypesEdited();
            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
        }
    }
}
