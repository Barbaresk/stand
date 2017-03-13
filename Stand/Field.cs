using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VirtualStand
{
    /// <summary>
    /// Класс для хранения типа переключателя внутри элемента (кнопка, тумблер, поле).
    /// </summary>
    internal class Field
    {

        private TextBox tb;
        private List<CheckBox> cb;
        private List<Button> b;
        private string type; 
        private const int sizeButton = 21;
        private int radix;
        private bool flag;

        public Field(string type, int radix)
        {
            flag = false;
            this.radix = radix;
            this.type = type;
            switch (type)
            {
                case "Кнопки":
                    b = new List<Button>();
                    for (int i = 0; i < radix; ++i)
                    {
                        Button button = new Button();
                        button.Size = new Size(sizeButton, sizeButton);
                        b.Add(button);
                    }
                    break;
                case "Тумблеры":
                    cb = new List<CheckBox>();
                    for (int i = 0; i < radix; ++i)
                    {
                        CheckBox checkBox = new CheckBox();
                        checkBox.Size = new Size(sizeButton, sizeButton);
                        cb.Add(checkBox);
                    }
                    break;
                case "Поле":
                    tb = new TextBox();
                    break;
            }
        }

        public void Draw(Point location, PictureBox picture)
        {
            switch(type)
            {
                case "Кнопки":
                    for (int i = 0; i < b.Count; ++i)
                    {
                        b[i].Location = new Point(location.X + i * sizeButton, location.Y);
                        if (!flag)
                            picture.Controls.Add(b[i]);
                        b[i].Invalidate();
                    }
                        break;
                case "Тумблеры":
                    for (int i = 0; i < cb.Count; ++i)
                    {
                        cb[i].Location = new Point(location.X + i * sizeButton, location.Y);
                        if (!flag)
                            picture.Controls.Add(cb[i]);
                        cb[i].Invalidate();
                    }
                    break;
                case "Поле":
                    tb.Location = location;
                    if (!flag)
                        picture.Controls.Add(tb);
                    break;
                    tb.Invalidate();
            }
            flag = true;
        }

        public List<bool> GetValue()
        {
            List<bool> value = new List<bool>(radix);
            switch (type)
            {
                case "Кнопки":
                    for (int i = 0; i < radix; ++i)
                        value.Add(true);
                    break;
                case "Тумблеры":
                    for (int i = 0; i < radix; ++i)
                        value.Add(cb[i].Checked);
                    break;
                case "Поле":
                    if (Term.Check(tb.Text))
                        value.AddRange(Value.StrToArray(tb.Text, radix)); 
                    break;
            }
            for (int i = value.Count; i < radix; ++i)
                value.Add(false);
            return value;
        }
    }
}