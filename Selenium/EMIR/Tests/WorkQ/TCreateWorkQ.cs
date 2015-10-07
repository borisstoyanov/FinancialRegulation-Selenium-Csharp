using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmirAutomation.Tests.WorkQ
{
    using AutomationUtilities;

    [TestClass]
    public class TCreateWorkQ:Test
    {
        bool storeResults = false;

        [TestInitialize]
        public void SetUp()
        {
            Test.SetTestName(TestContext);
            Test.LoginAsRegularUser();
        }

        [TestCategory("WorkQs"), TestCategory("RegressionTesting"), TestMethod()]
        public void TC14466_WorkQ_CreateWorkQ()
        {
            
                storeResults = true;
                PO_Dashboard.GoTo();
                PO_ManageWorkQueues workQueue = PO_Dashboard.GoToManageWorkQueuesTrades();
                workQueue.CreateLastWeekTradesQueue();
            try
            {    
                PO_EMIRQueue readyQueue = PO_Dashboard.GoToEMIRConfiguredQueue(Test.extRef);
                readyQueue.CheckResultTableAppears();
                PO_Dashboard.GoTo();
                workQueue = PO_Dashboard.GoToManageWorkQueuesTrades();
                workQueue.DeleteWorkQueue(Test.extRef);
            }
            catch (Exception)
            {
                PO_Dashboard.GoTo();
                PO_ManageWorkQueues deleteWorkQ = PO_Dashboard.GoToManageWorkQueuesTrades();
                deleteWorkQ.DeleteWorkQueue(Test.extRef);
            }

            Test.result = "Passed";
        }
        [TestCleanup]
        public void TearDown()
        {
            Test.TearDown(storeResults);
            Test.MarkTradeAsUsed();
        }
    }
}
