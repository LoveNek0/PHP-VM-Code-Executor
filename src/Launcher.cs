using PHP.VM.Lang;
using PHP.VM.Lang.Token;
using PHP.VM.Runtime;
using PHP.VM.Runtime.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace PHP.VM
{
    public class Launcher
    {       
        public static void Main(string[] args)
        {
            string code = File.ReadAllText(@"D:\Projects\CSharp\PHP-VM-Code-Executor\Test codes\example.pvc");
            Lexer lexer = new Lexer(code);
            TokenItem[][] tokens = lexer.Parse(true);
            int i = 1;
            foreach(TokenItem[] tokenItems in tokens)
            {
                Console.WriteLine("Line: " + i++);
                foreach (TokenItem tokenItem in tokenItems)
                    Console.WriteLine("    [" + tokenItem.type.ToString() + "]\t\t\t" + tokenItem.data);
                Console.WriteLine();
            }
            Syntaxer syntaxer = new Syntaxer(tokens);
            Operation[] operations = syntaxer.Parse();
            Executor executor = new Executor();
            int result = executor.Run(operations);
            Console.WriteLine("Result: " + result);
            Console.ReadKey();
        }
    }
}