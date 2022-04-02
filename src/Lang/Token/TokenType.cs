using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Lang.Token
{
    public enum TokenType
    {
        //  Useless
        COMMENT,
        WHITESPACE,

        //  Unary
        ECHO,
        EXIT,
        UNSET,
        POINT,
        GOTO,

        //  Binary
        ASSIGN,
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
        LESS_EQUAL,

        //  Ternary
        CONCAT,

        //  Data
        CONST_STRING,
        ENCLOSED_STRING,
        INTEGER,
        FLOAT,
        BOOLEAN,

        //  Var
        VAR
    }
}
