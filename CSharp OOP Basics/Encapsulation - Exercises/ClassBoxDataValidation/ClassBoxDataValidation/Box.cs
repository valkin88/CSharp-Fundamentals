using System;
using System.Text;

public class Box
{
    private double length;

    public double Length
    {
        get { return length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            length = value;
        }
    }

    private double width;

    public double Width
    {
        get { return width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            width = value;
        }
    }

    private double height;

    public double Height
    {
        get { return height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Height cannot be zero or negative.");
            }
            height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double GetSurfaceArea()
    {
        return 2 * (this.Length * this.Width) + 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);
    }

    public double GetLateralSurfaceArea()
    {
        return 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);
    }

    public double GetVolume()
    {
        return this.Length * this.Width * this.Height;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Surface Area - {GetSurfaceArea():f2}");
        builder.AppendLine($"Lateral Surface Area - {GetLateralSurfaceArea():f2}");
        builder.AppendLine($"Volume - {GetVolume():f2}");

        return builder.ToString();
    }
}
