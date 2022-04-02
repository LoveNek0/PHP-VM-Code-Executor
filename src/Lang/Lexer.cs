using PHP.VM.Exceptions;
using PHP.VM.Lang.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PHP.VM.Lang
{
    public class Lexer
    {
        public readonly string[] code;

        public Lexer(string code) => this.code = code.Split('\n');

        private List<TokenItem> ParseLine(int line)
        {
            List<TokenItem> list = new List<TokenItem>();
            int position = 0;
            while (position < code[line].Length)
            {
                bool exist = false;
                foreach (TokenType type in Enum.GetValues(typeof(TokenType)))
                {
                    Match match = Regex.Match(code[line].Substring(position), "^(" + type.GetPattern() + ")");
                    if (match.Success)
                    {
                        list.Add(new TokenItem(type, match.Value, line, position));
                        position += match.Value.Length;
                        exist = true;
                        break;
                    }
                }
                if(!exist)
                    throw new LexicException("Unknown token \"" + code[line][position] + "\"", line, position);
            }
            return list;
        }

        public TokenItem[][] Parse(bool clear = false)
        {
            List<TokenItem[]> result = new List<TokenItem[]>();
            for (int i = 0; i < code.Length; i++)
            {
                List<TokenItem> items = ParseLine(i);
                if (clear)
                    items.RemoveAll(delegate (TokenItem item)
                    {
                        return item.type == TokenType.COMMENT || item.type == TokenType.WHITESPACE;
                    });
                if (items.Count > 0)
                    result.Add(items.ToArray());
            }
            return result.ToArray();
        }
    }
}
