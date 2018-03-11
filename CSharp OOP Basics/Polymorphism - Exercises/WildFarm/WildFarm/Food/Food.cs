using System;

public abstract class Food
{
    private int quantity;

    public Food(int quantity)
    {
        this.Quantity = quantity;
    }

    public int Quantity
    {
        get { return quantity; }
        protected set
        {
            quantity = value;
        }
    }

}
