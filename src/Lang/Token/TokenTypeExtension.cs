using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Lang.Token
{
    public static class TokenTokenTypeExtension
    {
        private static readonly Dictionary<TokenType, string> patterns = new Dictionary<TokenType, string>()
            {
                //  Useless
                {TokenType.COMMENT,             @"#[\s\S]*" },
                {TokenType.WHITESPACE,          @"\s+" },

                //  Unary
                {TokenType.ECHO,                @"ECHO" },
                {TokenType.EXIT,                @"EXIT" },
                {TokenType.UNSET,               @"UNSET" },
                {TokenType.POINT,               @"POINT" },
                {TokenType.GOTO,                @"GOTO" },
                

                //  Binary
                {TokenType.ASSIGN,              @"ASSIGN" },

                //  Ternary
                {TokenType.CONCAT,              @"CONCAT" },
                {TokenType.ADD,                 @"ADD" },
                {TokenType.SUB,                 @"SUB" },
                {TokenType.MUL,                 @"MUL" },
                {TokenType.DIV,                 @"DIV" },
                {TokenType.MOD,                 @"MOD" },
                {TokenType.POW,                 @"POW" },

                //  Data
                {TokenType.CONST_STRING,        "C\"[a-zA-Z_][a-zA-Z0-9_]*\"" },
                {TokenType.ENCLOSED_STRING,     "S\".+\"" },
                {TokenType.INTEGER,             @"L[0-9]+" },
                {TokenType.FLOAT,               @"D[0-9]+(\.[0-9]+)?" },
                {TokenType.BOOLEAN,             @"TRUE|FALSE" },

                //  Var
                {TokenType.VAR,                 @"\$[a-zA-Z_][a-zA-Z0-9_]*" }
            };
        private static readonly Dictionary<TokenType, TokenType[][]> expected = new Dictionary<TokenType, TokenType[][]>()
        {
            {TokenType.ASSIGN,
                new TokenType[][]{
                    new TokenType[]{TokenType.VAR },
                    new TokenType[]{
                        TokenType.VAR,
                        TokenType.INTEGER, TokenType.FLOAT,
                        TokenType.ENCLOSED_STRING, TokenType.BOOLEAN }
                }
            },
            {TokenType.ECHO,
                new TokenType[][]{
                    new TokenType[]{
                        TokenType.VAR,
                        TokenType.INTEGER, TokenType.FLOAT,
                        TokenType.ENCLOSED_STRING, TokenType.BOOLEAN }
                }
            },
            {TokenType.EXIT,
                new TokenType[][]{
                    new TokenType[]{TokenType.VAR, TokenType.INTEGER, TokenType.BOOLEAN }
                }
            },
            {TokenType.CONCAT,
                new TokenType[][]{
                    new TokenType[]{TokenType.VAR },
                    new TokenType[]{TokenType.VAR, TokenType.INTEGER, TokenType.FLOAT, TokenType.ENCLOSED_STRING },
                    new TokenType[]{TokenType.VAR, TokenType.INTEGER, TokenType.FLOAT, TokenType.ENCLOSED_STRING }
                }
            },
            {TokenType.ADD,
                new TokenType[][]{
                    new TokenType[]{TokenType.VAR },
                    new TokenType[]{TokenType.VAR, TokenType.INTEGER, TokenType.FLOAT },
                    new TokenType[]{TokenType.VAR, TokenType.INTEGER, TokenType.FLOAT }
                }
            },
            {TokenType.SUB,
                new TokenType[][]{
                    new TokenType[]{TokenType.VAR },
                    new TokenType[]{TokenType.VAR, TokenType.INTEGER, TokenType.FLOAT },
                    new TokenType[]{TokenType.VAR, TokenType.INTEGER, TokenType.FLOAT }
                }
            },
            {TokenType.MUL,
                new TokenType[][]{
                    new TokenType[]{TokenType.VAR },
                    new TokenType[]{TokenType.VAR, TokenType.INTEGER, TokenType.FLOAT },
                    new TokenType[]{TokenType.VAR, TokenType.INTEGER, TokenType.FLOAT }
                }
            },
            {TokenType.DIV,
                new TokenType[][]{
                    new TokenType[]{TokenType.VAR },
                    new TokenType[]{TokenType.VAR, TokenType.INTEGER, TokenType.FLOAT },
                    new TokenType[]{TokenType.VAR, TokenType.INTEGER, TokenType.FLOAT }
                }
            },
            {TokenType.MOD,
                new TokenType[][]{
                    new TokenType[]{TokenType.VAR },
                    new TokenType[]{TokenType.VAR, TokenType.INTEGER, TokenType.FLOAT },
                    new TokenType[]{TokenType.VAR, TokenType.INTEGER, TokenType.FLOAT }
                }
            }
        };
        public static string GetPattern(this TokenType type) => patterns[type];
        public static TokenType[][] GetExpected(this TokenType type) => expected[type];
    }
}
