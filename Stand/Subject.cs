using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace VirtualStand
{
    /// <summary>
    /// Объект - набор элементов. Может быть сам частью другого объекта.
    /// </summary>
    class Subject : Item
    {
        private List<Item> items;

        private Value val;

        public Subject(string path) : this(path, 0, 0, "") { }

        public Subject(string path, int x, int y, string id) : base(path, x, y, id)
        {
            items = new List<Item>();
            Read();
            size = GetSize();
        }


        public override void Read()
        {
            Regex regexPath = new Regex(@"(.*\\)[^\\]*");                //выделение папки из пути к файлу
            string folder = regexPath.Match(Path).Groups[1].Value;
            Item last = null;
            int xk = 0;
            int yk = 0;
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
                            case "object":
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "background":
                                            try
                                            {
                                                background = Image.FromFile(folder + "\\" + reader.Value);
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
                            case "item_element":
                                string elementName = "";
                                string elementId = "";
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "id":
                                            elementId = reader.Value;
                                            break;
                                        case "name":
                                            elementName = reader.Value;
                                            break;
                                        case "x":
                                            xk = Convert.ToInt32(reader.Value);
                                            break;
                                        case "y":
                                            yk = Convert.ToInt32(reader.Value);
                                            break;
                                    }
                                }
                                last = new Element(folder + @"\" + elementName + @"\" + elementName + ".element", xk, yk, elementId);
                                items.Add(last);
                                break;
                            case "item_object":
                                string subjectName = "";
                                string subjectId = "";

                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "id":
                                            subjectId = reader.Value;
                                            break;
                                        case "name":
                                            subjectName = reader.Value;
                                            break;
                                        case "x":
                                            xk = Convert.ToInt32(reader.Value);
                                            break;
                                        case "y":
                                            yk = Convert.ToInt32(reader.Value);
                                            break;
                                    }
                                }
                                last = new Subject(folder + @"\" + subjectName + @"\" + subjectName + ".object", xk, yk, subjectId);
                                items.Add(last);
                                break;
                            case "in":
                                string newIn = "";
                                string pinIn = "";
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "newIn":
                                            newIn = reader.Value;
                                            break;
                                        case "name":
                                            pinIn = reader.Value;
                                            break;
                                    }
                                }
                                InPin oldIn = inPins.Find(x => x.Name.Equals(newIn));
                                if (oldIn == null)
                                {
                                    oldIn = new InPin(newIn, this);
                                    inPins.Add(oldIn);
                                }
                                oldIn.Add(last.InPins.Find(x => x.Name.Equals(pinIn)));
                                break;
                            case "out":
                                string newOut = "";
                                string pinOut = "";
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "newOut":
                                            newOut = reader.Value;
                                            break;
                                        case "name":
                                            pinOut = reader.Value;
                                            break;
                                    }
                                }
                                OutPin oldOut = outPins.Find(x => x.Name.Equals(newOut));
                                if (oldOut == null)
                                {
                                    oldOut = new OutPin(newOut);
                                    outPins.Add(oldOut);
                                }
                                oldOut.Add(last.OutPins.Find(x => x.Name.Equals(pinOut)));
                                break;
                        }
                        break;
                }
            }
        }

        public override List<string> CheckSave(string path, string addition)
        {
            return new List<string>();
        }

        public override void Draw(Graphics graphics, Value value, int x, int y)
        {
            if (background != null)
                graphics.DrawImage(background, X + x, Y + y);
            DrawItems(graphics, value, x, y);
        }

        public override void DrawPanel(Graphics graphics, Value value, int x, int y, PictureBox picture)
        {
            if (background != null)
                graphics.DrawImage(background, X + x, Y + y);
            Dictionary<string, Value> d = new Dictionary<string, Value>();
            foreach (Item i in items)
                d[i.Id] = new Value();
            foreach (InPin ip in InPins)
            {
                int k = 0;
                foreach (InPin subip in ip.Pins)
                {
                    d[subip.Item.Id][subip.Name] = value[ip.Name].GetRange(k, subip.Radix);
                    k += subip.Radix;
                }
            }
            foreach (Item i in items)
                i.DrawPanel(graphics, d[i.Id], X + x, Y + y, picture);
        }

        public override void DrawEditor(Graphics graphics, Value value, int x, int y)
        {
            if (background != null)
                graphics.DrawImage(background, X + x, Y + y);
            DrawItems(graphics, value, x, y);
 
            graphics.DrawRectangle(new Pen(new SolidBrush(Color.Red), 2), X + x, Y + y, Width, Height);
            graphics.DrawString(Id, new Font("Arial black", 10), new SolidBrush(Color.Black), X + x, Y + y);
        }

        public void DrawItems(Graphics graphics, Value value, int x, int y)
        {
            Dictionary<string, Value> d = new Dictionary<string, Value>();
            foreach (Item i in items)
                d[i.Id] = new Value();
            foreach (InPin ip in InPins)
            {
                int k = 0;
                foreach (InPin subip in ip.Pins)
                {
                    d[subip.Item.Id][subip.Name] = value[ip.Name].GetRange(k, subip.Radix);
                }
            }
            foreach (Item i in items)
                i.Draw(graphics, d[i.Id], X + x, Y + y);
        }

        public override Value GetDefault()
        {
            if (val == null)
            {
                Value value = new Value();
                foreach (InPin i in inPins)
                    value[i.Name] = i.Default;
                return value;
            }
            else
                return val;
        }

        public void SetDefault(Value val)
        {
            this.val = val;
        }

        public override void Save(string folderPath, string subPath)
        {
            string path = folderPath + @"\" + subPath + @"\" + Name + @"\";
            if (Directory.Exists(path))
                return;
            Directory.CreateDirectory(path);

            XmlTextWriter writer = new XmlTextWriter(path + @"\" + Name + @".object", null);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;
            writer.WriteStartDocument();
            writer.WriteStartElement("object");
            writer.WriteAttributeString("name", Name);
            if (background != null)
            {
                writer.WriteAttributeString("background", backgroundName);
                NewObject.WriteImage(path + @"\" + backgroundName, background);
            }

            foreach(Item i in items)
            {
                writer.WriteStartElement(i.GetItemType());
                writer.WriteAttributeString("name", i.Name);
                writer.WriteAttributeString("id", i.Id);
                writer.WriteAttributeString("x", i.X.ToString());
                writer.WriteAttributeString("y", i.Y.ToString());
                foreach(InPin ip in i.InPins)
                {
                    InPin ipp = inPins.Find(x => x.Pins.Contains(ip));
                    writer.WriteStartElement("in");
                    writer.WriteAttributeString("name", ip.Name);
                    writer.WriteAttributeString("newIn", ipp.Name);
                    writer.WriteEndElement();
                }
                foreach(OutPin op in i.OutPins)
                {
                    OutPin opp = outPins.Find(x => x.Pins.Contains(op));
                    writer.WriteStartElement("out");
                    writer.WriteAttributeString("name", op.Name);
                    writer.WriteAttributeString("newOut", opp.Name);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Close();
            foreach (Item i in items)
                i.Save(folderPath, subPath + @"\" + Name);
        }

        protected override Size GetSize()
        {
            int left = X;
            int right = 0;
            int top = Y;
            int bottom = 0;
            if (background != null)
            {
                right = left + background.Width;
                bottom = top + background.Height;
            }
            foreach (Item i in items)
            {
                if (i.X + X < left)
                    left = i.X;
                if (i.Y + Y < top)
                    top = i.Y;
                if (i.X + X + i.Width > right)
                    right = i.X + X + i.Width;
                if (i.Y + Y + i.Height > bottom)
                    bottom = i.Y + Y + i.Height;
            }
            return new Size(right - left, bottom - top);
        }

        public override string GetItemType()
        {
            return "item_object";
        }

        public override void Click(int x, int y)
        {
            foreach (var item in items)
                item.Click(x - item.X, y - item.Y);
        }
    }
}
