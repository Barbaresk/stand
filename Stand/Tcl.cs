
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualStand
{
    public class tclwithc 
    {
        private
            List<bool> arraybool;
            List<int> arrayint;
            string arrayhex;
        bool b1;
        bool b2;
        public
        tclwithc()
        {
            arraybool= new List<bool>();
        }

        public bool init()
        {
            return true;
        }

        public
        tclwithc(List<bool> massive)
        {
            arraybool = massive;
        }

        public int modern()
        {
            int i=0;
            arrayint = new List<int>();
            while (i != arraybool.Count)
            {
                if (arraybool[i] == true)
                    arrayint.Add(1);
                else
                    arrayint.Add(0);
                i++;
            }
        return 1;
        }

        public bool set(List<bool> l)
        {
            b1 = l[64 + 4];
            b2 = l[64 + 5];
            return true;
        }

        public List<bool> get()
        {
            List<bool> list = new List<bool>();
            list.AddRange(new bool[]{ !b1 && !b2, b1 && !b2, !b1 && b2, b1 && b2, false, false, true, false, false, true});
            return list;
        }

        public int Hexstring()
        {
            string str="";
            string str4symbol="";
            int i=0;
            while (i != arrayint.Count)
            {
                str += Convert.ToString(arrayint[i]);
                i++;
            }
            i=0;
            while (i != str.Length)
            {
                str4symbol = str.Substring(i, 4);
                i = i + 4;
                switch (str4symbol)
                {
                    case "0000": 
                        {
                            arrayhex += "0";
                            continue;
                        }
                    case "0001":
                        {
                            arrayhex += "1";
                            continue;
                        }
                    case "0010":
                        {
                            arrayhex += "2";
                            continue;
                        }
                    case "0011":
                        {
                            arrayhex += "3";
                            continue;
                        }
                    case "0100":
                        {
                            arrayhex += "4";
                            continue;
                        }
                    case "0101":
                        {
                            arrayhex += "5";
                            continue;
                        }
                    case "0110":
                        {
                            arrayhex += "6";
                            continue;
                        }
                    case "0111":
                        {
                            arrayhex += "7";
                            continue;
                        }
                    case "1000":
                        {
                            arrayhex += "8";
                            continue;
                        }
                    case "1001":
                        {
                            arrayhex += "9";
                            continue;
                        }
                    case "1010":
                        {
                            arrayhex += "A";
                            continue;
                        }
                    case "1011":
                        {
                            arrayhex += "B";
                            continue;
                        }
                    case "1100":
                        {
                            arrayhex += "C";
                            continue;
                        }
                    case "1101":
                        {
                            arrayhex += "D";
                            continue;
                        }
                    case "1110":
                        {
                            arrayhex += "E";
                            continue;
                        }
                    case "1111":
                        {
                            arrayhex += "F";
                            continue;
                        }
                    default:
                        return 0;
                }
            }
            return 1;
        }
        public int sethex()
        {
            char correctbit ='1';
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory="C:\\xillinx\\14.7\\ISE_DS\\ISE\\bin\\nt";
            startInfo.FileName = "xtclsh.exe";
            startInfo.Arguments = "tcltest.tcl "+"-dig "+arrayhex+" "+correctbit;
            process.StartInfo = startInfo;
            process.Start();
            return 1;
        }
        public int gethex()
        {
            char correctbit = '0';
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory = "C:\\xillinx\\14.7\\ISE_DS\\ISE\\bin\\nt";
            startInfo.FileName = "xtclsh.exe";
            startInfo.Arguments = "tcltest.tcl " + "-dig " + arrayhex + " " + correctbit;
            process.StartInfo = startInfo;
            // process.Start();
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\\xillinx\\14.7\\ISE_DS\\ISE\\bin\\nt\\test");
            arrayhex = file.ReadLine();
            file.Close();
            return 1;
        }
        public int DecodeHexString ()
        {
            int i = 0;
            string str = "";
            string symbol;
            while (i != arrayhex.Length)
            {
                symbol = arrayhex.Substring(i, 1);
                i++;
                switch (symbol)
                {
                    case "0":
                        {
                            str += "0000";
                            continue;
                        }
                    case "1":
                        {
                            str += "0001";
                            continue;
                        }
                    case "2":
                        {
                            str += "0010";
                            continue;
                        }
                    case "3":
                        {
                            str += "0011";
                            continue;
                        }
                    case "4":
                        {
                            str += "0100";
                            continue;
                        }
                    case "5":
                        {
                            str += "0101";
                            continue;
                        }
                    case "6":
                        {
                            str += "0110";
                            continue;
                        }
                    case "7":
                        {
                            str += "0111";
                            continue;
                        }
                    case "8":
                        {
                            str += "1000";
                            continue;
                        }
                    case "9":
                        {
                            str += "1001";
                            continue;
                        }
                    case "A":
                        {
                            str += "1010";
                            continue;
                        }
                    case "B":
                        {
                            str += "1011";
                            continue;
                        }
                    case "C":
                        {
                            str += "1100";
                            continue;
                        }
                    case "D":
                        {
                            str += "1101";
                            continue;
                        }
                    case "E":
                        {
                            str += "1110";
                            continue;
                        }
                    case "F":
                        {
                            str += "1111";
                            continue;
                        }
                    default:
                        return 0;
                }
            }
            i=0;
            arraybool.Clear();
            while (i != str.Length)
            {
                if (str[i] == 1)
                    arraybool.Add(true);
                else
                    arraybool.Add(false);
            }
            return 1;
        }
        public List<bool> getarraybool()
        {
            List<bool> list = new List<bool>();
            for (int i = 0; i < 64; ++i)
                list.Add(false);
            string str = "run";
            foreach (char c in str)
                for (UInt16 i = 0, k = Convert.ToUInt16(c); i < 16; i++, k /= 2)
                    list.Add(k % 2 == 1);
            for (int i = 0; i < 16; ++i)
                list.Add(false);
            str = "diod_panel";
            foreach (char c in str)
                for (UInt16 i = 0, k = Convert.ToUInt16(c); i < 16; i++, k /= 2)
                    list.Add(k % 2 == 1);
            for (int i = 0; i < 16; ++i)
                list.Add(false);
            return list;
            //return arraybool;
        }

 
    }
    class Program_
    {
        static void Main_(string[] args)
        {
            List<bool> listbol = new List<bool>();
            int i = 0;
            while (i != 64)
            {
                listbol.Add(true);
                i++;
            }
            tclwithc mas = new tclwithc(listbol);
            mas.modern();
            mas.Hexstring();
            //mas.sethex();
            mas.gethex();
            mas.DecodeHexString();
            
        }
    }
}
