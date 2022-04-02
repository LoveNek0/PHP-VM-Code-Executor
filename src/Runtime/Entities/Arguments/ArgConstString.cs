using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Runtime.Entities.Arguments
{
    public class ArgConstString : Argument
    {
        public ArgConstString(string value) : base(Type.CONST_STRING, value) { }
    }
}
