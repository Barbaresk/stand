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
using CA;
using System.Diagnostics;

namespace VirtualStand
{
    /// <summary>
    /// Форма - непосредственно стенд. Именно на этой форме отображаются элементы, используемые в стенде.
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

        private void update()
        {
            while (true)
            {
                Thread.Sleep(25);
                Invalidate();
            }
        }

        private void init()
        {
            
           
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
            while ((names = mas.gethex()).Count == 0)
                Thread.Sleep(1000);
            tbError.Invoke(new Action<string>(s => tbError.Text = s), "Инициализация прошла успешно\nДанные успешно получены.");
            List<string> strNames = getNames(names);
            foreach (string s in strNames)
                try
                {
                    items.Add(new Subject(s + @"\" + s + ".object"));
                }
                catch(System.IO.DirectoryNotFoundException e)
                {
                    MessageBox.Show(e.Message);
                }
            Run();
        }

        public void Run()
        {
            List<bool> base64 = GetEmptySend();
            while (true)
            {
                List<bool> send = new List<bool>();
                send.AddRange(base64);
                foreach (Subject s in items)
                {
                    var bufIn = StandRun.GetEmptyList(s.RadixIn);
                    bufIn.Reverse();
                    send.AddRange(bufIn);
                    var bufOut = s.GetValue();
                    bufOut.Reverse();
                    send.AddRange(bufOut);
                }
                reverse(send);
                mas.sethex(send);            
                List<bool> recive = mas.gethex();
                reverse(recive);
                recive.Reverse();
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
                            recive.CopyTo(recive.Count - (pos + k) - i.Radix, port, 0, i.Radix);
                            port.Reverse();
                            v[i.Name] = new List<bool>(port);
                            k += i.Radix;
                        }
                        pos += s.RadixIn + s.RadixOut;
                        s.SetDefault(v);
                    }
                }
                Invalidate();
            }
        }

        public static List<bool> GetEmptyList(int k)
        {
            List<bool> list = new List<bool>(k);
            for (int i = 0; i < k; ++i)
                list.Add(false);
            return list;
        }
        /// <summary>
        /// функция, которая возвращает заготовку для отправки. 
        /// массив состоит из 1, 31 нуля, количества разрядов (1
        /// </summary>
        /// <returns></returns>
        private List<bool> GetEmptySend()
        {
            int capacity = 0;
            foreach (Item i in items)
                capacity += i.RadixIn + i.RadixOut;
            List<bool> bits = new List<bool>(64 + capacity);
            bits.Add(true);
            bits.AddRange(StandRun.GetEmptyList(15));
            for (int i = 32, j = capacity; i < 48; ++i, j >>= 1)
                bits.Add(Convert.ToBoolean(j & 1));
            bits.AddRange(StandRun.GetEmptyList(32));
            //bits.Reverse();
            return bits;
        }

        public void reverse(List<bool> list)
        {
            while (list.Count % 64 != 0)
                list.Add(false);
            for(int i = 0; i < list.Count; i+=64)
                for(int j = 0; j < 32; ++j)
                {
                    bool buf = list[i + j];
                    list[i + j] = list[i + 63 - j];
                    list[i + 63 - j] = buf;
                }
        }

        private List<string> getNames(List<bool> bits)
        {
            List<string> names = new List<string>();
            bool create = true;

            for (int pos = 0; pos < bits.Count; pos += 64)
                for(int i = 0; i < 2; ++i)
                    for(int j = 0; j < 16; ++j)
                    {
                        bool buf = bits[pos + i * 16 + j];
                        bits[pos + i * 16 + j] = bits[pos + (3 - i) * 16 + j];
                        bits[pos + (3 - i) * 16 + j] = buf;
                    }


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
            
            //names[0] = "inc";
            return names;   
        }

        private void StandRun_Paint(object sender, PaintEventArgs e)
        {
            try
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
            catch { }
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
