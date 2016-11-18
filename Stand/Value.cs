using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualStand
{
    class Value
    {
        Dictionary<string, string> values;
        public Value()
        {
            values = new Dictionary<string, string>();
        }

        public void Add(string pinName, string value)
        {
            values[pinName] = value;
        }

        public string this[string s]
        {
            get
            {
                return values[s];
            }
        }
    }
}
