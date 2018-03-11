using System;

public class Repair
{
    private string nameOfPart;
    private int hoursWorker;

    public Repair(string nameOfPart, int hoursWorked)
    {
        this.NameOfPart = nameOfPart;
        this.HoursWorked = hoursWorked;
    }

    public string NameOfPart
    {
        get { return nameOfPart; }
        private set { nameOfPart = value; }
    }

    public int HoursWorked
    {
        get { return hoursWorker; }
        private set { hoursWorker = value; }
    }
}
