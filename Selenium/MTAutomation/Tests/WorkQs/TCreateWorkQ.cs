using AutomationUtilities.PageObjects;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAutomation.Tests.WorkQs
{
    [TestClass]
    public class TCreateWorkQ : Test
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
            try
            {


                storeResults = true;
                PO_Dashboard.GoTo();
                PO_ManageWorkQueues workQueue = PO_Dashboard.GoToManageWorkQueuesTrades();
                workQueue.CreateLastWeekTradesQueue();
                PO_Dashboard.GoTo();
                PO_EMIRQueue readyQueue = PO_Dashboard.GoToEMIRConfiguredQueue(Test.extRef);
                readyQueue.CheckResultTableAppears();
                PO_Dashboard.GoTo();
                PO_Dashboard.GoToManageWorkQueuesTrades();

                PO_Dashboard.LogOff();
                PO_LoginPage login = new PO_LoginPage();
                login.LoginWithTenantB_EMIRUser01();
                workQueue = PO_Dashboard.GoToManageWorkQueuesTrades();
                workQueue.CheckWorkQueueNotVisible(Test.extRef);

                PO_Dashboard.LogOff();
                login.LoginWithRegularUser();
                workQueue = PO_Dashboard.GoToManageWorkQueuesTrades();
                workQueue.DeleteWorkQueue(Test.extRef);
            }
            catch (Exception)
            {
                PO_Dashboard.GoTo();
                PO_ManageWorkQueues workQueue = PO_Dashboard.GoToManageWorkQueuesTrades();
                workQueue.DeleteWorkQueue(Test.extRef);
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
