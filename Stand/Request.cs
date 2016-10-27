using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VirtualStand
{
    public partial class Request : Form
    {
        MainForm form;
        public Request()
        {
            InitializeComponent();
        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            form = this.Owner as MainForm;
            //form.StandName = tbStand.Text;
            if (File.Exists(form.StandPath + "\\" + tbStand.Text))
            {
                DialogResult dialog = MessageBox.Show(
                    "Файл " + tbStand.Text + " существует в директории " + form.StandPath +
                    "\nВы хотите перезаписать файл?",
                    "Подтвеждение замены", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    MessageBox.Show("Имя " + tbStand.Text + " успешно введено.");
                    form.StandName = tbStand.Text;
                    Owner.Update();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Имя " + tbStand.Text + " успешно введено.");
                form.StandName = tbStand.Text;
                Owner.Update();
                Close();
            }
        }
    }
}
