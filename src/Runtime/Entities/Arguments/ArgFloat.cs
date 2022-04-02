using PHP.VM.Runtime.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Runtime.Entities.Arguments
{
    public class ArgFloat: Argument
    {
        public ArgFloat(double value) : base(Type.FLOAT, value) { }
    }
}
