using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using VirtualStand.Properties;

namespace VirtualStand
{
    public partial class NewObject : Form
    {
        /// <summary>
        /// Класс - форма создания новых объектов на основе существующи элементов.
        /// </summary>
        private List<Item> items;
        private Image background;
        private Item choice;
        private int fx;            
        private int fy;
        private string oldValue;
        
        public NewObject()
        {
            choice = null;
            fx = fy = 0;
            background = null;
            items = new List<Item>();
            oldValue = "";
            InitializeComponent();
        }

        public NewObject(string path) : this()
        {

        }

        private void bAddElement_Click(object sender, EventArgs e)
        {
            string path = Program.GetFile("Поиск элемента", "Элементы|*.element");
            if (path == null)
            {
                MessageBox.Show("Некорректный файл");
                return;
            }
            AddItem(new Element(path), path);
        }

        private void bAddObject_Click(object sender, EventArgs e)
        {
            string path = Program.GetFile("Поиск объекта", "Объекты|*.object");
            if (path == null)
            {
                MessageBox.Show("Некорректный файл");
                return;
            }
            AddItem(new Subject(path), path);

        }

        private void AddItem(Item item, string path)
        {
            foreach(Item i in items)
                if(i.Name.Equals(item.Name) && !i.Path.Equals(path))
                {
                    MessageBox.Show("Ошибка! Уже существует элемент типа " + item.Name + " по другому пути:\n" + i.Path + "\n отличному от:\n" + path);
                    return;
                }
            item.Id = GetNewElementId(item.Name);
            items.Add(item);
            int row = dgvItems.Rows.Add();
            dgvItems.Rows[row].Cells["ElementType"].Value = item.Name;
            dgvItems.Rows[row].Cells["ElementName"].Value = item.Id;

            foreach (InPin ip in item.InPins)
            {
                int rowIn = dgvIn.Rows.Add();
                dgvIn.Rows[rowIn].Cells["ElementIn"].Value = item.Id;
                dgvIn.Rows[rowIn].Cells["Input"].Value = ip.Name;
                dgvIn.Rows[rowIn].Cells["NewIn"].Value = ChooseName(dgvIn, "NewIn", item.Id, ip.Name);
            }

            foreach (OutPin op in item.OutPins)
            {
                int rowOut = dgvOut.Rows.Add();
                dgvOut.Rows[rowOut].Cells["ElementOut"].Value = item.Id;
                dgvOut.Rows[rowOut].Cells["Output"].Value = op.Name;
                dgvOut.Rows[rowOut].Cells["NewOut"].Value = ChooseName(dgvOut, "NewOut", item.Id, op.Name);
            }
        }

        private string ChooseName(DataGridView dgv, string newPinId, string element, string pin)
        {
            bool simple = false;
            bool composite = false;
            foreach(DataGridViewRow dgvr in dgv.Rows)
                try
                {
                    if(dgvr.Cells[newPinId].Value.ToString().Equals(pin))
                    {
                        simple = true;
                        break;
                    }
                    if (dgvr.Cells[newPinId].Value.ToString().Equals(element + "_" + pin))
                        composite = true;
                }
                catch { }
            if (!simple)
                return pin;
            if (!composite)
                return element + "_" + pin;
            return "";            
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
            if (cbLink.Checked)
            {
                for (int i = 0; i < pObject.Width; i += 10)
                    gbuf.DrawLine(new Pen(new SolidBrush(Color.LightGray), 1), i, 0, i, pObject.Height);
                for (int i = 0; i < pObject.Height; i += 10)
                    gbuf.DrawLine(new Pen(new SolidBrush(Color.LightGray), 1), 0, i, pObject.Width, i);
            }
            foreach (Item i in items)
                i.DrawEditor(gbuf, i.GetDefault(), 0, 0);
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
                    fx = e.X;
                    fy = e.Y;
                    return;
                }
            }
        }

        private void pObject_MouseMove(object sender, MouseEventArgs e)
        {
            if(choice != null)
            {
                if (cbLink.Checked)
                {
                    if (Math.Abs(e.X - fx) > 10)
                    {
                        choice.Move((e.X - fx) / 10 * 10, 0);
                        fx += (e.X - fx) / 10 * 10;
                    }
                    if (Math.Abs(e.Y - fy) > 10)
                    {
                        choice.Move(0, (e.Y - fy) / 10 * 10);
                        fy += (e.Y - fy) / 10 * 10;
                    }
                }
                else
                {
                    choice.Move(e.X - fx, e.Y - fy);
                    fx = e.X;
                    fy = e.Y;
                }
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

        private void dgvItems_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldValue = dgvItems[e.ColumnIndex, e.RowIndex].Value.ToString();
        }

        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string newValue = dgvItems[e.ColumnIndex, e.RowIndex].Value.ToString();
            int count = 0;
            foreach (DataGridViewRow dgvr in dgvItems.Rows)
                if (dgvr.Cells["ElementName"].Value != null
                    && dgvr.Cells["ElementName"].Value.ToString().Equals(newValue))
                    ++count;
            if (count == 2)
            {
                dgvItems[e.ColumnIndex, e.RowIndex].Value = oldValue;
                MessageBox.Show("Элемент с именем " + newValue + " уже существует!");
            }
            else
            {
                items.Find(x => x.Id.Equals(oldValue)).Id = newValue;
            }

            if (!cbIn.Checked)
                ChangeName(dgvIn, "ElementIn", "Input", "NewIn", newValue);
            if (!cbOut.Checked)
                ChangeName(dgvOut, "ElementOut", "Output", "NewOut", newValue);
            Invalidate();
        }

        private void ChangeName(DataGridView dgv, string elementId, string pinId, string newPinId, string elementNew)
        {
            foreach(DataGridViewRow dgvr in dgv.Rows)
                if(dgvr.Cells[elementId].Value.Equals(oldValue))
                {
                    dgvr.Cells[elementId].Value = elementNew;
                    string newPinOld = dgvr.Cells[newPinId].Value.ToString();
                    dgvr.Cells[newPinId].Value = "";
                    string newPinNew = ChooseName(dgv, newPinId, elementNew, dgvr.Cells[pinId].Value.ToString());
                    if (!newPinNew.Equals(""))
                        dgvr.Cells[newPinId].Value = newPinNew;
                    else
                        dgvr.Cells[newPinId].Value = newPinOld;
                }
        }

        private void dgvItems_KeyDown(object sender, KeyEventArgs e)
        {
            move(dgvItems, true, e);
        }

        private void dgvIn_KeyDown(object sender, KeyEventArgs e)
        {
            move(dgvIn, false, e);
        }


        private void dgvOut_KeyDown(object sender, KeyEventArgs e)
        {
            move(dgvOut, false, e);
        }

        private void move(DataGridView dgv, bool list, KeyEventArgs e)
        {
            if (!e.Control)
                return;
            if (e.KeyCode == Keys.W)
            {
                if (dgv.Rows[0].Selected)
                    return;
                for (int i = 1; i < dgv.RowCount; ++i)
                    if (dgv.Rows[i].Selected)
                    {
                        DataGridViewRow row = dgv.Rows[i - 1];
                        dgv.Rows.Remove(row);
                        dgv.Rows.Insert(i, row);
                        if (list)
                        {
                            Item item = items[i - 1];
                            items.Remove(item);
                            items.Insert(i, item);
                        }
                    }
            }
            else if (e.KeyCode == Keys.S)
            {
                if (dgv.Rows[dgv.RowCount - 1].Selected)
                    return;
                for (int i = dgv.RowCount - 1; i >= 0; --i)
                    if (dgv.Rows[i].Selected)
                    {
                        DataGridViewRow row = dgv.Rows[i + 1];
                        dgv.Rows.Remove(row);
                        dgv.Rows.Insert(i, row);
                        if (list)
                        {
                            Item item = items[i + 1];
                            items.Remove(item);
                            items.Insert(i, item);
                        }
                    }
            }
            Invalidate();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            int errorsCount = Check();
            if (errorsCount != 0)
            {
                MessageBox.Show("Найдено " + errorsCount + " ошибок");
                return;
            }

            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "Выбор директории для элемента";
            string folderPath = "", subPath = tbName.Text;
            string path = "";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                folderPath = folder.SelectedPath;
                path = folder.SelectedPath + @"\" + tbName.Text;
            }
            else
            {
                MessageBox.Show("Сохранение отменено");
                return;
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (SaveXml(folderPath, subPath))
                SaveVhd(folderPath, subPath);
        }

        private void SaveVhd(string folderPath, string subPath)
        {
            StreamWriter writer = new StreamWriter(folderPath + @"\" + subPath + @"\" + tbName.Text + ".vhd");
            writer.WriteLine(Resources.vhd0);
            writer.WriteLine("entity " + tbName.Text + " is");
            writer.WriteLine(Resources.vhd1);
            Dictionary<string, int> dici = new Dictionary<string, int>();
            int ri = 0;
            foreach (DataGridViewRow row in dgvIn.Rows)
            {
                string pin = row.Cells["NewIn"].Value.ToString();
                Item i = items.Find(x => x.Id.Equals(row.Cells["ElementIn"].Value.ToString()));
                InPin ip = i.InPins.Find(x => x.Name.Equals(row.Cells["Input"].Value.ToString()));
                ri += ip.Radix;
                if (dici.ContainsKey(pin))
                    dici[pin] = dici[pin] + ip.Radix;
                else
                    dici[pin] = ip.Radix;
            }
            foreach (KeyValuePair<string, int> p in dici)
                writer.WriteLine("\t\t" + p.Key + " : in  " + (p.Value == 1 ? "std_logic;" : ("std_logic_vector(" + (p.Value - 1).ToString() + " downto 0);")));

            int ro = 0;
            Dictionary<string, int> dico = new Dictionary<string, int>();
            foreach (DataGridViewRow row in dgvOut.Rows)
            {
                string pin = row.Cells["NewOut"].Value.ToString();
                string item = row.Cells["ElementOut"].Value.ToString(); ;
                Item i = items.Find(x => x.Id.Equals(item));
                OutPin op = i.OutPins.Find(x => x.Name.Equals(row.Cells["Output"].Value.ToString()));
                ro += op.Radix;
                if (dico.ContainsKey(pin))
                    dico[pin] = dico[pin] + op.Radix;
                else
                    dico[pin] = op.Radix;
            }
            foreach (KeyValuePair<string, int> p in dico)
                writer.WriteLine("\t\t" + p.Key + " : out " + (p.Value == 1 ? "std_logic;" : ("std_logic_vector(" + (p.Value - 1).ToString() + " downto 0);")));
            writer.WriteLine(Resources.vhd2);
            writer.WriteLine("end " + subPath + ";");
            writer.WriteLine("architecture Behavioral of " + tbName.Text + " is");
            writer.WriteLine("\t constant len  : integer := " + (ro + ri) + " ;");
            writer.WriteLine("\t constant rwc  : integer := " + ri + " ;");
            writer.WriteLine("\t constant name : integer := " + (tbName.Text.Length + 1) + " * 16;");
            writer.WriteLine("\t signal   info : std_logic_vector(name - 1 downto 0) := x\"" + "0000" + ToStr(tbName.Text) + "\";");
            writer.WriteLine(Resources.vhd3);
            if (ri != 0)
            {
                string inp = "";
                foreach (KeyValuePair<string, int> p in dici)
                    inp = p.Key + " & " + inp;
               
                inp = inp.Substring(0, inp.Length - 3);
                writer.WriteLine("\tvalue(rwc - 1 downto 0) <= " + inp + ";");
            }
            int pos = ri;
            foreach (KeyValuePair<string, int> p in dico)
            {
                writer.WriteLine(p.Key + " <= value(" + (pos - 1 + p.Value) + " downto " + pos + ");");
                pos += p.Value;

                }
            
            writer.WriteLine(Resources.vhd4);
            writer.Close();
        }

        public static string ToStr(string s)
        {
            string result = "";
            foreach(char c in s)
            {
                UInt16 k = Convert.ToUInt16(c);
                result = ToSym((Convert.ToUInt32(c) & 0xF000) >> 12 ) + result;
                result = ToSym((Convert.ToUInt32(c) & 0x0F00) >> 8) + result;
                result = ToSym((Convert.ToUInt32(c) & 0x00F0) >> 4) + result;
                result = ToSym((Convert.ToUInt32(c) & 0x000F)) + result;
            }
            return result;
        }

        public static char ToSym(UInt32 ui)
        {
            ui = ((ui & 1) << 3) | ((ui & 2) << 1) | ((ui & 4) >> 1) | ((ui & 8) >> 3);
            if (ui >= 10)
                return Convert.ToChar(Convert.ToUInt16('A') - 10 + ui);
            else
                return Convert.ToChar(Convert.ToUInt16('0') + ui);
        }


        private bool SaveXml(string folderPath, string subPath)
        {
            List<string> errors = CheckSave(folderPath, subPath);
            if (errors.Count != 0)
            {
                string message = "В директории " + subPath + " существуют следующие файлы и папки.\nОни будут перезаписаны.\n";
                foreach (string s in errors)
                    message += s + "\n";
                if (MessageBox.Show(message, "Предупреждение о перезаписи", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    MessageBox.Show("Сохранение отменено");
                    return false;
                }
            }
            XmlTextWriter writer = new XmlTextWriter(folderPath + @"\" + subPath + @"\" + tbName.Text + ".object", null);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;
            writer.WriteStartDocument();
            writer.WriteStartElement("object");
            writer.WriteAttributeString("name", subPath);
            if (background != null)
            {
                writer.WriteAttributeString("background", tbBackground.Text + ".png");
                WriteImage(folderPath + @"\" + subPath + @"\" + tbBackground.Text + ".png", background);
            }
            foreach (DataGridViewRow r in dgvItems.Rows)
            {
                Item i = items.Find(x => x.Id.Equals(r.Cells["ElementName"].Value.ToString()));
                writer.WriteStartElement(i.GetItemType());
                writer.WriteAttributeString("name", r.Cells["ElementType"].Value.ToString());
                writer.WriteAttributeString("id", r.Cells["ElementName"].Value.ToString());
                writer.WriteAttributeString("x", i.X.ToString());
                writer.WriteAttributeString("y", i.Y.ToString());
                foreach (DataGridViewRow row in dgvIn.Rows)
                    if (row.Cells["ElementIn"].Value.ToString().Equals(r.Cells["ElementName"].Value.ToString()))
                    {
                        writer.WriteStartElement("in");
                        writer.WriteAttributeString("name", row.Cells["Input"].Value.ToString());
                        writer.WriteAttributeString("newIn", row.Cells["NewIn"].Value.ToString());
                        writer.WriteEndElement();
                    }
                foreach (DataGridViewRow row in dgvOut.Rows)
                    if (row.Cells["ElementOut"].Value.ToString().Equals(r.Cells["ElementName"].Value.ToString()))
                    {
                        writer.WriteStartElement("out");
                        writer.WriteAttributeString("name", row.Cells["Output"].Value.ToString());
                        writer.WriteAttributeString("newOut", row.Cells["NewOut"].Value.ToString());
                        writer.WriteEndElement();
                    }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
            foreach (Item i in items)
                i.Save(folderPath, subPath);
            MessageBox.Show("Элемент успешно сохранён");
            return true;
        }

        public static void WriteImage(string name, Image image)
        {
            if (!File.Exists(name) || Line.GetHash(image) != Line.GetHash(Image.FromFile(name)))
                image.Save(name);
        }

        //проверка наличия файлов
        private List<string> CheckSave(string folderPath, string subPath)
        {
            List<string> errors = new List<string>();
            if (File.Exists(folderPath + @"\" + subPath + @"\" + tbBackground.Text + ".png"))
                errors.Add(subPath + @"\" + tbBackground.Text + ".png");
            foreach (Item i in items)
                errors.AddRange(i.CheckSave(folderPath, subPath));
            return errors;
        }

        private void bCheck_Click(object sender, EventArgs e)
        {
            Check();
        }

        private int Check()
        {
            List<string> errors = new List<string>();
            errors = CheckErrors();

            if (errors.Count == 0)
                lErrors.Text = "Ошибки отсутствуют.";
            else
            {
                lErrors.Text = "" + errors.Count + " ошибок:\n";
                foreach (string s in errors)
                    lErrors.Text += s + "\n";
            }

            List<string> warnings = new List<string>();
            //warnings = CheckWarnings();
            if (warnings.Count == 0)
                lWarnings.Text = "Предупреждения отсутствуют.";
            else
            {
                lWarnings.Text = "" + warnings.Count + " предупреждений:\n";
                foreach (string s in warnings)
                    lWarnings.Text += s + "\n";
            }
            return errors.Count;
        }

        //проверка наличия ошибок
        private List<string> CheckErrors()
        {
            List<string> errors = new List<string>();
            if (tbName.Text == "")
                errors.Add("Имя объекта отсутствует.");
            if (dgvItems.ColumnCount == 0)
                errors.Add("Элементы отсутствуют.");
            errors.AddRange(CheckName());
            errors.AddRange(CheckSymbols());
            //errors.AddRange(CheckCondtions());
            //errors.AddRange(CheckImage());
            return errors;
        }

        private List<string> CheckName()
        {
            List<string> errors = new List<string>();
            for (int i = 0; i < dgvIn.RowCount; ++i)
                for (int j = 0; j < dgvOut.RowCount; ++j)
                    if (dgvIn["NewIn", i].Value.ToString().Equals(dgvOut["NewOut", j].Value.ToString()))
                        errors.Add("Имя " + i + " входа совпадает с именем " + j + " выхода (" + dgvIn["NewIn", i].Value.ToString() + ").");
            return errors;
        }

        private List<string> CheckSymbols()
        {
            List<string> errors = new List<string>();
            for (int i = 0; i < dgvIn.RowCount; ++i)
                for (int j = 0; j < dgvIn["NewIn", i].Value.ToString().Length; ++j)
                    if (!CheckSymbol(dgvIn["NewIn", i].Value.ToString()[j]))
                    {
                        errors.Add("строка " + i + " содержит недопустимый символ в " + j + " позиции");
                        break;
                    }
            return errors;
        }

        private bool CheckSymbol(char c)
        {
            if (c <= 'z' && c >= 'a' || c <= 'Z' && c >= 'A' || c == '_' || c >= '0' && c <= '9')
                return true;
            else return false;
        }

        private void dgvItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int i = e.RowIndex; i < e.RowIndex + e.RowCount; ++i)
                RemoveItem(items[i].Id);
            items.RemoveRange(e.RowIndex, e.RowCount);
            Invalidate();
        }

        private void RemoveItem(string id)
        {
            for (int i = dgvIn.RowCount - 1; i >= 0; --i)
                if(dgvIn["ElementIn", i].Value.ToString().Equals(id))
                    dgvIn.Rows.RemoveAt(i);

            for (int i = dgvOut.RowCount - 1; i >= 0; --i)
                if (dgvOut["ElementOut", i].Value.ToString().Equals(id))
                    dgvOut.Rows.RemoveAt(i);
        }

        private void cbLink_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
