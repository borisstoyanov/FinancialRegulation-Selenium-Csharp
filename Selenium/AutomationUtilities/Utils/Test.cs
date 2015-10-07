using AutomationUtilities.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Text;
using System.Xml;

namespace AutomationUtilities.Utils
{
    public class Test
    {
        public Test()
        {
            SetTradeId();
            verificationErrors = new StringBuilder().Append("");
            instanceURL = Setings.Instance.Url;
            result = "Failed";
            testdate = DateTime.Now.ToString("yyyy-MM-dd");
            xmlDoc = new XmlDocument();
            CollateralPortCode = Util.GetRandomID();
           
        }


        public static String tradeID;
        public static String testInstance;
        public static String build;
        public static StringBuilder verificationErrors;
        public static String browserVersion;
        public static Screenshot screenshot;
        public static String fileName;
        public static String instanceURL;
        public static String absolutePathToImportFile;
        public static String testName;
        public static String result;
        public static String testdate;
        public static String bug_id;
        public static String testID;
        public XmlDocument xmlDoc;
        public static String extRef;
        public static String CollateralPortCode;
        public static String TransactionReference { get; set; }

        public static void SetTestName(TestContext testContext)
        {
            testName = testContext.TestName;
        }

        protected static void SetTestID()
        {
            testID = Util.GetTestID();
            
        }
        
        private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public static void LoginAsRegularUser()
        {
            //try
            {
                InitiateBrowser();
                PO_LoginPage loginPage = new PO_LoginPage();
                PO_Dashboard dash = loginPage.LoginWithRegularUser();
                if (Util.CheckIfPassedAndAbort())
                {
                    AbortTest();
                }
            }
            //catch (Exception e)
            {
             //   Test.verificationErrors.Append(e);
            //    Assert.Fail("There was an exception in LoginMethod\nException: " + Test.verificationErrors);
            }
        }

        public PO_LoginPage LoginAs()
        {
            InitiateBrowser();
            browserVersion = Browser.Browser.GetBrowserVersion();
            return new PO_LoginPage();
        }

        private static void AbortTest()
        {
            TearDown(false);
        }
        public static void TearDown(bool storeResults)
        {
            if (Test.result.Equals("failed") || (Test.result.Equals("Failed")))
            {
                TekeScreeshot();
            }
            try
            {
                Test.build = PO_HelpAbout.Getbuild();
            }
            catch (Exception)
            {
                Test.build = "GetBuild() has thrown an exception";
            }

            Browser.Browser.Quit();
            
            //ClearTestData();

            try
            {
                if (storeResults)
                {
                    //SQLServerUtilities.StoreResults();
                    //SQLServerUtilities.StoreScreenshot();
                }
            }
            catch (Exception)
            {
            }
        }

        private static void TekeScreeshot()
        {
            screenshot = ((ITakesScreenshot)Browser.Browser.Instance).GetScreenshot();
            Util.SaveScreenshot(screenshot);
        }

        public static void MarkTradeAsUsed()
        {
            SQLServerUtilities.MarkTestResultAsUsed(Test.tradeID);
        }

        public static void GetCollateralId()
        {
            int collateralId = SQLServerUtilities.GetCollateralId(STI);
            Browser.Browser.GoToPage("/EMIRCollateral/Edit?ID=" + collateralId.ToString());
        }

        protected static void InitiateBrowser()
        {
            Test.SetTestID();
            Browser.Browser.Init();
            browserVersion = Browser.Browser.GetBrowserVersion();
        }

        private static void ClearTestData()
        {
            try
            {
                SQLServerUtilities.ClearTestData(Test.testName);
            }
            catch(Exception)
            {
            }
        }

        private static String SetTradeId()
        {
            Test.tradeID = Util.GetRandomID();
            Test.UTI = Test.tradeID + "UTI";
            Test.STI = Test.tradeID + "STI";
            return Test.tradeID;
        }

        public static string counterParty { get; set; }

        public static string UTI { get; set; }

        public static string STI { get; set; }

        public static string counterPartyDelegated { get; set; }

        protected static void LoginAsSystemUser()
        {
                InitiateBrowser();
                PO_LoginPage loginPage = new PO_LoginPage();
                PO_Dashboard dash = loginPage.LoginWithSystemUser();
        }

        protected static void LoginAsREMITSysUser()
        {
            InitiateBrowser();
            PO_LoginPage loginPage = new PO_LoginPage();
            PO_Dashboard dash = loginPage.LoginWithREMITSysUser();
        }

        protected static void LoginAsREMITUser()
        {
            InitiateBrowser();
            PO_LoginPage loginPage = new PO_LoginPage();
            PO_Dashboard dash = loginPage.LoginWithREMITUser();
        }
    }
}
