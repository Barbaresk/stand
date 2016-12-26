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
    /// <summary>
    /// Класс для хранения одного из составных термов условия возникновения слоя изображения.
    /// Небходим при созданиии элемента.
    /// </summary>
    class Box
    {

        Panel panel;
        ComboBox signalName;     //имя сигналов
        TextBox signalValue; //значение
        ComboBox variants;   // =, <, >
        DataGridView dgv;
        Button cancel;
        Line line;
        
        public string Action
        {
            get
            {
                return variants.Text;
            }
            set
            {
                variants.Text = value.Equals("=") ? "=" : variants.Text == "g" ? ">" : "<";
            }
        }

        public string Value
        {
            get
            {
                return signalValue.Text;
            }
            set
            {
                signalValue.Text = value;
            }
        }

        public string Signal
        {
            get
            {
                return signalName.Text;
            }
            set
            {
                signalName.Text = value;
            }
        }

        public Panel Panel
        {
            get
            {
                return panel;
            }
        }

        public Box(Panel p, DataGridView dgv, Line line)
        {
            panel = p;
            this.line = line;
            this.dgv = dgv;
            signalName = new ComboBox();
            signalName.Location = new Point(10, 10);
            signalName.Size = new Size(60, 20);
            for (int i = 0; i < dgv.Rows.Count && dgv.Rows[i].Cells[0].Value != null; ++i)
                signalName.Items.Add(dgv.Rows[i].Cells["NameIn"].Value);
            panel.Controls.Add(signalName);

            variants = new ComboBox();
            variants.Location = new Point(80, 10);
            variants.Size = new Size(40, 20);
            variants.Items.AddRange(new string[] { ">", "<", "=" });
            variants.Text = "=";
            panel.Controls.Add(variants);

            signalValue = new TextBox();
            signalValue.Location = new Point(130, 10);
            signalValue.Size = new Size(60, 20);
            panel.Controls.Add(signalValue);

            cancel = new Button();
            cancel.Location = new Point(200, 10);
            cancel.Size = new Size(20, 20);
            cancel.Text = "X";
            cancel.Click += bCancel_Click;
            panel.Controls.Add(cancel);
        }

        //добавление условия для входов
        private void bCancel_Click(object sender, EventArgs e)
        {
            line.Remove(this);
        }

        public void Move()
        {
            panel.Location = new Point(panel.Location.X - panel.Width, panel.Location.Y);
        }


        public void Update()
        {
            for (int i = 0; i < dgv.Rows.Count && dgv.Rows[i].Cells[0].Value != null; ++i)
                if(!signalName.Items.Contains(dgv.Rows[i].Cells["NameIn"].Value))
                    signalName.Items.Add(dgv.Rows[i].Cells["NameIn"].Value);
        }

        public List<string> Check(int lineNum, int boxNum)
        {
            List<string> errors = new List<string>();
            bool exist = false;
            for (int i = 0; i < dgv.RowCount; ++i)
                if (dgv.Rows[i].Cells["NameIn"].Value != null && dgv.Rows[i].Cells["NameIn"].Value.Equals(signalName.Text))
                    exist = true;
            if (!exist)
                errors.Add("Неверное имя входа в " + boxNum + " условии " + lineNum + " строки");
            if (variants.Text != "=" && variants.Text != ">" && variants.Text != "<")
            {
                errors.Add("Некорретный знак в " + boxNum + " условии " + lineNum + " строки");
                return errors;
            }
            if(variants.Text == "=")
            {
                Regex regEq = new Regex("(^[0-9uU]+$)|(^[01uU]+b$)|(^0[xX][0-9a-fA-FuU]+$)");
                if (!regEq.IsMatch(signalValue.Text))
                    errors.Add("" + boxNum + " условие " + lineNum + " строки содержит недопустимое значение.");
            }
            else
            {
                Regex regNEq = new Regex("(^[0-9]+$)|(^0[xX][0-9a-fA-F]+$)");
                if (!regNEq.IsMatch(signalValue.Text))
                    errors.Add("" + boxNum + " условие " + lineNum + " строки содержит недопустимое значение.");
            }
            return errors;
        }

        public void Write(XmlTextWriter writer)
        {
            writer.WriteStartElement("condition");
            writer.WriteAttributeString("name", signalName.Text);
            writer.WriteAttributeString("value", signalValue.Text);
            writer.WriteAttributeString("action", variants.Text == "=" ? "=" : variants.Text == ">" ? "g" : "l");
            writer.WriteEndElement();
        }
    }
}
