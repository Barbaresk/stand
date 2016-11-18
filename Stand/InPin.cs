using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualStand
{
    class InPin
    {
        public string Name { get; private set; }
        public string Default
        {
            get
            {
                return defaultValue;
            }
        }

        protected int radix;
        private string defaultValue;

        public InPin(int radix, string name)
        {
            Name = name;
            this.radix = radix;
            defaultValue = "";
        }

        public InPin(int radix, string name, string defaultValue) : this(radix, name)
        {
            this.defaultValue = defaultValue;
        }
    }
}
