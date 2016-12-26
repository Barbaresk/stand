using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualStand
{
    /// <summary>
    /// Форма - непосредственно стенд. Именно на этой форме отображаются элементы, используемы в стенде.
    /// </summary>
    public partial class StandRun : Form
    {
        private List<Subject> items;
        private Item choice;
        private int fx;
        private int fy;
        private bool flag;

        public StandRun()
        {
            InitializeComponent();
            items = new List<Subject>();
            flag = true;
        }

        private tclwithc mas;

        private void bStart_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                Thread myThread = new Thread(init); //Создаем новый объект потока (Thread)
                
                myThread.Start(); //запускаем поток
            }
        }

        private void init()
        {
            Thread.Sleep(2000);
            mas = new tclwithc();
            for (int i = 0; !mas.init() && i < 10; ++i)
                if (i == 9)
                {
                    mas = null;
                    tbError.Text = "Инициализация не удалась";
                    return;
                }
                else
                    Thread.Sleep(1000);
            if (tbError.InvokeRequired) tbError.Invoke(new Action<string>((s) => tbError.Text = s), "Инициализация прошла успешно");
            else tbError.Text = "Инициализация прошла успешно";

            List<bool> names = new List<bool>();
            while ((names = mas.getarraybool()).Count == 0)
                Thread.Sleep(1000);
            tbError.Invoke(new Action<string>(s => tbError.Text = s), "Инициализация прошла успешно\nДанные успешно получены.");
            List<string> strNames = getNames(names);
            foreach (string s in strNames)
                items.Add(new Subject(s + @"\" + s + ".object"));
            Run();
        }

        public void Run()
        {
            List<bool> base64 = GetEmptySend();
            while (true)
            {
                Thread.Sleep(10);
                List<bool> send = new List<bool>();
                send.AddRange(base64);
                foreach (Subject s in items)
                {
                    send.AddRange(StandRun.GetEmptyList(s.RadixIn));
                    send.AddRange(s.GetValue());
                }
                Program.logger.Info("write");
                mas.set(send);
                Thread.Sleep(10);
                List<bool> recive = mas.get();
                if(recive.Count != 0)
                {
                    int pos = 0;
                    foreach(Subject s in items)
                    {
                        Value v = new Value();
                        int k = 0;
                        foreach (InPin i in s.InPins)
                        {
                            bool[] port = new bool[i.Radix];
                            recive.CopyTo(pos + k, port, 0, i.Radix); 
                            v[i.Name] = new List<bool>(port);
                            k += s.RadixIn;
                        }
                        pos += s.RadixIn + s.RadixOut;
                        s.SetDefault(v);
                    }
                }
                //Invalidate();
            }
        }

        public static List<bool> GetEmptyList(int k)
        {
            List<bool> list = new List<bool>(k);
            for (int i = 0; i < k; ++i)
                list.Add(false);
            return list;
        }

        private List<bool> GetEmptySend()
        {
            int capacity = 0;
            foreach (Item i in items)
                capacity += i.RadixIn + i.RadixOut;
            List<bool> bits = new List<bool>(64 + capacity);
            bits.Add(true);
            bits.AddRange(StandRun.GetEmptyList(31));
            for (int i = 32, j = capacity; i <= 47; ++i, capacity >>= 1)
                bits.Add(Convert.ToBoolean(j & 1));
            bits.AddRange(StandRun.GetEmptyList(16));
            return bits;
        }

        private List<string> getNames(List<bool> bits)
        {
            List<string> names = new List<string>();
            bool create = true;
            for (int i = 64; i < bits.Count; i += 16)
            {
                UInt16 k = 0;
                for (int j = 15; j >= 0 && i + j < bits.Count; --j)
                {
                    k <<= 1;
                    k |= Convert.ToUInt16(bits[i + j]);
                }
                UInt16 l = Convert.ToUInt16('e');
                if (k == 0)
                    create = true;
                else
                {
                    if (create)
                    {
                        names.Add(new string(Convert.ToChar(k), 1));
                        create = false;
                    }
                    else
                    {
                        names[names.Count - 1] += Convert.ToChar(k);
                    }
                }
            }
            return names;   
        }

        private void StandRun_Paint(object sender, PaintEventArgs e)
        {
            Image buf = new Bitmap(pbStand.Width, pbStand.Height);
            Graphics gbuf = Graphics.FromImage(buf);
            gbuf.Clear(Color.White);
            foreach (Item i in items)
            {
                i.DrawPanel(gbuf, i.GetDefault(), 0, 0, pbStand);
            }
            Graphics.FromHwnd(pbStand.Handle).DrawImageUnscaled(buf, 0, 0);
            gbuf.Dispose();
            buf.Dispose();
        }

        private void pbStand_MouseDown(object sender, MouseEventArgs e)
        {
            for (int k = items.Count - 1; k >= 0; k--)
            {
                Subject i = items[k];
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

        private void pbStand_MouseLeave(object sender, EventArgs e)
        {
            choice = null;
            Invalidate();
        }

        private void pbStand_MouseMove(object sender, MouseEventArgs e)
        {
            if (choice != null)
            {
                choice.Move(e.X - fx, e.Y - fy);
                fx = e.X;
                fy = e.Y;
            }
            Invalidate();
        }

        private void pbStand_MouseUp(object sender, MouseEventArgs e)
        {
            choice = null;
            Invalidate();
        }
    }
}
