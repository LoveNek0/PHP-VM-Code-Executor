using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Runtime.Buffers
{
    public class MemoryBuffer
    {
        private Dictionary<object, object> buffer = new Dictionary<object, object>();
        public MemoryBuffer()
        {

        }

        internal void Clear() => buffer.Clear();

        internal void Set(object key, object value) => buffer[key] = value;
        internal object Get(object key) => buffer[key];
        internal void Unset(object key) => buffer.Remove(key);
    }
}
