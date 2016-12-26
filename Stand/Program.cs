using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualStand
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            logger.Info("Application Start");
            Application.Run(new MainForm());
        }

        public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static string GetFile(string title, string filter)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = filter;
                dialog.Title = title;

                if (dialog.ShowDialog() == DialogResult.OK)
                    return dialog.FileName;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //загрузка изображения
        public static Image Loadimage(ref string name)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Изображения |*.png";
                dialog.Title = "Поиск изображения";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    name = dialog.FileName;
                    return Image.FromFile(dialog.FileName);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }

    }
}
