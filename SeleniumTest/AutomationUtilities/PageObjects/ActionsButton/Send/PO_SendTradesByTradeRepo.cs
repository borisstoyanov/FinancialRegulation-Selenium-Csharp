using AutomationUtilities.Exceptions;
using AutomationUtilities.FieldIDs;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects.SendPO
{
    public class PO_SendTradesByTradeRepo
    {
        public PO_SendTradesByTradeRepo()
        {
            Thread.Sleep(1000);
            String expectedPage = "Send Trades by Account";
            String actualPage = Browser.Browser.Instance.Title.ToString();
            try
            {
                if (!expectedPage.Equals(actualPage))
                {
                    throw new NotOnTheExpectedPageException(expectedPage, actualPage);
                }
            }
            catch (NotOnTheExpectedPageException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one. \nExpected this: " + e.getExpectedPage() + "\nbut got this: " + e.getActualPage());
            }
        }


        public void SelectTradeRepo(string targetSettingTradeRepo)
        {
            new SelectElement(Browser.Browser.Instance.FindElement(By.Id("TradeRepositoryAccount"))).SelectByText(targetSettingTradeRepo);
        }

        public void Send()
        {
            Browser.Browser.ClickByID("Submit");
        }

        public void VerifySendingByTargetSetting(string targetSetting)
        {
            Thread.Sleep(500);

            if (targetSetting.Equals(TargetSettings_SendByTradeRepo.TradeRepo_DTCC))
            {
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send DTCC ETD Trade New Records");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send DTCC ETD Trade Cancel records");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send DTCC ETD Trade Update Records");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send DTCC ETD New Backload Records");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send DTCC ETD Position New Records");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send DTCC ETD Position Cancel Records");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send DTCC OTC Position New Records");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send DTCC ETD Cancel Backload Records");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send DTCC ETD Position Update Records");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send DTCC OTC Position Update Records");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send DTCC OTC Position Cancel Records");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send DTCC OTC Backloads New Records");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send DTCC OTC Backloads Cancel Records");
            }

            if (targetSetting.Equals(TargetSettings_SendByTradeRepo.TradeRepo_REGIS))
            {
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send RegisTR New Trades");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send RegisTR Cancel Trades");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send RegisTR Update Trades");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send RegisTR Backload Positions");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send RegisTR New Positions");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send RegisTR Update Positions");
                Util.CheckIfTextPresented("EMIR Awaiting Send for target setting Send RegisTR Cancel Positions");
            }
        }

        public void CheckIfTradeAvailableForSending(string tradeID, int timeout, string target)
        {
            for (int i = 0; i <= timeout; i++)
            {
                Thread.Sleep(2000);
                if (Util.IsElementPresent(By.XPath("//td[text()='" + tradeID + "']")))
                {
                    break;
                }
                else
                {
                    if (i == timeout)
                    {
                        Test.verificationErrors.Append("Timeout: There is nothing to send.");
                        Assert.Fail("Timeout: There is nothing to send.");
                    }
                    PO_Dashboard.GoToSendTradesByTradeRepo();
                    Thread.Sleep(5000);
                    new SelectElement(Browser.Browser.Instance.FindElement(By.Id("TradeRepositoryAccount"))).SelectByText(target);
                }
            }
        }
    }
}
