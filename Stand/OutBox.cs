using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace VirtualStand
{
    internal class OutBox
    {
        /// <summary>
        /// Поле, хранящее значение терма условия. 
        /// Используется при создании элемента.
        /// </summary>
        Label name;
        ComboBox variants;
        public Panel Panel { get; private set; }
        //public Panel Preview { get; private set; }

        public Image ImageOff { get; set; }
        private string nameOn;
        public Image ImageOn { get; set; }
        private string nameOff;
        private Button buttonOn;
        private Button buttonOff;
        private Label labelOn;
        private Label labelOff;
        private int radix;

        public OutBox(string name, int radix)
        {
            int x = 0;
            Panel = new Panel();
            Panel.Height = 45;
            Panel.BackColor = Color.Gainsboro;

            Radix = radix;
            Location = new Point(0, 0);

            this.name = new Label();
            this.name.Text = name;
            this.name.Location = new Point(5, 15);
            this.name.Width = TextRenderer.MeasureText(name, this.name.Font).Width;
            x += this.name.Width + 10;

            variants = new ComboBox();
            variants.Items.AddRange(new string[] { "Кнопки", "Поле", "Тумблеры" });
            variants.Text = "Поле";
            variants.Location = new Point(x, 12);
            variants.Size = new Size(60, 20);
            x += 60 + 10;

            labelOn = new Label();
            labelOn.Text = "On:";
            labelOn.Location = new Point(x, 15);
            labelOn.Width = TextRenderer.MeasureText("On:", this.name.Font).Width;
            x += labelOn.Width + 5;

            buttonOn = new Button();
            buttonOn.Size = new Size(40, 40);
            buttonOn.Text = "On";
            buttonOn.Location = new Point(x, 2);
            buttonOn.Click += buttonOn_Click;
            x += buttonOn.Width + 10;

            labelOff = new Label();
            labelOff.Text = "Off:";
            labelOff.Location = new Point(x, 15);
            labelOff.Width = TextRenderer.MeasureText("Off:", this.name.Font).Width;
            x += labelOff.Width + 5;

            buttonOff = new Button();
            buttonOff.Size = new Size(40, 40);
            buttonOff.Text = "Off";
            buttonOff.Location = new Point(x, 2);
            buttonOff.Click += buttonOff_Click;
            x += buttonOff.Width + 5;

            Panel.Width = x;
            Panel.Controls.AddRange(new Control[] { this.name, variants, labelOn, buttonOn, labelOff, buttonOff });
            if (variants.Text == "Поле")
                Size = new Size(80, 20);
            else
                if (ImageOff != null)
                Size = new Size(Radix * ImageOff.Width, 20);
            else
                Size = new Size(Radix * 20, 20);

        }

        public Size Size { get; set; }

        public int Width
        {
            get
            {
                return Size.Width;
            }
            set
            {
                Size = new Size(value, Height);
            }
        }

        public int Height
        {
            get
            {
                return Size.Height;
            }
            set
            {
                Size = new Size(Width, value);
            }
        }

        public Point Location { get; set; }
        
        public int Radix
        {
            get
            {
                return radix;
            }
            set
            {
                radix = value;
                if (ImageOff != null)
                    Width = radix * ImageOff.Width;
                else if (ImageOn != null)
                    Width = radix * ImageOn.Width;
                else
                    Width = 20 * radix;
            }
        }

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
                    if (ImageOff == null)
                        if (ImageOn == null)
                            if (variants.Text.Equals("Кнопки"))
                                g.DrawImage(VirtualStand.Properties.Resources.buttonBuffer, new Point(Location.X + i * 20, Location.Y));
                            else
                                g.DrawImage(VirtualStand.Properties.Resources.checkboxBuffer, new Point(Location.X + i * 20, Location.Y));
                        else
                            g.DrawImage(ImageOn, new Point(Location.X + i * ImageOn.Width, Location.Y));
                    else
                        g.DrawImage(ImageOff, new Point(Location.X + i * ImageOff.Width, Location.Y));
             
            g.DrawString(name.Text, Panel.Font, Brushes.Black, new PointF(Location.X, Location.Y - 10));
        }        

        public void Write(string path, XmlTextWriter writer)
        {
            writer.WriteStartElement("out");
            writer.WriteAttributeString("name", name.Text);
            writer.WriteAttributeString("x", Location.X.ToString());
            writer.WriteAttributeString("y", Location.Y.ToString());
            writer.WriteAttributeString("type", variants.Text);
            writer.WriteAttributeString("radix", Radix.ToString());
            if (ImageOn != null && ImageOff != null)
            {
                writer.WriteAttributeString("on", nameOn + ".png");
                writer.WriteAttributeString("off", nameOff + ".png");
                WriteImage(path + "\\" + nameOn + ".png", ImageOn);
                WriteImage(path + "\\" + nameOff + ".png", ImageOff);
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

        private void buttonOn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = "";
                ImageOn = Program.Loadimage(ref name);
                if (ImageOn == null)
                {
                    MessageBox.Show("Изображение не загружено");
                }
                else
                {
                    Bitmap b = new Bitmap(40, 40);
                    Graphics g = Graphics.FromImage((Image)b);
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(ImageOn, 0, 0, 40, 40);
                    buttonOn.BackgroundImage = b;
                    buttonOn.Text = "";
                    Regex regex = new Regex(@"([^\\]*)\..*");
                    if (ImageOff == null)
                    {
                        Width = Radix * ImageOn.Width;
                        Height = ImageOn.Height;
                    }
                    nameOn = regex.Match(name).Groups[1].Value;
                    MessageBox.Show("Изображение успешно загружено");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonOff_Click(object sender, EventArgs e)
        {
            try
            {
                string name = "";
                ImageOff = Program.Loadimage(ref name);
                if (ImageOn == null)
                {
                    MessageBox.Show("Изображение не загружено");
                }
                else
                {
                    Bitmap b = new Bitmap(40, 40);
                    Graphics g = Graphics.FromImage((Image)b);
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(ImageOff, 0, 0, 40, 40);
                    buttonOff.BackgroundImage = b;
                    buttonOff.Text = "";
                    Regex regex = new Regex(@"([^\\]*)\..*");
                    nameOff = regex.Match(name).Groups[1].Value;
                    Width = Radix * ImageOff.Width;
                    Height = ImageOff.Height;
                    MessageBox.Show("Изображение успешно загружено");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}