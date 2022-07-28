using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdSplit = args.
                Split();
            string cmdName = cmdSplit[0];
            string[] cmdArgs = cmdSplit.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type cmdType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{cmdName}Command" &&
                                t.GetInterfaces().Any(i => i.Name == "ICommand"));

            if (cmdType == null)
            {
                throw new Exception();
            }

            object cmdInstance = Activator.CreateInstance(cmdType);

            MethodInfo cmdMethod = cmdType.GetMethods()
                .First(m => m.Name == "Execute");

            string result = (string)cmdMethod.Invoke(cmdInstance, new object[] { cmdArgs });

            return result;
            
        }
    }
}
