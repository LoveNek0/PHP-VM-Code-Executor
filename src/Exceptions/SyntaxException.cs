using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Exceptions
{
    public class SyntaxException : Exception
    {
        public readonly int line;
        public readonly int column;

        public SyntaxException(string message, int line, int column) : base("Lexic Error: " + message + " on line " + line + ", column " + column)
        {
            this.line = line;
            this.column = column;
        }
    }
}
