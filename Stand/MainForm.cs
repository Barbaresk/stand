using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualStand;

namespace VirtualStand
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
 
        }

        private void newElement_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new NewElement();
                form.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка при создании формы: " + ex.Message);
            }
        }

        private void openElement_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Изображения |*.element";
                dialog.Title = "Поиск элемента";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Form form = new NewElement(dialog.FileName);
                    form.ShowDialog(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void newObject_Click(object sender, EventArgs e)
        {
            try
            {
                Form form = new NewObject();
                form.Show();
                   
            }
            catch(Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка: " + ex.Message);
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AboutBox about = new AboutBox();
                about.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка: " + ex.Message);
            }
        }

        private void bCreateElement_Click(object sender, EventArgs e)
        {
            Form form = new NewElement();
            form.Show();
        }

        private void bOpenElement_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Изображения |*.element";
                dialog.Title = "Поиск элемента";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Form form = new NewElement(dialog.FileName);
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void bCreateObject_Click(object sender, EventArgs e)
        {
            Form form = new NewObject();
            form.Show();
        }

        private void bStand_Click(object sender, EventArgs e)
        {
            Form form = new StandRun();
            form.Show();
        }
    }
}
