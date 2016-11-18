using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualStand
{
    class OutPin : InPin
    {
        private int X { get; set; }
        private int Y { get; set; }

        private string type;

        public OutPin(int radix, string name, int x, int y, string type) : base(radix, name)
        {
            X = x;
            Y = y;
            this.type = type;
        }

        public void Draw(Graphics graphics, Point location)
        {
            if (type.Equals("Поле"))
                graphics.FillRectangle(new SolidBrush(Color.Pink), new Rectangle(new Point(location.X + X, location.Y + Y), new Size(80, 20)));
            else
                for (int i = 0; i < radix; ++i)
                    graphics.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(location.X + X + i * 20, location.Y + Y, 20, 20));
            //graphics.DrawString(Name, new Font("Arial Black", 10), Brushes.Black, new PointF(location.X + X, location.Y + Y - 10));
        }
    }
}
