using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Runtime.Entities
{
    public abstract class Argument
    {
        public enum Type
        {
            CONST_STRING,
            ENCLOSED_STRING,
            INTEGER,
            FLOAT,
            BOOLEAN,
            VAR
        }

        public readonly Type type;
        public readonly object value;

        public Argument(Type type, object value)
        {
            this.type = type;
            this.value = value;
        }
    }
}
