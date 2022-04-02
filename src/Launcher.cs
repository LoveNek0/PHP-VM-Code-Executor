using PHP.VM.Lang;
using PHP.VM.Lang.Token;
using PHP.VM.Runtime;
using PHP.VM.Runtime.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace PHP.VM
{
    public class Launcher
    {       
        public static void Main(string[] args)
        {
            string code = File.ReadAllText(args[0]);
            Lexer lexer = new Lexer(code);
            TokenItem[][] tokens = lexer.Parse(true);
            Syntaxer syntaxer = new Syntaxer(tokens);
            Operation[] operations = syntaxer.Parse();
            Executor executor = new Executor(operations);
            executor.OnMessageEventHandler = delegate (string message)
            {
                Console.WriteLine(message);
            };
            int result = executor.Run();
            Console.WriteLine("Result: " + result);
            Console.ReadKey();
        }
    }
}