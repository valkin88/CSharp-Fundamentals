using System;

public class Ferrari : ICar
{
    private string model;
    private string driverName;

    public Ferrari(string driverName)
    {
        this.DriverName = driverName;
        this.Model = "488-Spider";
    }

    public string Model
    {
        get { return model; }
        private set { model = value; }
    }

    public string DriverName
    {
        get { return driverName; }
        private set { driverName = value; }
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public string UseGas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.UseBrakes()}/{this.UseGas()}/{this.DriverName}";
    }
}
