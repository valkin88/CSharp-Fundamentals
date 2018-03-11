using System;
using System.Collections.Generic;
using System.Text;

public class Student : Human
{
    private string facultyNumber;

    public string FacultyNumber
    {
        get { return this.facultyNumber; }
        set
        {
            Validator.ValidateFacultyNumber(value);
            this.facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNumber):base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder(base.ToString());
        builder.AppendLine($"Faculty number: {this.FacultyNumber}");
        return builder.ToString();
    }
}
