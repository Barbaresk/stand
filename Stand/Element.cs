using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace VirtualStand
{
    /// <summary>
    /// Класс - элемент. Является наименьшим возможным самостоятлеьным элементом стенда.
    /// </summary>
    class Element : Item
    {
        private List<Condition> conditions;
        private Value defaultValue;

        public Element(string path) : this(path, 0, 0, "") { }

        public Element(string path, int x, int y, string id) : base(path, x, y, id)
        {
            conditions = new List<Condition>();
            Read();
            defaultValue = new Value();
            foreach (InPin pin in inPins)
                defaultValue[pin.Name] = pin.Default;
            size = GetSize();
        }

        public override void Read()
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
                                                backgroundName = reader.Value;
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("Ошибка при открытии файла:\n" + ex.Message);
                                            }
                                            break;
                                        case "name":
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
                                            x = Convert.ToInt32(reader.Value);
                                            break;
                                        case "y":
                                            y = Convert.ToInt32(reader.Value);
                                            break;
                                        case "type":
                                            type = reader.Value;
                                            break;
                                        case "radix":
                                            outRadix = Convert.ToInt32(reader.Value);
                                            break;
                                        case "name":
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
                                        case "name":
                                            inName = reader.Value;
                                            break;
                                        case "default":
                                            defaultValue = reader.Value;
                                            break;
                                    }
                                }
                                inPins.Add(new InPin(inRadix, inName, defaultValue, this));
                                break;
                            case "line":
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name.Equals("image"))
                                    {
                                        try
                                        {
                                            Image image = Image.FromFile(regexPath.Match(Path).Groups[1].Value + "\\" + reader.Value);
                                            conditions.Add(new Condition(image, reader.Value));
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

        public override void Draw(Graphics graphics, Value value, int x, int y)
        {
            if (background != null)
                graphics.DrawImage(background, X + x, Y + y);
            foreach (Condition c in conditions)
                c.Draw(graphics, new Point(X + x, Y + y), value);
            foreach (OutPin o in outPins)
                o.Draw(graphics, new Point(X + x, Y + y));
        }

        public override void DrawEditor(Graphics graphics, Value value, int x, int y)
        {
            Draw(graphics, value, x, y);
            graphics.DrawRectangle(new Pen(new SolidBrush(Color.Red), 2), X + x, Y + y, Width, Height);
            graphics.DrawString(Id, new Font("Arial black", 10), new SolidBrush(Color.Black), X + x, Y + y);
        }

        public override void DrawPanel(Graphics graphics, Value value, int x, int y, PictureBox picture)
        {
            if (background != null)
                graphics.DrawImage(background, X + x, Y + y);
            foreach (Condition c in conditions)
                c.Draw(graphics, new Point(X + x, Y + y), value);
            foreach (OutPin o in outPins)
                o.DrawPanel(graphics, new Point(X + x, Y + y), picture);

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

        public override List<string> CheckSave(string folderPath, string subPath)
        {
            string path = folderPath + @"\" + subPath + @"\" + name;
            List<string> names = new List<string>();
            if (!Directory.Exists(path))
                return names;
            if (backgroundName != null)
                if (File.Exists(path + @"\" + backgroundName))
                {
                    Bitmap bFile = new Bitmap(Image.FromFile(path + @"\" + backgroundName));
                    Bitmap bThis = new Bitmap(background);
                    if (!bFile.Size.Equals(bThis.Size))
                        names.Add(path + @"\" + background);
                    else
                    {
                        for (int i = 0; i < bFile.Width; i += 3)
                            for (int j = 0; j < bFile.Height; j += 3)
                                if (!bFile.GetPixel(i, j).Equals(bThis.GetPixel(i, j)))
                                {
                                    names.Add(subPath + @"\" + name + @"\" + background);
                                    break;
                                }
                    }
                }

            return new List<string>();
        }

        public override void Save(string path, string subPath)
        {
            path = path + @"\" + subPath + @"\" + name;
            if (Directory.Exists(path))
                return;
            Directory.CreateDirectory(path);

            XmlTextWriter writer;

            writer = new XmlTextWriter(path + "\\" + name + ".element", null);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;
            writer.WriteStartDocument();
            writer.WriteStartElement("element");
            writer.WriteAttributeString("name", name);
            if (background != null)
            {
                writer.WriteAttributeString("background", backgroundName);
                WriteImage(path + @"\" + backgroundName, background);
            }
            foreach (OutPin o in outPins)
                o.Write(writer);
            foreach (InPin i in inPins)
                i.Write(writer);
            foreach (Condition c in conditions)
                c.Write(writer, path);

            writer.WriteEndElement();
            writer.Close();
        }

        public static void WriteImage(string name, Image image)
        {
            if (!File.Exists(name) || Line.GetHash(image) != Line.GetHash(Image.FromFile(name)))
                image.Save(name);
        }

        public override string GetItemType()
        {
            return "item_element";
        }
    }
}
