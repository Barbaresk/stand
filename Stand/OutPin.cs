using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace VirtualStand
{
    class OutPin : InPin
    {
        /// <summary>
        /// Выходной порт элемента.
        /// </summary>
        private int X { get; set; }
        private int Y { get; set; }
        private Field field;

        private string type;

        public OutPin(int radix, string name, int x, int y, string type) : base(radix, name)
        {
            X = x;
            Y = y;
            this.type = type;
            field = new Field(type, radix);
        }

        public OutPin(string name) : this(0, name, 0, 0, null) { }

        public void Draw(Graphics graphics, Point location)
        {
            if (type.Equals("Поле"))
                graphics.DrawImage(VirtualStand.Properties.Resources.textboxBuffer, new Point(location.X + X, location.Y + Y));
            else
                for (int i = 0; i < radix; ++i)
                    if (type.Equals("Кнопки"))
                        graphics.DrawImage(VirtualStand.Properties.Resources.buttonBuffer, new Point(location.X + X + i * 20, Y + location.Y));
                    else
                        graphics.DrawImage(VirtualStand.Properties.Resources.checkboxBuffer, new Point(location.X + X + i * 20, Y + location.Y));
        }

        public void DrawPanel(Graphics graphics, Point location, PictureBox picture)
        {
            field.Draw(location, picture);
        }

        public List<bool> GetValue()
        {
            if (pins.Count == 0)
                return field.GetValue();
            List<bool> list = new List<bool>();
            foreach (OutPin i in pins)
                list.AddRange(i.GetValue());
            return list;
        }

        public override void Write(XmlTextWriter writer)
        {
            writer.WriteStartElement("out");
            writer.WriteAttributeString("name", Name);
            writer.WriteAttributeString("x", X.ToString());
            writer.WriteAttributeString("y", Y.ToString());
            writer.WriteAttributeString("type", type);
            writer.WriteAttributeString("radix", radix.ToString());
            writer.WriteEndElement();
        }
    }
}
