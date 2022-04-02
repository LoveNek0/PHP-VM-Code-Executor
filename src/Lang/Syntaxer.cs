using PHP.VM.Exceptions;
using PHP.VM.Lang.Token;
using PHP.VM.Runtime.Entities;
using PHP.VM.Runtime.Entities.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Lang
{
    public class Syntaxer
    {
        private readonly TokenItem[][] tokenLines;
        public Syntaxer(TokenItem[][] tokenLines) => this.tokenLines = tokenLines;

        private Operation ParseLine(int line)
        {
            int position = 0;
            TokenItem NextToken(params TokenType[] expected) => 
                expected != null && !expected.Contains(tokenLines[line][position].type) && expected.Length > 0
                    ? throw new SyntaxException("Unexpected token " + tokenLines[line][position].type, tokenLines[line][position].line, tokenLines[line][position].column)
                    : tokenLines[line][position++];
            TokenItem opItem = NextToken(
                TokenType.ECHO, TokenType.EXIT,
                TokenType.ASSIGN, TokenType.CONCAT,
                TokenType.ADD, TokenType.SUB,
                TokenType.MUL, TokenType.DIV,
                TokenType.MOD, TokenType.POW);
            if (tokenLines[line].Length - 1 != opItem.type.GetExpected().Length)
                throw new SyntaxException("Incorrect number of arguments for operator " + opItem.type, opItem.line, opItem.column);
            List<Argument> args = new List<Argument>();
            for(int i = 0; i < opItem.type.GetExpected().Length; i++)
            {
                TokenItem arg = NextToken(opItem.type.GetExpected()[i]);
                switch (arg.type)
                {
                    case TokenType.VAR:
                        args.Add(new ArgVar(arg.data));
                        break;
                    case TokenType.INTEGER:
                        args.Add(new ArgInteger(long.Parse(arg.data.ToString().Substring(1))));
                        break;
                    case TokenType.FLOAT:
                        args.Add(new ArgFloat(double.Parse(arg.data.ToString().Substring(1))));
                        break;
                    case TokenType.ENCLOSED_STRING:
                        args.Add(new ArgEnclosedString(arg.data.Substring(2, arg.data.Length - 3)));
                        break;
                    case TokenType.BOOLEAN:
                        args.Add(new ArgBoolean(arg.data == "TRUE" ? true : false));
                        break;
                }
            }
            switch (opItem.type)
            {
                case TokenType.ECHO:
                    return new Operation(Operation.Type.ECHO, args.ToArray());
                case TokenType.EXIT:
                    return new Operation(Operation.Type.EXIT, args.ToArray());
                case TokenType.ASSIGN:
                    return new Operation(Operation.Type.ASSIGN, args.ToArray());
                case TokenType.CONCAT:
                    return new Operation(Operation.Type.CONCAT, args.ToArray());
                case TokenType.ADD:
                    return new Operation(Operation.Type.ADD, args.ToArray());
                case TokenType.SUB:
                    return new Operation(Operation.Type.SUB, args.ToArray());
                case TokenType.MUL:
                    return new Operation(Operation.Type.MUL, args.ToArray());
                case TokenType.DIV:
                    return new Operation(Operation.Type.DIV, args.ToArray());
                case TokenType.MOD:
                    return new Operation(Operation.Type.MOD, args.ToArray());
                case TokenType.POW:
                    return new Operation(Operation.Type.POW, args.ToArray());
            }
            throw new SyntaxException("WTF??!", opItem.line, opItem.column);
        }

        public Operation[] Parse()
        {
            List<Operation> operations = new List<Operation>();
            for (int i = 0; i < tokenLines.Length; i++)
                operations.Add(ParseLine(i));
            return operations.ToArray();
        }
    }
}
