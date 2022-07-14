namespace _03.Telephony.Models
{

    using Interfaces;
    using System;

    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            return $"Calling... {number}";
        }
    }
}
