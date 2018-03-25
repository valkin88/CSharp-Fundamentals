using Logger.Enums;
using System;

namespace Logger.Models
{
    public class ErrorLevelParser
    {
        public ErrorLevel ParseErrorLevel(string errorToString)
        {
            try
            {
                object levelObj = Enum.Parse(typeof(ErrorLevel), errorToString);
                return (ErrorLevel)levelObj;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Invalid ErrorLevel Type!", ex);
            }
        }
    }
}
