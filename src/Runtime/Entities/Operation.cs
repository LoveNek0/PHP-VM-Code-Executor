using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Runtime.Entities
{
    public class Operation
    {
        public enum Type
        {
            //  Unary
            ECHO,
            EXIT,
            UNSET,
            POINT,
            GOTO,

            //  Binary
            ASSIGN,
            CONCAT,
            ADD,
            SUB,
            MUL,
            DIV,
            MOD,
            POW,
            IF,
            EQUAL,
            NOT_EQUAL,
            MORE,
            LESS,
            MORE_EQUAL,
            LESS_EQUAL
        }

        public readonly Type type;
        public readonly Argument[] arguments;

        public Operation(Type type, Argument[] arguments)
        {
            this.type = type;
            this.arguments = arguments;
        }
    }
}
