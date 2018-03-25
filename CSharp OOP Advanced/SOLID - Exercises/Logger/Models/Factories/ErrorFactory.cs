using Logger.Enums;
using Logger.Models.Contracts;
using Logger.Models.Errors;
using System;
using System.Globalization;

namespace Logger.Models.Factories
{
    public class ErrorFactory
    {
        const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string dateTimeToString, string errorLevelToString, string message)
        {
            ErrorLevelParser errorLevelParser = new ErrorLevelParser();
            DateTime dateTime = DateTime.ParseExact(dateTimeToString, DateFormat, CultureInfo.InvariantCulture);
            ErrorLevel errorLevel = errorLevelParser.ParseErrorLevel(errorLevelToString);

            IError error = new Error(dateTime, errorLevel, message);

            return error;
        }
    }
}
