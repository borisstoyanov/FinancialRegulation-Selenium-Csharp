using AutomationUtilities.Exceptions;
using AutomationUtilities.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationUtilities.PageObjects.Maintanance.BusinessData.EicCodes
{
    public class PO_EIC_Details
    {
        public PO_EIC_Details()
        {
            try
            {
                Util.WaitForElementPresentByXPath("//h2[text()='Detail " + Test.extRef + "']", 60);
            }
            catch (NotOnTheExpectedPageException e)
            {
                Test.verificationErrors.Append(e);
                Assert.Fail("The page displayed is not as the expected one.");
            }
        }
    }
}
