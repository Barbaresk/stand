using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace VirtualStand
{
    internal class Line
    {
        private Panel panel;
        private PictureBox picture;
        private Label lName;
        private TextBox name;
        private List<Box> boxes;
        private DataGridView dgv;
        public int Hash { get; private set; }

        public Image Image { get; private set; }

        public string Name
        {
            get
            {
                return name.Text;
            }
        }

        public int Width
        {
            get
            {
                return Image.Width;
            }
        }

        public int Height
        {
            get
            {
                return Image.Height;
            }
        }

        public Line(Image image, Panel panel, DataGridView dgv, string name)
        {
            Image = image;
            this.panel = panel;
            
            picture = new PictureBox();
            picture.Size = new Size(40, 40);
            picture.Location = new Point(0, 0);

            Bitmap b = new Bitmap(40, 40);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(image, 0, 0, 40, 40);
            picture.Image = (Image)b;

            panel.Controls.Add(picture);

            lName = new Label();
            lName.Text = "Имя:";
            lName.Location = new Point(45, 13);
            lName.Size = new Size(35, 20);
            panel.Controls.Add(lName);

            this.name = new TextBox();
            this.name.Text = name;
            this.name.Location = new Point(80, 10);
            this.name.Size = new Size(60, 20);
            panel.Controls.Add(this.name);
            
            boxes = new List<Box>();
            this.dgv = dgv;

            Hash = GetHash(Image);
        }

        public void Update()
        {
            foreach (Box b in boxes)
                b.Update();
        }

        public void Remove(Box box)
        {
            int pos = boxes.FindIndex(x => x.Equals(box));
            for (int i = pos + 1; i < boxes.Count; ++i)
            {
                boxes[i].Move();
            }
            boxes.RemoveAt(pos);
            panel.Controls.Remove(box.Panel);
        }

        public List<string> CheckErrors(int num)
        {
            List<string> errors = new List<string>();
            for (int i = 0; i < boxes.Count; ++i)
                errors.AddRange(boxes[i].Check(num, i+1));
            return errors;
        }

        public List<string> CheckWarnings(int num, Image img)
        {
            List<string> warnings = new List<string>();
            if (img != null && !img.Size.Equals(Image.Size))
                warnings.Add("Размер изображения в " + num + " условии не совпадает с фоновым");
            return warnings;
        }

        public void Write(XmlTextWriter writer, string path)
        {
            path += "\\" + name.Text + ".png";
            if (!File.Exists(path))
                Image.Save(path);
            else if (Line.GetHash(Image) != Line.GetHash(Image.FromFile(path)))
            {
                File.Delete(path);
                Image.Save(path);
            }
            writer.WriteStartElement("line");
            writer.WriteAttributeString("image", name.Text + ".png");
            foreach (Box b in boxes)
                b.Write(writer);
            writer.WriteEndElement();
        }

        public void AddCondition()
        {
            Panel p = new Panel();
            p.Size = new Size(240, 40);
            p.Location = new Point(140 + boxes.Count * 240, 0);
            p.BackColor = boxes.Count % 2 == 1 ? Color.Black : Color.Yellow;
            boxes.Add(new Box(p, dgv, this));
            panel.Controls.Add(p);
        }

        public void AddCondition(string signal, string value, string action)
        {
            AddCondition();
            boxes.Last().Signal = signal;
            boxes.Last().Value = value;
            boxes.Last().Action = action;
        }

        public static int GetHash(Image image)
        {
            int hash = 0;
            Bitmap b = new Bitmap(image);
            for(int i = 0; i < b.Width; i+=3)
                for(int j = 0; j < b.Height; j+=3)
                    hash ^= b.GetPixel(i, j).ToArgb();
            return hash;
        }

        public List<string> CheckSave(string path, int num)
        {
            try {
                if (File.Exists(path + @"\" + Name + ".png"))
                {
                    Bitmap bFile = new Bitmap(Image.FromFile(path + @"\" + Name + ".png"));
                    Bitmap bThis = new Bitmap(Image);
                    if (!bFile.Size.Equals(bThis.Size))
                        return new List<string>(new string[] { Name + ".png" });
                    else
                    {
                        for (int i = 0; i < bFile.Width; ++i)
                            for (int j = 0; j < bFile.Height; ++j)
                                if (!bFile.GetPixel(i, j).Equals(bThis.GetPixel(i, j)))
                                    return new List<string>(new string[] { Name + ".png" });
                    }
                    return new List<string>();
                }
                return new List<string>();
            }
            catch(Exception)
            {
                return new List<string>();
            }
        }
    }
}