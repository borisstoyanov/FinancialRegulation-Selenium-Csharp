using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_EMIRQueue
    {
        public PO_EMIRQueue(string workQueueName)
        {
            try
            {
                Util.WaitForElementPresentByXPath("//li[contains(@title,'" + workQueueName + "')]", 60);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }


        public void SearchByTradeID(string UTI)
        {
            Browser.Browser.ClickByXPath("//div[contains(@id,'_FilterToggle')]");
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.XPath("//input[@value='Trade Id']")).SendKeys(UTI);
            Browser.Browser.Instance.FindElement(By.XPath("//input[@value='Trade Id']")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            try
            {
                Util.WaitForElementVisibleByXPath("//td[text()='" + UTI + "']", 30);

            }
            catch (NoSuchElementException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("UTI was not found in the results.");
            }
            Thread.Sleep(2000);
        }

        public void SearchBySourceTradeID(string UTI)
        {
            Browser.Browser.ClickByXPath("//div[contains(@id,'_FilterToggle')]");
            Thread.Sleep(5000);
            Browser.Browser.Instance.FindElement(By.XPath("//input[@value='Source Trade ID']")).SendKeys(UTI);
            Browser.Browser.Instance.FindElement(By.XPath("//input[@value='Source Trade ID']")).SendKeys(Keys.Enter);
            Thread.Sleep(5000);
            try
            {
                Util.WaitForElementVisibleByXPath("//td[text()='" + UTI + "']", 90);
            }
            catch (NoSuchElementException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("UTI was not found in the results.");
            }
            Thread.Sleep(5000);
        }

        public void SearchBySourceTradeIDRecordNotFound(string UTI)
        {
            Browser.Browser.ClickByXPath("//div[contains(@id,'_FilterToggle')]");
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.XPath("//input[@value='Source Trade ID']")).SendKeys(UTI);
            Browser.Browser.Instance.FindElement(By.XPath("//input[@value='Source Trade ID']")).SendKeys(Keys.Enter);
            Thread.Sleep(10000);
            try
            {
                Browser.Browser.Instance.FindElement(By.XPath("//td[text()='" + UTI + "']")).SendKeys(UTI);

                Test.verificationErrors.Append("Trade visible when should be inaccessible");
                Assert.Fail("UTI was not found in the results.");
            }
            catch (NoSuchElementException)
            {
            }
        }

        public void SearchByEmirReference(string emirReference)
        {
            ToggleHidden();
            Browser.Browser.Instance.FindElement(By.XPath("//input[@value='Reference']")).SendKeys(emirReference);
            Browser.Browser.Instance.FindElement(By.XPath("//input[@value='Reference']")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            try
            {
                Util.WaitForElementVisibleByXPath("//td[text()='" + emirReference + "']", 60);

            }
            catch (NoSuchElementException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("EmirReference was not found in the results.");
            }
            Thread.Sleep(2000);
        }

        private void ToggleHidden()
        {                
            string classAttribute = Browser.Browser.Instance.FindElement(By.XPath("//div[contains(@id,'_FilterToggle')]")).GetAttribute("class");

            if (classAttribute.Contains("FilterHidden"))
            {
                Browser.Browser.ClickByXPath("//div[contains(@id,'_FilterToggle')]");
                Thread.Sleep(2000);
            }
        }

        public void GetEmirReference(string p)
        {
            SearchByTradeID(p);
            Test.TransactionReference = Browser.Browser.Instance.FindElement(By.XPath("//td[contains(text(),'EMIR')]")).Text;
        }

        public void SortColumnsAsc(string columnName)
        {
            if (!Util.IsElementPresent(By.XPath("//th[text()='" + columnName + "'][contains(@class,'sorting_desc')]")) || !Util.IsElementPresent(By.XPath("//th[text()='" + columnName + "'][@class='ImpendiumGridTableHeaderColumn sorting']")))
            {
                Browser.Browser.ClickByXPath("//th[text()='" + columnName + "']");
            }
            Thread.Sleep(2000);
            string firstResult = Browser.Browser.Instance.FindElement(By.XPath("//tbody//tr[1]//td[3]")).Text;
            string secondResult = Browser.Browser.Instance.FindElement(By.XPath("//tbody//tr[2]//td[3]")).Text;
            DateTime dt1 = Convert.ToDateTime(firstResult);
            DateTime dt2 = Convert.ToDateTime(secondResult);

            int result = DateTime.Compare(dt1, dt2);

            if (result > 0) 
            {
                Test.verificationErrors.Append("1st date in results is not smaller than the 2nd. Ascending sorting is not working");
                Assert.Fail("1st date in results is not smaller than the 2nd. Ascending sorting is not working");
            }
        }



        public void SortColumnsDesc(string columnName)
        {
            if (!Util.IsElementPresent(By.XPath("//th[text()='" + columnName + "'][contains(@class,'sorting_asc')]")) || !Util.IsElementPresent(By.XPath("//th[text()='" + columnName + "'][@class='ImpendiumGridTableHeaderColumn sorting']")))
            {
                Browser.Browser.ClickByXPath("//th[text()='" + columnName + "']");
                Thread.Sleep(1000);
                Browser.Browser.ClickByXPath("//th[text()='" + columnName + "']");
            }
            Thread.Sleep(2000);
            string firstResult = Browser.Browser.Instance.FindElement(By.XPath("//tbody//tr[1]//td[3]")).Text;
            string secondResult = Browser.Browser.Instance.FindElement(By.XPath("//tbody//tr[2]//td[3]")).Text;
            DateTime dt1 = Convert.ToDateTime(firstResult);
            DateTime dt2 = Convert.ToDateTime(secondResult);

            int result = DateTime.Compare(dt1, dt2);

            if (result < 0)
            {
                Test.verificationErrors.Append("1st date in results is not greater than the 2nd. Descending sorting is not working");
                Assert.Fail("1st date in results is not greater than the 2nd. Descending sorting is not working");
            }
        }

        public void ClickNext()
        {
            Thread.Sleep(2000);
            int first = Int32.Parse(Browser.Browser.Instance.FindElement(By.XPath("//a[@class='paginate_active']")).Text);
            Browser.Browser.ClickByXPath("//a[contains(@id,'_next')]");
            Thread.Sleep(2000);
            int second = Int32.Parse(Browser.Browser.Instance.FindElement(By.XPath("//a[@class='paginate_active']")).Text);
            if (!(second - first == 1))
            {
                Test.verificationErrors.Append("Clicking Next did not jumped to next page");
                Assert.Fail("Clicking Next did not jumped to next page");
            }
        }

        public void ClickFirst()
        {
            Thread.Sleep(2000);
            ClickLast();
            Browser.Browser.ClickByXPath("//a[contains(@id,'_first')]");
            Thread.Sleep(2000);
            Util.WaitForElementPresentByXPath("//div[contains(@id,'_paginate')]//span//a[1][@class='paginate_active']", 10);
        }

        public void ClickLast()
        {
            Thread.Sleep(2000);
            Browser.Browser.ClickByXPath("//a[contains(@id,'_last')]");
            Thread.Sleep(2000);
            Util.WaitForElementPresentByXPath("//div[contains(@id,'_paginate')]//span//a[5][@class='paginate_active']", 10);
        }

        public void ClickBack()
        {
            Thread.Sleep(2000);
            Browser.Browser.ClickByXPath("//a[contains(@id,'_next')]");
            Thread.Sleep(2000);
            int first = Int32.Parse(Browser.Browser.Instance.FindElement(By.XPath("//a[@class='paginate_active']")).Text);
            Browser.Browser.ClickByXPath("//a[contains(@id,'_previous')]");
            Thread.Sleep(2000);
            int second = Int32.Parse(Browser.Browser.Instance.FindElement(By.XPath("//a[@class='paginate_active']")).Text);
            if (!(first - second == 1))
            {
                Test.verificationErrors.Append("Clicking Back did not jumped to previous page");
                Assert.Fail("Clicking Back did not jumped to previous page");
            }
        }

        public void CheckResultTableAppears()
        {
            Thread.Sleep(2000);
            if (!Util.IsElementPresent(By.XPath("//table[contains(@class,'ImpendiumGridTable')]")))
            {
                Test.verificationErrors.Append("Result Table does not appear");
                Assert.Fail("Result Table does not appear");
                
            }
        }

        public void VerifyTradeNotVisibleInTheQueue(string UTI)
        {
            Browser.Browser.ClickByXPath("//div[contains(@id,'_FilterToggle')]");
            Thread.Sleep(2000);
            Browser.Browser.Instance.FindElement(By.XPath("//input[@value='Unique Trade Id']")).SendKeys(UTI);
            Browser.Browser.Instance.FindElement(By.XPath("//input[@value='Unique Trade Id']")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            
            if (!Util.IsElementPresent(By.XPath("//td[text()='" + UTI + "']")))
            {
            }
            else
            {
                Test.verificationErrors.Append("Timeout: Trade was Visible.");
                Assert.Fail("Timeout: Trade was Visible.");
            }
            Thread.Sleep(2000);
        }

        public PO_EditEmirTransactionPage OpenFirstRecord()
        {
            Browser.Browser.ClickByXPath("//table[contains(@id,'ImpendiumGridTable')]//tbody//tr[1]");
            return new PO_EditEmirTransactionPage();
        }
    }
}
