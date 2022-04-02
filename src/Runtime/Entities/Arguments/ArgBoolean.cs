using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Runtime.Entities.Arguments
{
    public class ArgBoolean : Argument
    {
        public ArgBoolean(bool value) : base(Type.BOOLEAN, value) { }
    }
}
