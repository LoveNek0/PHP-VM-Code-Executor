using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Lang.Token
{
    public class TokenItem
    {
        public readonly TokenType type;
        public readonly string data;
        public readonly int line;
        public readonly int column;

        public TokenItem(TokenType type, string data, int line, int column)
        {
            this.type = type;
            this.data = data;
            this.line = line;
            this.column = column;
        }
    }
}
