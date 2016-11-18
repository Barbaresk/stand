using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace VirtualStand
{
    class Element : Item
    {
        private List<OutPin> outPins;
        private List<InPin> inPins;
        private List<Condition> conditions;
        private Value defaultValue;

        public Element(string path)
        {
            this.path = path;
            background = null;
            outPins = new List<OutPin>();
            inPins = new List<InPin>();
            conditions = new List<Condition>();
            Location = new Point(0, 0);
            Read();
            defaultValue = new Value();
            foreach (InPin pin in inPins)
                defaultValue.Add(pin.Name, pin.Default);
            size = GetSize();
        }

        public void Read()
        {
            Regex regexPath = new Regex(@"(.*\\)[^\\]*");                //выделение папки из пути к файлу

            XmlTextReader reader = new XmlTextReader(Path);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.XmlDeclaration:
                        break;
                    case XmlNodeType.Element:
                        switch (reader.Name)
                        {
                            case "element":
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "background":
                                            try
                                            {
                                                background = Image.FromFile(regexPath.Match(Path).Groups[1].Value + "\\" + reader.Value);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("Ошибка при открытии файла:\n" + ex.Message);
                                            }
                                            break;
                                        case "xmlns":
                                            name = reader.Value;
                                            break;
                                    }
                                }
                                break;
                            case "out":
                                int x = 0;
                                int y = 0;
                                int outRadix = 0;
                                string type = "";
                                string outName = "";
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "x":
                                            y = Convert.ToInt32(reader.Value);
                                            break;
                                        case "y":
                                            x = Convert.ToInt32(reader.Value);
                                            break;
                                        case "type":
                                            type = reader.Value;
                                            break;
                                        case "radix":
                                            outRadix = Convert.ToInt32(reader.Value);
                                            break;
                                        case "xmlns":
                                            outName = reader.Value;
                                            break;
                                    }
                                }
                                outPins.Add(new OutPin(outRadix, outName, x, y, type));
                                break;
                            case "in":
                                int inRadix = 0;
                                string inName = "";
                                string defaultValue = "";
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "radix":
                                            inRadix = Convert.ToInt32(reader.Value);
                                            break;
                                        case "xmlns":
                                            inName = reader.Value;
                                            break;
                                        case "default":
                                            defaultValue = reader.Value;
                                            break;
                                    }
                                }
                                inPins.Add(new InPin(inRadix, inName, defaultValue));
                                break;
                            case "line":
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name.Equals("image"))
                                    {
                                        try
                                        {
                                            Image image = Image.FromFile(regexPath.Match(Path).Groups[1].Value + "\\" + reader.Value);
                                            conditions.Add(new Condition(image));
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Ошибка при открытии файла:\n" + ex.Message);
                                        }
                                    }
                                }
                                break;
                            case "condition":
                                string pin = "";
                                string value = "";
                                string action = "";
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "name":
                                            pin = reader.Value;
                                            break;
                                        case "value":
                                            value = reader.Value;
                                            break;
                                        case "action":
                                            action = reader.Value;
                                            break;
                                    }
                                }
                                conditions.Last().Add(inPins.Find(o => o.Name.Equals(pin)), value, Term.ToAction(action));
                                break;
                        }
                        break;
                }
            }
        }

        public override void Draw(Graphics g, Value value)
        {
            if (background != null)
                g.DrawImage(background, Location);
            foreach (Condition c in conditions)
                c.Draw(g, Location, value);
            foreach (OutPin o in outPins)
                o.Draw(g, Location);
            g.DrawString(Id, new Font("Arial black", 10), new SolidBrush(Color.Black), X, Y);
        }

        public override Value GetDefault()
        {
            return defaultValue;
        }

        protected override Size GetSize()
        {
            int width = 0;
            int height = 0;
            if (background != null)
            {
                width = background.Width;
                height = background.Height;
            }
            foreach (Condition c in conditions)
            {
                if (c.Width > width)
                    width = c.Width;
                if (c.Height > height)
                    height = c.Height;
            }
            return new Size(width, height);
        }
    }
}
