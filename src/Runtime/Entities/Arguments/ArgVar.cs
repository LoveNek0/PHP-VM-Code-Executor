using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Runtime.Entities.Arguments
{
    public class ArgVar : Argument
    {
        public ArgVar(string value) : base(Type.VAR, value) { }
    }
}
