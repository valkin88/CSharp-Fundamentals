﻿using System;
using System.Collections.Generic;
using System.Text;

public class Stats
{
    private double endurance;
    private double sprint;
    private double dribble;
    private double passing;
    private double shooting;

    public double Endurance
    {
        get { return endurance; }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Endurance should be between 0 and 100.");
            }
            endurance = value;
        }
    }

    public double Sprint
    {
        get { return sprint; }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Sprint should be between 0 and 100.");
            }
            sprint = value;
        }
    }

    public double Dribble
    {
        get { return dribble; }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Dribble should be between 0 and 100.");
            }
            dribble = value;
        }
    }

    public double Passing
    {
        get { return passing; }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Passing should be between 0 and 100.");
            }
            passing = value;
        }
    }

    public double Shooting
    {
        get { return shooting; }
        private set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Shooting should be between 0 and 100.");
            }
            shooting = value;
        }
    }

    public Stats(double endurance, double sprint, double dribble, double passing, double shooting)
    {
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

}
