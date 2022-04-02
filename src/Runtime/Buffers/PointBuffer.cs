using PHP.VM.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP.VM.Runtime.Buffers
{
    public class PointBuffer
    {
        private Dictionary<string, int> points = new Dictionary<string, int>();

        public PointBuffer() { }

        public void Add(string key, int value)
        {
            if (points.ContainsKey(key))
                throw new RuntimeException("Point \"" + key + "\" already defined on line " + points[key]);
            points.Add(key, value);
        }

        public int Get(string key)
        {
            if(!points.ContainsKey(key))
                throw new RuntimeException("Point \"" + key + "\" not defined");
            return points[key];
        }
    }
}
