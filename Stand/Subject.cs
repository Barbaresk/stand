using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace VirtualStand
{
    class Subject : Item
    {
        private List<Item> items;

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
                                        case "xmlns":
                                            name = reader.Value;
                                            break;
                                        case "x":
                                            X = Convert.ToInt32(reader.Value);
                                            break;
                                        case "y":
                                            Y = Convert.ToInt32(reader.Value);
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
                                        case "xmlns":
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
                            case "item_subject":
                                string subjectName = "";
                                string subjectId = "";

                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "id":
                                            subjectId = reader.Value;
                                            break;
                                        case "xmlns":
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
                                last = new Subject(folder + @"\" + subjectName + @"\" + subjectName + ".subject", xk, yk, subjectId);
                                items.Add(last);
                                break;
                            case "in":
                                string newIn = "";
                                string pinIn = "";
                                while (reader.MoveToNextAttribute())
                                {
                                    switch (reader.Name)
                                    {
                                        case "new":
                                            newIn = reader.Value;
                                            break;
                                        case "xmlns":
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
                                        case "new":
                                            newOut = reader.Value;
                                            break;
                                        case "xmlns":
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
            throw new NotImplementedException();
        }

        public override void Draw(Graphics graphics, Value value)
        {
            if (background != null)
                graphics.DrawImage(background, Location);
            foreach (Item i in items)
                i.Draw(graphics, value);
        }

        public override void DrawEditor(Graphics graphics, Value value)
        {
            if (background != null)
                graphics.DrawImage(background, Location);

            Dictionary<string, Value> d = new Dictionary<string, Value>();
            foreach (Item i in items)
                d[i.Id] = new Value();
            foreach (InPin ip in InPins)
            {
                int k = 0;
                foreach (InPin subip in ip.Pins)
                {
                
                //    if (d[subip.Item.Id] == null)
                 //       d[subip.Item.Id] = new Value();
                    d[subip.Item.Id][subip.Name] = value[ip.Name].GetRange(k, subip.Radix);
                }
            }
            foreach (Item i in items)
                i.Draw(graphics, d[i.Id]);
            graphics.DrawRectangle(new Pen(new SolidBrush(Color.Red), 2), X, Y, Width, Height);
            graphics.DrawString(Id, new Font("Arial black", 10), new SolidBrush(Color.Black), X, Y);
        }

        public override Value GetDefault()
        {
            Value value = new Value();
            foreach (InPin i in inPins)
                value[i.Name] = i.Default;
            return value;
        }

        public override void Save(string path, string subPath)
        {
            throw new NotImplementedException();
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
                if (i.X < left)
                    left = i.X;
                if (i.Y < top)
                    top = i.Y;
                if (i.X + i.Width > right)
                    right = i.X + i.Width;
                if (i.Y + i.Height > bottom)
                    bottom = i.Y + i.Height;
            }
            return new Size(right - left, bottom - top);
        }

        public override string GetItemType()
        {
            return "item_element";
        }
    }
}
