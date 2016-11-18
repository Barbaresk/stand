using System.Collections.Generic;
using System.Drawing;

namespace VirtualStand
{
    class Condition
    {
        private Image Image { get; set; }
        private List<Term> terms;

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

        public Condition(Image image)
        {
            Image = image;
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
    }
}