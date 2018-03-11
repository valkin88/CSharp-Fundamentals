using System;
using System.Collections.Generic;
using System.Text;

public class Worker : Human
{
    private double weekSalary;
    private double workHoursPerDay;

    public double WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            Validator.ValidateSalary(value, nameof(weekSalary));
            this.weekSalary = value;
        }
    }

    public double WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        set
        {
            Validator.ValidateWorkingHours(value , nameof(workHoursPerDay));
            this.workHoursPerDay = value;
        }
    }

    public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay) :base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public double CalculateweekSalaryPerHour
    {
        get
        {
            return (this.WeekSalary / 5) / this.WorkHoursPerDay;
        }
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder(base.ToString());
        builder.AppendLine($"Week Salary: {this.WeekSalary:f2}");
        builder.AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}");
        builder.AppendLine($"Salary per hour: {this.CalculateweekSalaryPerHour:f2}");

        return builder.ToString();
    }
}
