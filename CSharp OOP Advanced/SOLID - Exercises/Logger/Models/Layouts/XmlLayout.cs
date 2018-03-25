using Logger.Models.Contracts;
using System;

namespace Logger.Models.Layouts
{
    public class XmlLayout : Layout
    {
        // 0 -> Date; 1 -> ErrorLevel; 2 -> Message 
        public override string Format =>
            "<log>" + Environment.NewLine + 
                "\t<date>{0}</date>" + Environment.NewLine + 
                "\t<level>{1}</level>" + Environment.NewLine + 
                 "\t<message>{2}</message>" + Environment.NewLine + 
            "</log>";
    }
}
