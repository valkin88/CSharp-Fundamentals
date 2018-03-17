﻿using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private const string Offset = "  ";

    public string model;
    public int power;
    public int displacement;
    public string efficiency;


    public Engine(string model, int power, int displacement, string efficiency)
    {
        this.model = model;
        this.power = power;
        this.displacement = displacement;
        this.efficiency = efficiency;
    }



    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("{0}{1}:\n", Offset, this.model);
        sb.AppendFormat("{0}{0}Power: {1}\n", Offset, this.power);
        sb.AppendFormat("{0}{0}Displacement: {1}\n", Offset, this.displacement == -1 ? "n/a" : this.displacement.ToString());
        sb.AppendFormat("{0}{0}Efficiency: {1}\n", Offset, this.efficiency);

        return sb.ToString();
    }
}
