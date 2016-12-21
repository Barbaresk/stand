using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace VirtualStand
{
    internal class OutBox
    {
        Label name;
        ComboBox variants;
        public Panel Panel { get; private set; }
        //public Panel Preview { get; private set; }

        public Size Size
        {
            get
            {
                return new Size(variants.Text == "Поле" ? 80 : Radix * 20, 20);
            }
        }
        public Point Location { get; set; }
        
        public int Radix { get; set; }

        public string Name
        {
            get
            {
                return name.Text;
            }
        }

        public string Type
        {
            get
            {
                return variants.Text;
            }

            set
            {
                if (value.Equals("Кнопки") || value.Equals("Тумблеры") || value.Equals("Поле"))
                    variants.Text = value;
                else
                    variants.Text = "";
            }
        }

        public OutBox(string name, int radix)
        {
            Panel = new Panel();
            Panel.Height = 45;
            Panel.BackColor = Color.GreenYellow;

            Radix = radix;
            Location = new Point(0, 0);

            this.name = new Label();
            this.name.Text = name;
            this.name.Location = new Point(5, 10);
            this.name.Width = TextRenderer.MeasureText(name, this.name.Font).Width;

            variants = new ComboBox();
            variants.Items.AddRange(new string[] { "Кнопки", "Поле", "Тумблеры" });
            variants.Text = "Поле";
            variants.Location = new Point(this.name.Width + 10, 10);
            variants.Size = new Size(60, 20);
    
            Panel.Width = variants.Location.X + variants.Size.Width + 5;
            Panel.Controls.AddRange(new Control[] { this.name, variants });
        }

        public override string ToString()
        {
            return name.Text;
        }

        public void Draw(Graphics g)
        {
            if (variants.Text.Equals("Поле"))
                g.DrawImage(VirtualStand.Properties.Resources.textboxBuffer, Location);
            else
                for (int i = 0; i < Radix; ++i)
                    if (variants.Text.Equals("Кнопки"))
                        g.DrawImage(VirtualStand.Properties.Resources.buttonBuffer, new Point(Location.X + i * 20, Location.Y));
                    else
                        g.DrawImage(VirtualStand.Properties.Resources.checkboxBuffer, new Point(Location.X + i * 20, Location.Y));
             
            g.DrawString(name.Text, Panel.Font, Brushes.Black, new PointF(Location.X, Location.Y - 10));
        }        

        public void Write(XmlTextWriter writer)
        {
            writer.WriteStartElement("out");
            writer.WriteAttributeString("name", name.Text);
            writer.WriteAttributeString("x", Location.X.ToString());
            writer.WriteAttributeString("y", Location.Y.ToString());
            writer.WriteAttributeString("type", variants.Text);
            writer.WriteAttributeString("radix", Radix.ToString());
            writer.WriteEndElement();
        }
    }
}