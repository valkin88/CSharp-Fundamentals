using System;
using System.Collections.Generic;
using System.Text;

public class Dough
{
    private string flourType;
    private string bakingTechnique;
    private double weight;

    public string FlourType
    {
        get { return flourType; }
        private set
        {
            Validator.DoughTypeValidator(value);
            flourType = value;
        }
    }

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        private set
        {
            Validator.DoughTypeValidator(value);
            bakingTechnique = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        private set
        {
            Validator.DoughWeightValidator(value);
            weight = value;
        }
    }

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public double CalculateDoughCalories
    {
        get
        {
            return (2 * this.Weight) * this.FlourTypeModdifier() * this.BakingTechniqueModifier();
        }
    }

    private double FlourTypeModdifier()
    {
        if (this.FlourType.ToLower() == "white")
        {
            return 1.5;
        }
        else
        {
            return 1.0;
        }
    }

    private double BakingTechniqueModifier()
    {
        if (this.BakingTechnique.ToLower() == "crispy")
        {
            return 0.9;
        }
        else if (this.BakingTechnique.ToLower() == "chewy")
        {
            return 1.1;
        }
        else
        {
            return 1.0;
        }
    }
}
