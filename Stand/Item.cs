﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualStand
{
    abstract class Item
    {
        protected Image background;

        protected List<OutPin> outPins;
        protected List<InPin> inPins;
        public string Id { get; set; }
        protected string path;
        protected string name;
        protected Size size;
        protected string backgroundName;

        public string Path
        {
            get
            {
                return path;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            protected set
            {
                name = value;
            }
        }

        public Size Size
        {
            get
            {
                return size;
            }
        }
        public int Width
        {
            get
            {
                return size.Width;
            }
        }
        public int Height
        {
            get
            {
                return size.Height;
            }
        }
        public Point Location { get; set; }
        public int X
        {
            get
            {
                return Location.X;
            }
            protected set
            {
                Location = new Point(value, Y);
            }
        }
        public int Y
        {
            get
            {
                return Location.Y;
            }
            protected set
            {
                Location = new Point(X, value);
            }
        }

        public List<OutPin> OutPins
        {
            get
            {
                return outPins;
            }
        }

        public List<InPin> InPins
        {
            get
            {
                return inPins;
            }
        }

        public Item(string path, int x, int y, string id)
        {
            this.path = path;
            X = x;
            Y = y;
            Id = id;
            background = null;
            backgroundName = null;
            outPins = new List<OutPin>();
            inPins = new List<InPin>();
        }

        abstract protected Size GetSize();
        abstract public Value GetDefault();
        abstract public void Draw(Graphics graphics, Value value, int X, int Y);
        abstract public void DrawEditor(Graphics graphics, Value value, int X, int Y);
        abstract public List<string> CheckSave(string path, string addition);
        abstract public void Save(string path, string subPath);
        abstract public void Read();
        abstract public string GetItemType();
        public void Move(int dx, int dy)
        {
            X = X + dx;
            Y = Y + dy;
        }
    }

}
