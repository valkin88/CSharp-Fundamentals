using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Book
{
    private string title;
    private string author;
    private decimal price;

    public string Title
    {
        get { return this.title; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public string Author
    {
        get { return this.author; }
        set
        {
            string[] newValue = value.Split();
            if (newValue.Length == 2 && char.IsDigit(newValue[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }
            this.author = value;
        }
    }

    public virtual decimal Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Type: {this.GetType().Name}");
        builder.AppendLine($"Title: {this.Title}");
        builder.AppendLine($"Author: {this.Author}");
        builder.AppendLine($"Price: {this.Price:f2}");
        return builder.ToString();
    }

}
