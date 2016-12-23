using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml;

namespace VirtualStand
{
    class Condition
    {
        private Image Image { get; set; }
        private List<Term> terms;
        private string imageName; 

        public int Height
        {
            get
            {
                if (Image != null)
                    return Image.Height;
                else
                    return 0;
            }
        }

        public int Width
        {
            get
            {
                if (Image != null)
                    return Image.Width;
                else
                    return 0;
            }
        }

        public Condition(Image image, string imageName)
        {
            Image = image;
            this.imageName = imageName;
            terms = new List<Term>();
        }

        public void Add(InPin pin, string value, Term.Actions action)
        {
            terms.Add(new Term(pin, value, action));
        }

        public void Draw(Graphics graphics, Point location, Value value)
        {
            foreach (Term t in terms)
                if (!t.Correct(value[t.Name]))
                    return;
            graphics.DrawImage(Image, location);
        }

        public void Write(XmlTextWriter writer, string path)
        {
            path += @"\" + imageName;
            if (!File.Exists(path))
                Image.Save(path);
            else if (Line.GetHash(Image) != Line.GetHash(Image.FromFile(path)))
            {
                File.Delete(path);
                Image.Save(path);
            }
            writer.WriteStartElement("line");
            writer.WriteAttributeString("image", imageName);
            foreach (Term t in terms)
                t.Write(writer);
            writer.WriteEndElement();
        }
    }
}