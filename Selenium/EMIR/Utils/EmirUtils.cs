using AutomationUtilities.FieldIDs;
using AutomationUtilities.PageObjects;
using AutomationUtilities.PageObjects.BicPO;
using AutomationUtilities.PageObjects.NavigationPO;
using AutomationUtilities.Utils;
using System;


namespace EmirAutomation.Utils
{
    public class EmirUtils
    {

        
        
        internal static void VerifyEmirConfirmed()
        {
            PO_UTISearch.GoTo(Test.UTI, 50);
            PO_EditEmirTransactionPage emirTransactionPage = new PO_EditEmirTransactionPage();
            emirTransactionPage.VerifySendSuccessfully(30);
            emirTransactionPage.VerifyEMIRConfirmed();
        }

        internal static string CreateBicCode()
        {
            PO_BICPopUp bic = PO_Dashboard.GoToBICPopUp();
            bic.CreateNewBicCode()
                .Create();
            bic.VerifyBicCodeCreated();
            AutomationUtilities.Browser.Browser.ClickClose();
            return Test.extRef;
        }

    }
}
