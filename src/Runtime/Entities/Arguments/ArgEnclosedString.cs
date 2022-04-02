using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Runtime.Entities.Arguments
{
    public class ArgEnclosedString : Argument
    {
        public ArgEnclosedString(string value) : base(Type.ENCLOSED_STRING, value) { }
    }
}
