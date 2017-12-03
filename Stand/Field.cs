using System;
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
        private Image imageOn;
        private Image imageOff;
        private List<bool> value;
        private string text;

        public Field(string type, int radix, Image on, Image off)
        {
            text = "";
            flag = false;
            imageOn = on;
            imageOff = off;
            this.radix = radix;
            this.type = type;
            if (type.Equals("Поле"))
            {
                tb = new TextBox();
                tb.TextChanged += tbName_TextChanged;
            }
            else
            {
                value = new List<bool>();
                for (int i = 0; i < radix; ++i)
                    value.Add(false);
            }
            //switch (type)
            //{
            //    case "Кнопки":
            //        b = new List<Button>();
            //        for (int i = 0; i < radix; ++i)
            //        {
            //            Button button = new Button();
            //            button.Size = new Size(sizeButton, sizeButton);
            //            b.Add(button);
            //        }
            //        break;
            //    case "Тумблеры":
            //        cb = new List<CheckBox>();
            //        for (int i = 0; i < radix; ++i)
            //        {
            //            CheckBox checkBox = new CheckBox();
            //            checkBox.Size = new Size(sizeButton, sizeButton);
            //            cb.Add(checkBox);
            //        }
            //        break;
            //    case "Поле":
            //        tb = new TextBox();
            //        break;
            //}
        }

        public void Draw(Graphics graphics, Point location, PictureBox picture)
        {
            if(type.Equals("Поле"))
            {
                tb.Location = location;
                if (!flag)
                    picture.Controls.Add(tb);
                tb.Invalidate();
                flag = true;
            }
            else
            {
                for (int i = 0; i < radix; ++i)
                    graphics.DrawImage(value[i] ? imageOn : imageOff, location.X + i * imageOn.Width, location.Y);
            }
        }


        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if (!tb.Text.Equals(""))
                text = tb.Text;
        }

        public List<bool> GetValue()
        {
            if (type.Equals("Поле"))
            {
                return Value.StrToArray(text, radix);
            }
            else
            {
                List<bool> val = new List<bool>(value);
                val.Reverse();
                return val;
            }
        }
        
        public void Click(int x)
        {
            int i = x / imageOn.Width;
            value[i] = !value[i];
        }
    }
}