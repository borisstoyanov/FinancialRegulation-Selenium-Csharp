using System;

namespace AutomationUtilities.Exceptions
{
    class TextNotFoundException:Exception
    {
        string text;
        public TextNotFoundException(String textNotFound)
        {
            this.text = textNotFound;
        }

        public String getExpectedText()
        {
            return text;
        }
    }
}
