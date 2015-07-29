
namespace AutomationUtilities.PageObjects
{
    public class PO_UserAccountButton
    {
        public static void LogOff()
        {
            Engage();
            ClickLogOff();
        }

        private static void ClickLogOff()
        {
            Browser.Browser.ClickByXPath("//a[text()='Log Out']");
        }

        private static void Engage()
        {
            Browser.Browser.ClickByID("UserAccountImage");
        }
    }
}
