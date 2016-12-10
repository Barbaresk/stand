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
        public string StandPath { get; set; }
        public string StandName { get; set; }
        public bool StandExist { get; set; }
        //private Stand();
        private Stand stand;
        public MainForm()
        {
            InitializeComponent();
            StandPath = "";
            StandName = "";
        }

        private void newStand_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "Выбор директории для стенда";
            if(folder.ShowDialog() == DialogResult.OK)
            {
                StandPath = folder.SelectedPath;
            }
            StandName = "Stand0";
            Form form = new Request();
            form.Owner = this;
            form.ShowDialog();

            stand = new Stand(StandPath + "\\" + StandName);
            stand.Create();
            Invalidate();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            lDirectory.Text = StandPath;
            lStand.Text = StandName;
        }

        private void newElement_Click(object sender, EventArgs e)
        {
            Form form = new NewElement();
            form.Show();
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
            Form form = new NewObject();
            form.Show();
        }
    }
}
