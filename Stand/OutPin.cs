using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public int X { get; private set; }
        public int Y { get; private set; }
        private Field field;

        private string type;
        private Image ImageOn;
        private Image ImageOff;
        private string nameOn;
        private string nameOff;
        private List<bool> value;

        public OutPin(int radix, string name, int x, int y, string type, Image on, Image off, string nameOn, string nameOff) : base(radix, name)
        {
            X = x;
            Y = y;
            if (type != null)
            {
                this.type = type;
                field = new Field(type, radix, on, off);
                if (on != null && off != null)
                {
                    ImageOn = on;
                    this.nameOn = nameOn;
                    ImageOff = off;
                    this.nameOff = nameOff;
                    Width = radix * ImageOn.Width;
                    Height = radix * ImageOff.Height;
                }
                else
                {
                    if (type != null)
                    {
                        if (type.Equals("Кнопки"))
                        {
                            ImageOn = VirtualStand.Properties.Resources.buttonBuffer;
                            ImageOff = VirtualStand.Properties.Resources.buttonBuffer;
                        }
                        else
                        {
                            ImageOn = VirtualStand.Properties.Resources.checkboxBuffer;
                            ImageOff = VirtualStand.Properties.Resources.checkboxBuffer;
                        }
                        Width = radix * ImageOn.Width;
                        Height = radix * ImageOff.Height;
                    }
                    else
                    {
                        Width = Height = 0;
                    }
                }
            }
        }

        public OutPin(string name) : this(0, name, 0, 0, null, null, null, "", "") { }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public void Draw(Graphics graphics, Point location)
        {
            if (pins.Count == 0)
            {
                if (type.Equals("Поле"))
                    graphics.DrawImage(VirtualStand.Properties.Resources.textboxBuffer, new Point(location.X + X, location.Y + Y));
                else
                    for (int i = 0; i < radix; ++i)
                        graphics.DrawImage(ImageOff, new Point(location.X + X + i * 20, Y + location.Y));
            }
        }

        public void DrawPanel(Graphics graphics, Point location, PictureBox picture)
        {
            field.Draw(graphics, location, picture);
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

        public void Write(string path, XmlTextWriter writer)
        {
            writer.WriteStartElement("out");
            writer.WriteAttributeString("name", Name);
            writer.WriteAttributeString("x", X.ToString());
            writer.WriteAttributeString("y", Y.ToString());
            writer.WriteAttributeString("type", type);
            writer.WriteAttributeString("radix", radix.ToString());
            if (ImageOn != null && ImageOff != null)
            {
                writer.WriteAttributeString("on", nameOn);
                writer.WriteAttributeString("off", nameOff);
                WriteImage(path + "\\" + nameOn, ImageOn);
                WriteImage(path + "\\" + nameOff, ImageOff);
            }
            writer.WriteEndElement();
        }

        public static void WriteImage(string name, Image image)
        {
            try
            {
                if (!File.Exists(name) || Line.GetHash(image) != Line.GetHash(Image.FromFile(name)))
                    image.Save(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Click(int x, int y)
        {
            if (!type.Equals("Поле"))
                if (x > 0 && x < Width && y > 0 && y < Height)
                    field.Click(x);
        }
    }
}
