using System;
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

        public string Id { get; set; }
        protected string path;
        protected string name;
        protected Size size;

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
            set
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
            set
            {
                Location = new Point(X, value);
            }
        }

        abstract protected Size GetSize();
        abstract public void Draw(Graphics graphics, Value value);
        abstract public Value GetDefault();

    }

}
