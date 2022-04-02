using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Runtime.Entities.Arguments
{
    public class ArgInteger : Argument
    {
        public ArgInteger(long value) : base(Type.INTEGER, value) { }
    }
}
