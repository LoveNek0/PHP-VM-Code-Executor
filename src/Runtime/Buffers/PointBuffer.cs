using PHP.VM.Exceptions;
using PHP.VM.Runtime.Entities;
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

        public PointBuffer(Operation[] operations) {
            int line = 0;
            foreach (Operation operation in operations)
            {
                if (operation.type == Operation.Type.POINT)
                    points.Add((string)operation.arguments[0].value, line);
                line++;
            }
        }

        internal int Get(string key)
        {
            if(!points.ContainsKey(key))
                throw new RuntimeException("Point \"" + key + "\" not defined");
            return points[key];
        }
    }
}
