using System;
using System.Linq;

public class Smartphone : ICallable, IBrowsable
{
    public string Browsing(string website)
    {
        if (website.Any(x => char.IsDigit(x)))
        {
            throw new ArgumentException("Invalid URL!");
        }
        return $"Browsing: {website}!";
    }

    public string Calling(string phoneNumber)
    {
        if (phoneNumber.Any(x => char.IsLetter(x)))
        {
            throw new ArgumentException("Invalid number!");
        }
        return $"Calling... {phoneNumber}";
    }

}
