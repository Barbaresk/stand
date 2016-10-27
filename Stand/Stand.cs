using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace VirtualStand
{
    class Stand
    {
        private string path;
        public Stand(string path)
        {
            this.path = path;
        }

        public void Create()
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(path, null);
                writer.WriteStartDocument();
                writer.WriteStartElement("Stand");
                writer.WriteEndElement();
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно создать файл\n" + ex.Message);
            }
        }
    }
}
