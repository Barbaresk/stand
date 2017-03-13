using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace VirtualStand
{
    /// <summary>
    /// Класс - форма создания новых элементов.
    /// </summary>
    public partial class NewElement : Form
    {
        private Image background;         //фоновое изображение
        private List<Button> buttonsUp;   //кнопки перемещения условия вверх
        private List<Button> buttonsDown; //кнопки перемещения условия вниз
        private List<Button> buttonsDel;  //кнопки удаления условий
        private List<Button> buttonsAdd;  //кнопки добалвления условия
        private List<Panel> panels;       //панели с условиями
        private List<Line> lines;         //условия
        private OutBox choice;            //выбранное условие для перемещения
        int dx;                           //разница между курсором и углом кнопок
        int dy;                           //разница между курсором и углом кнопок
        public const int height = 60;     //высота панелек

        
        private List<OutBox> outs;

        public NewElement()
        {
            try
            {
                background = null;
                buttonsUp = new List<Button>();
                buttonsDown = new List<Button>();
                buttonsDel = new List<Button>();
                buttonsAdd = new List<Button>();
                panels = new List<Panel>();
                lines = new List<Line>();
                outs = new List<OutBox>();
                choice = null;
                dx = dy = 0;
                InitializeComponent();
                pbBackground.CreateGraphics();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public NewElement(string path) : this()
        {
            try
            {
                Regex regexPath = new Regex(@"(.*\\)[^\\]*");
                XmlTextReader reader = new XmlTextReader(path);
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.XmlDeclaration:
                            break;
                        case XmlNodeType.Element:
                            switch (reader.Name)
                            {
                                case "element":
                                    while (reader.MoveToNextAttribute())
                                    {
                                        switch (reader.Name)
                                        {
                                            case "background":
                                                Regex regex = new Regex(@"([^\\]*)\..*");
                                                tbBackground.Text = regex.Match(reader.Value).Groups[1].Value;
                                                try
                                                {
                                                    background = Image.FromFile(regexPath.Match(path).Groups[1].Value + tbBackground.Text + ".png");
                                                    pbBackground.Size = background.Size;
                                                }
                                                catch { }
                                                break;
                                            case "name":
                                                tbName.Text = reader.Value;
                                                break;
                                        }
                                    }
                                    break;
                                case "out":
                                    int x = 0;
                                    int y = 0;
                                    string type = "";
                                    string outRadix = "";
                                    string outName = "";
                                    while (reader.MoveToNextAttribute())
                                    {
                                        switch (reader.Name)
                                        {
                                            case "x":
                                                x = Convert.ToInt32(reader.Value);
                                                break;
                                            case "y":
                                                y = Convert.ToInt32(reader.Value);
                                                break;
                                            case "type":
                                                type = reader.Value;
                                                break;
                                            case "radix":
                                                outRadix = reader.Value;
                                                break;
                                            case "name":
                                                outName = reader.Value;
                                                break;
                                        }
                                    }
                                    int outRow = dgvOut.Rows.Add();
                                    dgvOut.Rows[outRow].Cells["RadixOut"].Value = outRadix;
                                    dgvOut.Rows[outRow].Cells["NameOut"].Value = outName;
                                    OutBox newBox = outs.Find(ob => ob.Name.Equals(outName));
                                    newBox.Location = new Point(x, y);
                                    newBox.Type = type;
                                    break;
                                case "in":
                                    string inRadix = "";
                                    string inName = "";
                                    string inDefault = "";
                                    while (reader.MoveToNextAttribute())
                                    {
                                        switch (reader.Name)
                                        {
                                            case "radix":
                                                inRadix = reader.Value;
                                                break;
                                            case "name":
                                                inName = reader.Value;
                                                break;
                                            case "default":
                                                inDefault = reader.Value;
                                                break;
                                        }
                                    }
                                    int inRow = dgvIn.Rows.Add();
                                    dgvIn.Rows[inRow].Cells["RadixIn"].Value = inRadix;
                                    dgvIn.Rows[inRow].Cells["NameIn"].Value = inName;
                                    dgvIn.Rows[inRow].Cells["DefaultIn"].Value = inDefault;
                                    break;
                                case "line":
                                    string image = "";
                                    while (reader.MoveToNextAttribute())
                                    {
                                        if (reader.Name.Equals("image"))
                                            image = reader.Value;
                                    }
                                    AddLine(regexPath.Match(path).Groups[1].Value + image);
                                    break;
                                case "condition":
                                    string conditionName = "";
                                    string value = "";
                                    string action = "";
                                    while (reader.MoveToNextAttribute())
                                    {
                                        switch (reader.Name)
                                        {
                                            case "name":
                                                conditionName = reader.Value;
                                                break;
                                            case "value":
                                                value = reader.Value;
                                                break;
                                            case "action":
                                                action = reader.Value;
                                                break;
                                        }
                                    }
                                    lines.Last().AddCondition(conditionName, value, action);
                                    break;
                            }
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        //загрузка фона
        private void bBackground_Click(object sender, EventArgs e)
        {
            try
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
                    pbBackground.Size = background.Size;
                    if (background.Height >= 300)
                    {
                        pMain.Width = 700;
                        pLines.Width = 600;
                    }
                    Invalidate();
                    MessageBox.Show("Фон загружен");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //метод, при отрисовки окна
        private void NewElement_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Size size = getSize();
                if (size.Height >= 300)
                {
                    pMain.Width = 700;
                    pLines.Width = 600;
                }

                Image buf = new Bitmap(pbBackground.Width, pbBackground.Height);
                Graphics gbuf = Graphics.FromImage(buf);
                gbuf.Clear(Color.White);
                if (background != null)
                    gbuf.DrawImage(background, 0, 0);
                foreach (OutBox ob in outs)
                    ob.Draw(gbuf);
                Graphics.FromHwnd(pbBackground.Handle).DrawImageUnscaled(buf, 0, 0);
                gbuf.Dispose();
                buf.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Size getSize()
        {
            try
            {
                int width = 0;
                int height = 0;
                if (background != null)
                {
                    width = background.Width;
                    height = background.Height;
                }
                foreach (Line l in lines)
                {
                    if (l.Height > height)
                        height = l.Height;
                    if (l.Width > width)
                        width = l.Width;
                }
                return new Size(width, height);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new Size(0, 0);
            }
        }

        //добавление условия для входов
        private void bAddIn_Click(object sender, EventArgs e)
        {
            AddLine("");
        }

        private void AddLine(string name)
        {
            try
            {
                Image image;
                if (name.Equals(""))
                {
                    image = Program.Loadimage(ref name);
                    if (image == null)
                    {
                        MessageBox.Show("Некорректная картинка");
                        return;
                    }
                }
                else
                {
                    try
                    {
                        image = Image.FromFile(name);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
                Regex regex = new Regex(@"([^\\]*)\..*");
                Line line = new Line(image, AddPanel(), dgvIn, regex.Match(name).Groups[1].Value);
                lines.Add(line);
                AddButtons();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //добавление кнопок на панель кнопок
        private void AddButtons()
        {
            try
            {
                Button bUp = new Button();
                bUp.Location = new Point(0, buttonsUp.Count * height);
                bUp.Size = new Size(40, 18);
                bUp.Text = "Up";
                bUp.Font = new Font(bUp.Font.Name, 6);
                buttonsUp.Add(bUp);
                bUp.Visible = false;
                pButtons.Controls.Add(bUp);

                Button bDown = new Button();
                bDown.Location = new Point(0, buttonsDown.Count * height + 22);
                bDown.Size = new Size(40, 18);
                bDown.Text = "Down";
                bDown.Font = new Font(bUp.Font.Name, 6);
                buttonsDown.Add(bDown);
                bDown.Visible = false;
                pButtons.Controls.Add(bDown);

                Button bDel = new Button();
                bDel.Location = new Point(45, buttonsDel.Count * height);
                bDel.Size = new Size(40, 18);
                bDel.Text = "X";
                bDel.Click += bDel_Click;
                buttonsDel.Add(bDel);
                pButtons.Controls.Add(bDel);

                Button bAdd = new Button();
                bAdd.Location = new Point(45, buttonsAdd.Count * height + 22);
                bAdd.Size = new Size(40, 18);
                bAdd.Text = "+";
                bAdd.Click += bAdd_Click;
                buttonsAdd.Add(bAdd);
                pButtons.Controls.Add(bAdd);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //добавление панели для настроек
        private Panel AddPanel()
        {
            try
            {
                Panel p = new Panel();
                p.Location = new Point(0, panels.Count * height);
                p.Size = new Size(pLines.Width - 10, height - 2);
                p.BackColor = Color.WhiteSmoke;
                p.AutoScroll = false;
                p.AutoSize = true;
                panels.Add(p);
                pLines.Controls.Add(p);
                return p;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new Panel();
            }
        }

        //удаление кнопок и панелей
        private void bDel_Click(object sender, EventArgs e)
        {
            try
            {
                int pos = buttonsDel.FindIndex(x => x.Equals(sender));
                if (pos == -1)
                    return;
                for (int i = pos; i < buttonsDel.Count; ++i)
                    buttonsDel[i].Location = new Point(buttonsDel[i].Location.X, buttonsDel[i].Location.Y - height);
                buttonsDel.RemoveAt(pos);

                for (int i = pos; i < buttonsDown.Count; ++i)
                    buttonsDown[i].Location = new Point(buttonsDown[i].Location.X, buttonsDown[i].Location.Y - height);
                buttonsDown.RemoveAt(pos);

                for (int i = pos; i < buttonsUp.Count; ++i)
                    buttonsUp[i].Location = new Point(buttonsUp[i].Location.X, buttonsUp[i].Location.Y - height);
                buttonsUp.RemoveAt(pos);

                for (int i = pos; i < buttonsAdd.Count; ++i)
                    buttonsAdd[i].Location = new Point(buttonsAdd[i].Location.X, buttonsAdd[i].Location.Y - height);
                buttonsAdd.RemoveAt(pos);

                for (int i = pos; i < panels.Count; ++i)
                    panels[i].Location = new Point(0, panels[i].Location.Y - height);
                panels.RemoveAt(pos);
                lines.RemoveAt(pos);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //добавление условия по клику кнопки
        private void bAdd_Click(object sender, EventArgs e)
        {
            try
            {
                lines[buttonsAdd.FindIndex(x => x == sender)].AddCondition();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        //изменения входных сигналов
        private void dgvIn_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                foreach (Line l in lines)
                    l.Update();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvIn_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (Line l in lines)
                    l.Update();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //изменения выходных сигналов
        private void dgvOut_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dgvr in dgvOut.Rows)
                {
                    if (dgvr.Cells[0].Value == null || dgvr.Cells["NameOut"].Value == null || dgvr.Cells["RadixOut"].Value == null)
                        continue;
                    string name = dgvr.Cells["NameOut"].Value.ToString();
                    string radix = dgvr.Cells["RadixOut"].Value.ToString();
                    OutBox ob = outs.Find(x => x.ToString().Equals(name));
                    if (ob == null)
                    {
                        int rad = 0;
                        try
                        {
                            rad = Convert.ToInt32(radix);
                        }
                        catch (Exception) { }

                        OutBox box = new OutBox(name, rad);
                        outs.Add(box);
                        pOut.Controls.Add(box.Panel);
                    }
                    else
                    {
                        try
                        {
                            ob.Radix = Convert.ToInt32(radix);
                        }
                        catch (Exception)
                        {
                            ob.Radix = 0;
                        }
                    }
                }

                for (int i = outs.Count - 1; i >= 0; --i)
                {
                    bool exist = false;
                    foreach (DataGridViewRow dgvr in dgvOut.Rows)
                    {
                        if (dgvr.Cells["NameOut"].Value != null && dgvr.Cells["NameOut"].Value.Equals(outs[i].ToString()))
                        {
                            exist = true;
                            break;
                        }
                    }
                    if (!exist)
                    {
                        pOut.Controls.Remove(outs[i].Panel);
                        outs.RemoveAt(i);
                    }
                }
                ChangeLocation();
                Invalidate();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //передвижение фигуры
        private void ChangeLocation()
        {
            try
            {
                int width = 0;
                int height = 0;
                foreach (OutBox box in outs)
                {
                    if (box.Panel.Width + width > pOut.Width + 10)
                    {
                        width = 0;
                        height += box.Panel.Height;
                    }
                    box.Panel.Location = new Point(width, height);
                    width += box.Panel.Width + 5;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //проверить корректность введённых данных
        private void bCheck_Click(object sender, EventArgs e)
        {
            try
            {
                Check();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //функция проверки наличия ошибок
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
            warnings = CheckWarnings();
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

        //проверка наличия предупреждений
        private List<string> CheckWarnings()
        {
            List<string> warnings = new List<string>();
            if (background == null)
                warnings.Add("Фон отсутствует.");
            if (dgvOut.RowCount == 1 && dgvIn.RowCount == 1)
                warnings.Add("Таблицы входов и выходов пустые.");
            for (int i = 0; i < lines.Count; ++i)
                warnings.AddRange(lines[i].CheckWarnings(i + 1, background));
            return warnings;
        }

        //проверка наличия ошибок
        private List<string> CheckErrors()
        {
            List<string> errors = new List<string>();
            if (tbName.Text == "")
                errors.Add("Имя элемента пустое.");
            errors.AddRange(CheckIn());
            errors.AddRange(CheckOut());
            errors.AddRange(CheckCondtions());
            errors.AddRange(CheckImage());
            return errors;
        }

        //проверка символа - названия входа/выхода
        private bool CheckSymbol(char c)
        {
            if (c <= 'z' && c >= 'a' || c <= 'Z' && c >= 'A' || c == '_' || c >= '0' && c <= '9')
                return true;
            else return false;
        }

        //проверка условий в линиях
        private List<string> CheckCondtions()
        {
            List<string> errors = new List<string>();
            for (int i = 0; i < lines.Count; ++i)
                errors.AddRange(lines[i].CheckErrors(i+1));
            return errors;
        }

        //проверка выходных сигналов
        private List<string> CheckOut()
        {
            List<string> errors = new List<string>();
            for (int i = 0; i < dgvOut.Rows.Count - 1; ++i)
            {
                if (dgvOut.Rows[i].Cells[0] == null)
                    continue;

                if (dgvOut.Rows[i].Cells["NameOut"].Value == null)
                    errors.Add("В " + (i + 1) + " строке в таблице выходов отсутствует имя.");
                else
                {
                    for (int j = i + 1; j < dgvOut.Rows.Count && dgvOut.Rows[i].Cells["NameOut"].Value != null; ++j)
                        if (dgvOut.Rows[j].Cells["NameOut"].Value != null
                            && dgvOut.Rows[j].Cells["NameOut"].Value.ToString().ToLower().Equals(dgvOut.Rows[i].Cells["NameOut"].Value.ToString().ToLower()))
                            errors.Add("Имя в " + (i + 1) + " строке выходов совпадает с именем в " + (j + 1) + " строке выходов.");
                    for (int j = 0; j < dgvIn.Rows.Count && dgvOut.Rows[i].Cells["NameOut"].Value != null; ++j)
                        if (dgvIn.Rows[j].Cells["NameIn"].Value != null
                            && dgvIn.Rows[j].Cells["NameIn"].Value.ToString().ToLower().Equals(dgvOut.Rows[i].Cells["NameOut"].Value.ToString().ToLower()))
                            errors.Add("Имя в " + (i + 1) + " строке выходов совпадает с именем в " + (j + 1) + " строке входов.");
                    for (int j = 0; j < dgvOut.Rows[i].Cells["NameOut"].Value.ToString().Length; ++j)
                        if (!CheckSymbol(dgvOut.Rows[i].Cells["NameOut"].Value.ToString()[j]))
                        {
                            errors.Add("Имя " + (i + 1) + " выхода содержит недопустимый символ в " + (j + 1) + " позиции.");
                            break;
                        }
                }

                if (dgvOut.Rows[i].Cells["RadixOut"].Value == null)
                    errors.Add("В " + (i + 1) + " строке в таблице выходов отсутствует число разрядов.");
                else
                    try
                    {
                        int radix = Convert.ToInt32(dgvOut.Rows[i].Cells["RadixOut"].Value);
                        if (radix <= 0)
                            errors.Add("Число разрядов должно быть положительно. Строка " + (i + 1) + " выходов");
                    }
                    catch (Exception)
                    {
                        errors.Add("Значение разрядов в " + (i + 1) + " строке выходов не может быть пробразовано в число.");
                    }
            }
            return errors;
        }

        //проверка изображений
        private List<string> CheckImage()
        {
            List<string> errors = new List<string>();
            for (int i = 0; i < lines.Count; ++i)
                for (int j = i + 1; j < lines.Count; ++j)
                    if (lines[i].Name.Equals(lines[j].Name) && lines[i].Hash != lines[j].Hash)
                        errors.Add("В " + (i + 1) + " и " + (j + 1) + " строках разные изображения с одинаковыми именами!");
            return errors;
        }
        
        //проверка въодных сигналов
        private List<string> CheckIn()
        {
            List<string> errors = new List<string>();
            for (int i = 0; i < dgvIn.Rows.Count - 1; ++i)
            {
                if (dgvIn.Rows[i].Cells[0] == null)
                    continue;

                if (dgvIn.Rows[i].Cells["NameIn"].Value == null)
                    errors.Add("В " + (i + 1) + " строке в таблице входов отсутствует имя.");
                else
                {
                    for (int j = i + 1; j < dgvIn.Rows.Count && dgvIn.Rows[i].Cells["NameIn"].Value != null; ++j)
                        if (dgvIn.Rows[j].Cells["NameIn"].Value != null &&
                            dgvIn.Rows[j].Cells["NameIn"].Value.ToString().ToLower().Equals(dgvIn.Rows[i].Cells["NameIn"].Value.ToString().ToLower()))
                            errors.Add("Имя в " + (i + 1) + " строке входов совпадает с именем в " + (j + 1) + " строке входов.");
                    for (int j = 0; j < dgvIn.Rows[i].Cells["NameIn"].Value.ToString().Length; ++j)
                        if (!CheckSymbol(dgvIn.Rows[i].Cells["NameIn"].Value.ToString()[j]))
                        {
                            errors.Add("Имя " + (i + 1) + " входа содержит недопустимый символ в " + (j + 1) + " позиции.");
                            break;
                        }
                }

                if (dgvIn.Rows[i].Cells["RadixIn"].Value == null)
                    errors.Add("В " + (i + 1) + " строке в таблице входов отсутствует число разрядов.");
                else
                    try
                    {
                        int radix = Convert.ToInt32(dgvIn.Rows[i].Cells["RadixIn"].Value);
                        if (radix <= 0)
                            errors.Add("Число разрядов должно быть положительно. Строка " + (i + 1) + " входов");
                    }
                    catch (Exception)
                    {
                        errors.Add("Значение разрядов в " + (i + 1) + " строке входов не может быть пробразовано в число.");
                    }

                if (dgvIn.Rows[i].Cells["DefaultIn"].Value != null)
                {
                    Regex regex = new Regex("(^[0-9]+$)|(^[01]+b$)|(^0[xX][0-9a-fA-F]+$)");
                    if (!dgvIn.Rows[i].Cells["DefaultIn"].Value.ToString().Equals("") 
                        && !regex.IsMatch(dgvIn.Rows[i].Cells["DefaultIn"].Value.ToString()))
                        errors.Add("Неверное значение по умолчанию в " + (i + 1) + "строке.");
                }
            }
            return errors;
        }

        //сохранение 
        private void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                int errorsCount = Check();
                if (errorsCount != 0)
                    MessageBox.Show("Сохранение невозможно. " + errorsCount + " ошибок.");
                else
                {
                    FolderBrowserDialog folder = new FolderBrowserDialog();
                    folder.Description = "Выбор директории для элемента";
                    string path = "";

                    if (folder.ShowDialog() == DialogResult.OK)
                    {
                        path = folder.SelectedPath + @"\" + tbName.Text;
                    }
                    else
                    {
                        MessageBox.Show("Сохранение отменено");
                        return;
                    }

                    if (Directory.Exists(path))
                    {
                        List<string> errors = CheckSave(path);
                        if (errors.Count != 0)
                        {
                            string message = "В директории " + path + " существуют следующие изобаржения.\nОни будут перезаписаны.\n";
                            foreach (string s in errors)
                                message += s + "\n";
                            if (MessageBox.Show(message, "Предупреждение о перезаписи", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                            {
                                MessageBox.Show("Сохранение отменено");
                                return;
                            }
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(path);
                    }

                    XmlTextWriter writer;
                    if (File.Exists(path + @"\" + tbName.Text + ".element"))
                    {
                        if (MessageBox.Show("Файл " + tbName.Text + ".element существует в директории " + path, "Предупреждение",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            writer = new XmlTextWriter(path + "\\" + tbName.Text + ".element", null);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        try
                        {
                            writer = new XmlTextWriter(path + "\\" + tbName.Text + ".element", null);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                    }
                    writer.Formatting = Formatting.Indented;
                    writer.Indentation = 4;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("element");
                    writer.WriteAttributeString("name", tbName.Text);
                    if (background != null)
                    {
                        writer.WriteAttributeString("background", tbBackground.Text + ".png");
                        WriteImage(path + "\\" + tbBackground.Text + ".png", background);
                    }
                    foreach (OutBox box in outs)
                        box.Write(writer);
                    foreach (DataGridViewRow dgvr in dgvIn.Rows)
                        if (dgvr.Cells["NameIn"].Value != null)
                        {
                            writer.WriteStartElement("in");//, dgvr.Cells["NameIn"].Value.ToString());
                            writer.WriteAttributeString("name", dgvr.Cells["NameIn"].Value.ToString());
                            writer.WriteAttributeString("radix", dgvr.Cells["RadixIn"].Value.ToString());
                            writer.WriteAttributeString("default", dgvr.Cells["DefaultIn"].Value == null ? "" : dgvr.Cells["DefaultIn"].Value.ToString());
                            writer.WriteEndElement();
                        }
                    foreach (Line l in lines)
                        l.Write(writer, path);

                    writer.WriteEndElement();
                    writer.Close();
                    MessageBox.Show("Элемент успешно сохранён");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //проверка наличия файлов
        private List<string> CheckSave(string path)
        {
            try
            {
                List<string> errors = new List<string>();
                for (int i = 0; i < lines.Count; ++i)
                    errors.AddRange(lines[i].CheckSave(path));
                if (File.Exists(path + @"\" + tbBackground.Text + ".png"))
                    errors.Add(tbBackground.Text + ".png");
                return errors;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<string>();
            }
        }

        //удаление строки
        private void dgvOut_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            Invalidate();
        }

        public static void WriteImage(string name, Image image)
        {
            try
            {
                if (!File.Exists(name) || Line.GetHash(image) != Line.GetHash(Image.FromFile(name)))
                    image.Save(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //передвижение мыши
        private void pbBackground_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (choice != null)
                    choice.Location = new Point(e.Location.X - dx, e.Location.Y - dy);
                Invalidate();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbBackground_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                choice = outs.Find(x => x.Location.X <= e.X && e.X <= x.Location.X + x.Size.Width &&
                            x.Location.Y <= e.Y && e.Y <= x.Location.Y + x.Size.Height);
                if (choice != null)
                {
                    dx = e.X - choice.Location.X;
                    dy = e.Y - choice.Location.Y;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pbBackground_MouseLeave(object sender, EventArgs e)
        {
            choice = null;
            dx = dy = 0;
        }

        private void pbBackground_MouseUp(object sender, MouseEventArgs e)
        {
            choice = null;
            dx = dy = 0;
        }
    }
}
