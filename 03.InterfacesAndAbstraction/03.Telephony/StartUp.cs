using _03.Telephony.IO;
using _03.Telephony.IO.Interfaces;
using _03.Telephony.Models.Core;
using System;

namespace _03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Start();
        }
    }
}
