namespace _03.Telephony.Models
{
    using Interfaces;

    internal class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            return $"Dialing... {number}";
        }
     
    }
}
