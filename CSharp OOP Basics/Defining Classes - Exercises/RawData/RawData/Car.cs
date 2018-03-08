using System;
using System.Collections.Generic;
using System.Linq;

public class Car
{
    private string model;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    private Engine engine;

    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    private Cargo cargo;

    public Cargo Cargo
    {
        get { return cargo; }
        set { cargo = value; }
    }

    private List<Tire> tires;

    public List<Tire> Tires
    {
        get { return tires; }
        set { tires = value; }
    }


    public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.Tires = tires;
    }
}
