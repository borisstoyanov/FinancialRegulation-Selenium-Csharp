using AutomationUtilities.PageObjects.Audit;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace AutomationUtilities.PageObjects
{
    public class PO_EditEmirTransactionPage
    {
        public PO_EditEmirTransactionPage()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//title[contains(text(),'Transaction')]", 15);
            }
            catch (Exception e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
            GetTransactionReference();
        }

        private void GetTransactionReference()
        {
            Test.TransactionReference = Browser.Browser.Instance.FindElement(By.XPath("//li[@title='Click to Refresh Transaction']")).Text;
        }

        public void VerifyReadyToSend()
        {
            Util.WaitForElementPresentByXPath("//td[contains(text(),'Ready To Send')]", 15);
        }

        /*
        public void GoTo(string tradeID, int timeout)
        {
            Util.RemoveDisplay("utiSearch");
            Browser.Browser.Instance.FindElement(By.XPath("//input[@class='utiSearch']")).SendKeys("retest14758");
            for (int i = 0; i <= timeout; i++)
            {
                if (Util.IsElementPresent(By.XPath("//title[contains(text(),'Edit EMIR Transaction')]")))
                {
                    break;
                }
                else
                {
                    if (i == timeout)
                    {
                        Test.verificationErrors.Append("Timeout: Trade was not found/imported.");
                        Test.TearDown(true);
                        Assert.Fail("Timeout: Trade was not found/imported.");
                    }
                    Browser.Browser.Instance.FindElement(By.XPath("//input[@class='utiSearch']")).SendKeys(Keys.Return);
                    Thread.Sleep(5000);
                }
            }
        }
        */

        public void VerifiTradeNotReachable(string tradeID)
        {
            Util.RemoveDisplay("utiSearch");
            Browser.Browser.Instance.FindElement(By.XPath("//input[@class='utiSearch']")).SendKeys(tradeID + "STI");
            Browser.Browser.Instance.FindElement(By.XPath("//input[@class='utiSearch']")).SendKeys(Keys.Return);
            Thread.Sleep(5000);
            
            if (!Util.IsElementPresent(By.XPath("//title[contains(text(),'Edit EMIR Transaction')]")))
            {

            }
            else
            {
                Test.verificationErrors.Append("Timeout: Trade was not found/imported.");
                Assert.Fail("Timeout: Trade was not found/imported.");
            }
        }

        public void EditNotationAmount(String amount)
        {
            Browser.Browser.ClickByXPath("//div[text()='Trade']");
            IWebElement natAmount = Browser.Browser.Instance.FindElement(By.Id("30_Trade_NotionalAmount_ExternalDiv"));
            Actions action = new Actions(Browser.Browser.Instance);
            action.DoubleClick(natAmount);
            action.Perform();
            Browser.Browser.Instance.FindElement(By.XPath("//form[@class='form-inline editableform']//input[@type='text']")).Clear();
            Browser.Browser.Instance.FindElement(By.XPath("//form[@class='form-inline editableform']//input[@type='text']")).SendKeys(amount);
            Browser.Browser.ClickByXPath("//button[@class='editable-submit ui-button ui-widget ui-state-default ui-corner-all ui-button-icon-only EMIRButtonStyle']");

            Browser.Browser.ClickByID("EditValidateButton");
        }

        public void EditCounterparty(String directlyLinked, string clearingMember)
        {
            Browser.Browser.ClickByXPath("//div[text()='Counterparty']");
            IWebElement natAmount = Browser.Browser.Instance.FindElement(By.Id("10_Counterparty_DirectlyLinkedtoCommercialActivity_ExternalDiv"));
            IWebElement clearingMemberCtrl = Browser.Browser.Instance.FindElement(By.Id("10_Counterparty_ClearingMember_DerivedDiv"));

            Actions action = new Actions(Browser.Browser.Instance);
            action.DoubleClick(natAmount);
            action.Perform();
            Thread.Sleep(1000);
            Browser.Browser.Instance.FindElement(By.XPath("//form[@class='form-inline editableform']//input[@type='text']")).SendKeys(directlyLinked);
            Thread.Sleep(1000);



            IWebElement submitBtn1 = Browser.Browser.Instance.FindElement(By.XPath("//button[@type='submit']"));
            action.DoubleClick(submitBtn1);
            action.DoubleClick(submitBtn1);
            action.Perform();
            Thread.Sleep(10000);

            
            action.DoubleClick(clearingMemberCtrl);
            action.Perform();
            Thread.Sleep(1000);
            Browser.Browser.Instance.FindElement(By.XPath("//form[@class='form-inline editableform']//input[@type='text']")).SendKeys(clearingMember);
            Thread.Sleep(1000);
            
            IWebElement submitBtn = Browser.Browser.Instance.FindElement(By.XPath("//button[@type='submit']"));
            action.DoubleClick(submitBtn);
            action.DoubleClick(submitBtn);
            action.Perform();
            Thread.Sleep(10000);

            Browser.Browser.ClickByID("EditValidateButton");
        }

        public void EditProduct(String amount)
        {
            Browser.Browser.ClickByXPath("//div[text()='Product']");
            IWebElement natAmount = Browser.Browser.Instance.FindElement(By.Id("40_Product_DeliveryType_InternalDiv"));
            Actions action = new Actions(Browser.Browser.Instance);
            action.DoubleClick(natAmount);
            action.Perform();
            Thread.Sleep(1000);
            Browser.Browser.Instance.FindElement(By.XPath("//form[@class='form-inline editableform']//input[@type='text']")).Clear();
            Thread.Sleep(1000);
            Browser.Browser.Instance.FindElement(By.XPath("//form[@class='form-inline editableform']//input[@type='text']")).SendKeys(amount + Keys.Return);
            Thread.Sleep(1000);

            IWebElement submitBtn = Browser.Browser.Instance.FindElement(By.XPath("//button[@type='submit']"));
            action.DoubleClick(submitBtn);
            action.DoubleClick(submitBtn);
            action.Perform();
            Thread.Sleep(10000);

     //       Browser.Browser.ClickByID("EditValidateButton");
        }

        public void EditConfirmation(String amount)
        {
            Browser.Browser.ClickByXPath("//div[text()='Confirmation']");
            IWebElement natAmount = Browser.Browser.Instance.FindElement(By.Id("50_Confirmation_ConfirmationMeans_InternalDiv"));

            Actions action = new Actions(Browser.Browser.Instance);
            action.DoubleClick(natAmount);
            action.Perform();
            Thread.Sleep(1000);   
            Browser.Browser.Instance.FindElement(By.XPath("//form[@class='form-inline editableform']//input[@type='text']")).Clear();
            Thread.Sleep(1000);
            Browser.Browser.Instance.FindElement(By.XPath("//form[@class='form-inline editableform']//input[@type='text']")).SendKeys(amount + Keys.Return);
            Thread.Sleep(1000);

            IWebElement submitBtn= Browser.Browser.Instance.FindElement(By.XPath("//button[@type='submit']"));
            action.DoubleClick(submitBtn);
            action.DoubleClick(submitBtn);
            action.Perform();
            Thread.Sleep(10000);

            Browser.Browser.ClickByID("EditValidateButton");
        }

        public void EditClearing(String amount)
        {
            Browser.Browser.ClickByXPath("//div[text()='Clearing']");
            IWebElement natAmount = Browser.Browser.Instance.FindElement(By.Id("60_Clearing_CentralCounterparty_ExternalDiv"));
            IWebElement DateTimeStamp = Browser.Browser.Instance.FindElement(By.Id("60_Clearing_ClearingTimestamp_ExternalDiv"));

            Actions action = new Actions(Browser.Browser.Instance);
            action.DoubleClick(natAmount);
            action.Perform();
            Thread.Sleep(1000);
            Browser.Browser.Instance.FindElement(By.XPath("//form[@class='form-inline editableform']//input[@type='text']")).SendKeys(amount);
            Thread.Sleep(1000);
            Browser.Browser.ClickByXPath("//button[@class='editable-submit ui-button ui-widget ui-state-default ui-corner-all ui-button-icon-only EMIRButtonStyle']");
            Thread.Sleep(1000);
            
            IWebElement submitBtn = Browser.Browser.Instance.FindElement(By.XPath("//button[@type='submit']"));
            action.DoubleClick(submitBtn);
            action.DoubleClick(submitBtn);
            action.Perform();

            Browser.Browser.ClickByID("EditValidateButton");
        }

        public void EditValuation(String amount)
        {
            Browser.Browser.ClickByXPath("//div[text()='Valuation']");
            IWebElement natAmount = Browser.Browser.Instance.FindElement(By.Id("70_Valuation_ValuationType_ExternalDiv"));
            Actions action = new Actions(Browser.Browser.Instance);
            action.DoubleClick(natAmount);
            action.Perform();
            Browser.Browser.Instance.FindElement(By.XPath("//form[@class='form-inline editableform']//input[@type='text']")).SendKeys(amount + Keys.Return + Keys.Return);
            Thread.Sleep(2000);

            IWebElement submitBtn = Browser.Browser.Instance.FindElement(By.XPath("//button[@type='submit']"));
            action.DoubleClick(submitBtn);
            action.DoubleClick(submitBtn);
            action.Perform();
        }

        public void VerifyCollateralAndValuationFileIsImported(int timeout)
        {
            string testText = "//span[contains(text(),'" + Test.UTI + "')]";
            for (int i = 0; i <= timeout; i++)
            {
                if (Util.IsOneOfElementsPresented("//span[contains(text(),'Collateral Awaiting Data')]", testText))
                {
                    break;
                }
                else
                {
                    if (i == timeout)
                    {
                        Test.verificationErrors.Append("Collateral or Valuation were not imported successfully").ToString();
                        Assert.Fail("Collateral or Valuation were not imported successfully");
                    }
                    Browser.Browser.Instance.Navigate().Refresh();
                    Thread.Sleep(5000);
                }
            }
        }

        public void GoToCollateralSection()
        {
            Browser.Browser.ClickByXPath("//div[text()='Collateral']");
        }

        public void GoToValuationSection()
        {
            Browser.Browser.ClickByXPath("//div[text()='Valuation']");
        }

        public void VerifyDelegatedCollateralReadyToSend(int timeout)
        {
            for (int i = 0; i <= timeout; i++)
            {
                Browser.Browser.Instance.FindElement(By.Name("tabPanelTab-DelegatedCollateral")).Click();
                Thread.Sleep(1000);
                if (Util.IsOneOfElementsPresented("//span[contains(text(),'Ready To Send')]", "//span[contains(text(),'Confirmation')]"))
                {
                    break;
                }
                else
                {
                    if (i == timeout)
                    {
                        Test.verificationErrors.Append("Collateral or Valuation were not imported successfully");
                        Assert.Fail("Collateral or Valuation were not imported successfully");
                    }
                    Browser.Browser.Instance.Navigate().Refresh();
                    Thread.Sleep(4000);
                }
            }
        }

        public void VerifyDelegatedValuationFileIsImported(int timeout)
        {
            for (int i = 0; i <= timeout; i++)
            {
                Browser.Browser.Instance.FindElement(By.Name("tabPanelTab-DelegatedValuation")).Click();
                Thread.Sleep(1000);
                if (Util.IsOneOfElementsPresented("//span[contains(text(),'Ready To Send')]", "//span[contains(text(),'Confirmation')]"))
                {
                    break;
                }
                else
                {
                    if (i == timeout)
                    {
                        Test.verificationErrors.Append("Collateral or Valuation were not imported successfully");
                        Assert.Fail("Collateral or Valuation were not imported successfully");
                    }
                    Browser.Browser.Instance.Navigate().Refresh();
                    Thread.Sleep(4000);
                }
            }
        }

        public void VerifySendSuccessfully(int timeout)
        {
            for (int i = 0; i <= timeout; i++)
            {
                Thread.Sleep(1000);
                if (Util.IsElementPresent(By.XPath("//*[contains(text(),'Sent Successfully')]")))
                {
                    break;
                }
                else
                {
                    if (i == timeout)
                    {
                        Test.verificationErrors.Append("Trade/position was not send successully");
                        Assert.Fail("Trade/position was not send successully");
                    }
                    Browser.Browser.Instance.Navigate().Refresh();
                    Thread.Sleep(4000);
                }
            }
        }

        public void VerifyTransactionEdited(int timeout)
        {
            for (int i = 0; i <= timeout; i++)
            {
                Thread.Sleep(1000);
                if (Util.IsElementPresent(By.XPath("//*[contains(text(),'Transaction Edited')]")))
                {
                    break;
                }
                else
                {
                    if (i == timeout)
                    {
                        Test.verificationErrors.Append("Status did not updated to EMIR Transaction Edited");
                        Assert.Fail("Status did not updated to EMIR Transaction Edited");
                    }
                    Browser.Browser.Instance.Navigate().Refresh();
                    Thread.Sleep(4000);
                }
            }
        }

        public void VerifyReadyToSend(int timeout)
        {
            for (int i = 0; i <= timeout; i++)
            {
                Thread.Sleep(1000);
                if (Util.IsElementPresent(By.XPath("//*[contains(text(),'Ready To Send')]")))
                {
                    break;
                }
                else
                {
                    if (Util.IsElementPresent(By.XPath("//*[contains(text(),'Static Issue')]")))
                    {
                        Test.verificationErrors.Append("Static Issue");
                        Assert.Fail("Static Issue");
                    }
                    if (i == timeout)
                    {
                        Test.verificationErrors.Append("Status did not updated to EMIR Ready To Send");
                        Assert.Fail("Status did not updated to EMIR Ready To Send");
                    }
                    Browser.Browser.Instance.Navigate().Refresh();
                    Thread.Sleep(4000);
                }
            }
        }

        public void VerifyEMIRConfirmed()
        {
            while (Util.IsElementPresent(By.XPath("//*[contains(text(),'Sent Successfully')]")))
            {
                Thread.Sleep(1000);
                Browser.Browser.Instance.Navigate().Refresh();
                Thread.Sleep(4000);
            }               
            Util.WaitForElementVisibleByXPath("//*[contains(text(),'Confirmed')]", 10);
        }

        public void VerifyStatusStaticIssues()
        {
            Util.WaitForElementPresentByXPath("//*[contains(text(),'Static Issue')]", 15);
        }

        public void EditTradeAttributeWithAutocompletion(string tab, string attributeID, string value)
        {
            Browser.Browser.ClickByXPath("//div[text()='"+tab+"']");
            IWebElement natAmount = Browser.Browser.Instance.FindElement(By.Id(attributeID));
            Actions action = new Actions(Browser.Browser.Instance);
            action.DoubleClick(natAmount);
            action.Perform();
            Browser.Browser.Instance.FindElement(By.XPath("//form[@class='form-inline editableform']//input[@type='text']")).Clear();
            Browser.Browser.Instance.FindElement(By.XPath("//form[@class='form-inline editableform']//input[@type='text']")).SendKeys(value);
            Util.WaitForElementVisibleByXPath("//ul[contains(@class,'ui-autocomplete')]//a[contains(text(),'"+value+"')]", 15);
            Browser.Browser.ClickByXPath("//ul[contains(@class,'ui-autocomplete')]//a[contains(text(),'" + value + "')]");
            Thread.Sleep(500);
            Browser.Browser.ClickByXPath("//button[@class='editable-submit ui-button ui-widget ui-state-default ui-corner-all ui-button-icon-only EMIRButtonStyle']");
        }
        public void ValidateEditing()
        {
            Browser.Browser.ClickByID("EditValidateButton");
            VerifyReadyToSend();
        }



        public void VerifyEditingNotPossible()
        {
            Browser.Browser.ClickByXPath("//div[text()='Trade']");
            IWebElement natAmount = Browser.Browser.Instance.FindElement(By.Id("30_Trade_NotionalAmount_ExternalDiv"));
            Actions action = new Actions(Browser.Browser.Instance);
            action.DoubleClick(natAmount);
            action.Perform();

            if (!Util.IsElementVisible(By.XPath("//form[@class='form-inline editableform']//input[@type='text']")))
            {

            }
            else
            {
                Assert.Fail("Trade can be edited");
            }
        }

        public void VerifySending(int timeout)
        {
            for (int i = 0; i <= timeout; i++)
            {
                Thread.Sleep(1000);
                if (Util.IsElementPresent(By.XPath("//*[contains(text(),'Sending')]")))
                {
                    break;
                }
                else
                {
                    if (i == timeout)
                    {
                        Test.verificationErrors.Append("Trade/position was not send successully");
                        Assert.Fail("Trade/position was not send successully");
                    }
                    Browser.Browser.Instance.Navigate().Refresh();
                    Thread.Sleep(4000);
                }
            }
        }

        public void VerifyRepairRequired(int timeout)
        {
            for (int i = 0; i <= timeout; i++)
            {
                Thread.Sleep(1000);
                if (Util.IsElementPresent(By.XPath("//*[contains(text(),'Repair Required')]")))
                {
                    break;
                }
                else
                {
                    if (i == timeout)
                    {
                        Test.verificationErrors.Append("Status did not updated to EMIR Ready To Send");
                        Assert.Fail("Status did not updated to EMIR Repear required");
                    }
                    Browser.Browser.Instance.Navigate().Refresh();
                    Thread.Sleep(4000);
                }
            }
        }

        public void VerifyStaticIssue(int timeout)
        {
            for (int i = 0; i <= timeout; i++)
            {
                Thread.Sleep(1000);
                if (Util.IsElementPresent(By.XPath("//*[contains(text(),'Static Issue')]")))
                {
                    break;
                }
                else
                {
                    if (i == timeout)
                    {
                        Test.verificationErrors.Append("Status did not updated to Static Issue");
                        Assert.Fail("Status did not updated to EMIR Repear required");
                    }
                    Browser.Browser.Instance.Navigate().Refresh();
                    Thread.Sleep(4000);
                }
            }
        }

        public void VerifyError(int timeout)
        {
        
            for (int i = 0; i <= timeout; i++)
            {
                Thread.Sleep(1000);
                if (Util.IsElementPresent(By.XPath("//*[contains(text(),'Error')]")))
                {
                    break;
                }
                else
                {
                    if (i == timeout)
                    {
                        Test.verificationErrors.Append("Status did not updated to Error");
                        Assert.Fail("Status did not updated to Error");
                    }
                    Browser.Browser.Instance.Navigate().Refresh();
                    Thread.Sleep(4000);
                }
            }
        }

        public void VerifyStaticIssue(int timeout, string staticIssueText)
        {
            for (int i = 0; i <= timeout; i++)
            {
                Thread.Sleep(1000);
                if (Util.IsElementPresent(By.XPath("//*[contains(text(),'Static Issue')]")))
                {
                    PO_ActionButton.GoToAuditTrade();
                    PO_AuditTradePopUp.CheckStaticIssue(staticIssueText);
                    break;
                }
                else
                {
                    if (Util.IsElementPresent(By.XPath("//*[contains(text(),'Ready To Send')]")))
                    {
                        Test.verificationErrors.Append("It's Ready To Send");
                        Assert.Fail("Didn't get Static Issue");
                    }
                    if (i == timeout)
                    {
                        Test.verificationErrors.Append("Status did not updated to Static Issue");
                        Assert.Fail("Status did not updated to Static Issue");
                    }
                    Browser.Browser.Instance.Navigate().Refresh();
                    Thread.Sleep(4000);
                }
            }
        }
    }
}
