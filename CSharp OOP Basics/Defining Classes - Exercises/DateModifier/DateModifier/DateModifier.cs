using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

public class DateModifier
{
    private DateTime startDate;
    private DateTime endDate;

    public DateTime StartDate
    {
        get { return this.startDate; }
        set { this.startDate = value; }
    }

    public DateTime EndDate
    {
        get { return this.endDate; }
        set { this.endDate = value; }
    }

    public DateModifier(DateTime startDate, DateTime endDate)
    {
        this.StartDate = startDate;
        this.EndDate = endDate;
    }

    public double CountInDays()
    {
        double days = Math.Abs((this.StartDate - this.EndDate).TotalDays);
        return days;
    }


}
