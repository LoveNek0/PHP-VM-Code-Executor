using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Runtime.Buffers
{
    public class OutputBuffer
    {
        private Queue<byte[]> buffer = new Queue<byte[]>();

        public OutputBuffer() { }

        public void Write(object message) => buffer.Enqueue(Encoding.UTF8.GetBytes(message.ToString()));

        public byte[] Read() => buffer.Dequeue();
    }
}
