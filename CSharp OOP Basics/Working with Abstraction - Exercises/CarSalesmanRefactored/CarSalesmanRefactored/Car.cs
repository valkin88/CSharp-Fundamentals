using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private const string Offset = "  ";

    public string model;
    public Engine engine;
    public int weight;
    public string color;

    public Car(string model, Engine engine, int weight, string color)
    {
        this.model = model;
        this.engine = engine;
        this.weight = weight;
        this.color = color;
    }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("{0}:\n", this.model);
        sb.Append(this.engine.ToString());
        sb.AppendFormat("{0}Weight: {1}\n", Offset, this.weight == -1 ? "n/a" : this.weight.ToString());
        sb.AppendFormat("{0}Color: {1}", Offset, this.color);

        return sb.ToString();
    }
}
