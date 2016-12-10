using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace VirtualStand
{
    class InPin
    {
        public string Name { get; private set; }
        public List<bool> Default
        {
            get
            {
                if (pins.Count == 0)
                    return Value.StrToArray(defaultValue, radix);
                List<bool> list = new List<bool>();
                foreach (InPin i in pins)
                    list.AddRange(i.Default);
                return list;
            }
        }

        protected int radix;
        private string defaultValue;
        private List<InPin> pins;
        public Item Item { get; private set; }
        public List<InPin> Pins
        {
            get
            {
                return pins;
            }
        }

        public int Radix
        {
            get
            {
                return radix;
            }
        }

        public InPin(int radix, string name)
        {
            Name = name;
            this.radix = radix;
            defaultValue = "";
            pins = new List<InPin>();
        }

        public InPin(int radix, string name, string defaultValue, Item item) : this(radix, name)
        {
            this.defaultValue = defaultValue;
            Item = item;
        }

        public InPin(string name, Item item) : this(0, name, "", item) { }

        virtual public void Write(XmlTextWriter writer)
        {
            writer.WriteStartElement("in");//, dgvr.Cells["NameIn"].Value.ToString());
            writer.WriteAttributeString("xmlns", Name);
            writer.WriteAttributeString("radix", radix.ToString());
            writer.WriteAttributeString("default", defaultValue.ToString());
            writer.WriteEndElement();
        }

        public void Add(InPin pin)
        {
            pins.Add(pin);
            radix += pin.radix;
        }
    }
}
