using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualStand
{
    public partial class NewObject : Form
    {
        private List<Item> items;
        private Image background;
        private Item choice;
        private int dx;            
        private int dy;

        public NewObject()
        {
            choice = null;
            dx = dy = 0;
            background = null;
            items = new List<Item>();
            InitializeComponent();
        }

        private void bAddElement_Click(object sender, EventArgs e)
        {
            string path = Program.GetFile("Поиск элемента", "Элементы|*.element");
            if (path == null)
            {
                MessageBox.Show("Некорректный файл");
                return;
            }

            AddElement(path);
            

            //int outRow = dgvOut.Rows.Add();
            //dgvOut.Rows[outRow].Cells["RadixOut"].Value = outRadix;
            //dgvOut.Rows[outRow].Cells["NameOut"].Value = outName;
        }

        private void AddElement(string path)
        {
            Element element = new Element(path);
            foreach(Item i in items)
                if(i.Name.Equals(element.Name) && !i.Path.Equals(path))
                {
                    MessageBox.Show("Ошибка! Уже существует элемент типа " + element.Name + " по другому пути:\n" + i.Path + "\n отличному от:\n" + path);
                    return;
                }
            element.Id = GetNewElementId(element.Name);
            items.Add(element);
            int row = dgvItems.Rows.Add();
            dgvItems.Rows[row].Cells["ElementType"].Value = element.Name;
            dgvItems.Rows[row].Cells["ElementName"].Value = element.Id;
        }

        private string GetNewElementId(string name)
        {
            if (!items.Exists(x => x.Id.Equals(name)))
                return name;
            for (int i = 2; ; ++i)
                if (!items.Exists(x => x.Id.Equals(name + i)))
                    return name + i;
        }

        private void NewObject_Paint(object sender, PaintEventArgs e)
        {
            Image buf = new Bitmap(pObject.Width, pObject.Height);
            Graphics gbuf = Graphics.FromImage(buf);
            gbuf.Clear(Color.White);
            if (background != null)
                gbuf.DrawImage(background, 0, 0);
            foreach (Item i in items)
                i.Draw(gbuf, i.GetDefault());
            Graphics.FromHwnd(pObject.Handle).DrawImageUnscaled(buf, 0, 0);
            gbuf.Dispose();
            buf.Dispose();
        }

        private void bBackground_Click(object sender, EventArgs e)
        {
            string name = "";
            background = Program.Loadimage(ref name);
            if (background == null)
            {
                MessageBox.Show("Фон не загружен");
                tbBackground.Text = "Фон отсутствует";
            }
            else
            {
                Regex regex = new Regex(@"([^\\]*)\..*");
                tbBackground.Text = regex.Match(name).Groups[1].Value;
                pObject.Size = background.Size;
                Invalidate();
                MessageBox.Show("Фон загружен");
            }
        }

        private void pObject_MouseDown(object sender, MouseEventArgs e)
        {
            for (int k = items.Count - 1; k >= 0; k--)
            {
                Item i = items[k];
                if (i.X < e.X && i.X + i.Width > e.X &&
                   i.Y < e.Y && i.Y + i.Height > e.Y)
                {
                    choice = i;
                    dx = e.X - i.X;
                    dy = e.Y - i.Y;
                    return;
                }
            }
        }

        private void pObject_MouseMove(object sender, MouseEventArgs e)
        {
            if(choice != null)
            {
                choice.X = e.X - dx;
                choice.Y = e.Y - dy;
            }
            Invalidate();
        }

        private void pObject_MouseLeave(object sender, EventArgs e)
        {
            choice = null;
        }

        private void pObject_MouseUp(object sender, MouseEventArgs e)
        {
            choice = null;
        }
    }
}
