using System;

namespace AutomationUtilities.Exceptions
{
    class NotOnTheExpectedPageException:Exception
    {
        String expectedPage;
        String actualPage;
        public NotOnTheExpectedPageException(String expectedPage, String actualPage)
        {
            this.actualPage = actualPage;
            this.expectedPage = expectedPage;

        }

        public String getExpectedPage()
        {
            return expectedPage;
        }
        public String getActualPage()
        {
            return actualPage;
        }
    }
}
