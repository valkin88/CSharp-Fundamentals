using Logger.Models.Contracts;
using System.Globalization;

namespace Logger.Models.Layouts
{
    public abstract class Layout : ILayout
    {
        protected const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public virtual string Format { get; }

        public virtual string FormatError(IError error)
        {
            string dateToString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);

            string formatedError = string.Format(this.Format, dateToString, error.ErrorLevel.ToString(), error.Message);

            return formatedError;
        }
    }
}
