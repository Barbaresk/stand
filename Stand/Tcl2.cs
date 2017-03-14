
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace CA
{
    class tclwithc 
    {
        private
            List<bool> arraybool;
            List<int> arrayint;
            string arrayhex;
            string handle;
        string coreRef;
        public
        tclwithc()
        {
            arraybool= new List<bool>();
            int i = 0;
            while (i!=arraybool.Count) 
            {
                arraybool.Add(false);
                i++;
            }
                  }
        public void setarrayhex(string s)
        {
            arrayhex = s;
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
        //------------------------------------------------
        public void gethandlefromfile()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\\xilinx\\14.7\\ISE_DS\\ISE\\bin\\nt\\handle.txt");
            handle = file.ReadLine();
            file.Close();
        }

        public void getcoreReffromfile()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\\xilinx\\14.7\\ISE_DS\\ISE\\bin\\nt\\coreRef.txt");
            coreRef = "\""+file.ReadLine()+ "\"";
            file.Close();
        }

        public string gethandle()
        {
            return handle;
        }

        public string getcoreRef()
        {
            return coreRef;
        }

        //-----------------------------------------------
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
        public int sethex( List<bool> listbool)
        {
            
            arrayhex = "";
            string modebit ="1";
            string write_string, read_string = "", check_read_string = "", argument = " ";
            System.IO.StreamReader file = null;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.WorkingDirectory = @"C:\xilinx\14.7\ISE_DS\ISE\bin\nt";
            startInfo.FileName = "xtclsh.exe";
            arraybool = listbool;
            for (int j = 0; listbool.Count % 64 !=0; j++)
                listbool.Add(false);
            modern();
            Hexstring();
            int i = 0;
            string correctbit = "4";
            while (i < arrayhex.Length)
            {   
                argument = "";
                write_string = "0";//
                write_string += arrayhex.Substring(i,16);
                write_string += correctbit;//----------------
                argument += "cs_tcl.tcl ";
                argument += "-dig ";
                argument += write_string;
                argument += " ";
                argument += modebit;
                startInfo.Arguments = argument;
                process.StartInfo = startInfo;
                process.StartInfo.UseShellExecute = true;
                process.Start();
                process.WaitForExit();
                process.Close();
                modebit = "0";
                
                if (correctbit == "4" || correctbit == "5" || correctbit == "6" || correctbit == "7")
                    while (true)
                    {
                        
                        argument = "";
                        argument += "cs_tcl.tcl ";
                        argument += "-dig ";
                        argument += "null";//-----------------------------------------------
                        argument += " ";
                        argument += modebit;
                        startInfo.Arguments = argument;
                        process.StartInfo = startInfo;
                       
                        process.Start();
                        process.WaitForExit();
                        process.Close();
                       
                        file = new System.IO.StreamReader(@"C:\\xilinx\\14.7\\ISE_DS\\ISE\\bin\\nt\\check_line.txt");
                        read_string = file.ReadLine();
                        file.Close();
                        check_read_string = read_string.Substring(17,1);
                       
                        if (check_read_string == "4" || check_read_string == "5" || check_read_string == "6" || check_read_string == "7")
                            break;
                    }
                else
                    while (true)
                    {
                        argument = "";
                        argument += "cs_tcl.tcl ";
                        argument += "-dig ";
                        argument += "null";//-----------------------------------------------
                        argument += " ";
                        argument += modebit;
                        startInfo.Arguments = argument;
                        process.StartInfo = startInfo;
                        process.Start();
                        process.WaitForExit();
                        process.Close();
                        file = new System.IO.StreamReader(@"C:\\xilinx\\14.7\\ISE_DS\\ISE\\bin\\nt\\check_line.txt");
                        read_string = file.ReadLine();
                        file.Close();
                        check_read_string = read_string.Substring(17, 1);

                        if (check_read_string == "8" || check_read_string == "9" || check_read_string == "A" || check_read_string == "B")
                            break;
                    }
                
                if (correctbit == "4" || correctbit == "5" || correctbit == "6"  || correctbit == "7")
                    correctbit = "8";
                else
                {
                    correctbit = "4";
                }
                i += 16;
                modebit = "1";
            }
            
            file.Close();
            modebit = "1";
            write_string = "000000000000000000";
            argument = "";
            argument += "cs_tcl.tcl ";
            argument += "-dig ";
            argument += write_string;
            argument += " ";
            argument += modebit;
            startInfo.Arguments = argument;
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = true;
            process.Start();
            process.Close();
            return 1;
        }

        public List<bool> gethex()
        {
            arrayhex = "";
            char modernbit = '1';
            System.Diagnostics.Process proces = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.WorkingDirectory =@"C:\xilinx\14.7\ISE_DS\ISE\bin\nt";
            startInfo.FileName = "xtclsh.exe";
            string str = "", read_string, correct_read_string = "";
            startInfo.Arguments = "cs_tcl.tcl " + "-dig " + "000000000000000002" + " " + modernbit;
            proces.StartInfo = startInfo;
            proces.StartInfo.UseShellExecute = true;
            proces.Start();
            proces.WaitForExit();
            proces.Close();
            modernbit = '0';
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\xilinx\14.7\ISE_DS\ISE\bin\nt\check_line.txt");
            read_string = file.ReadLine();
            file.Close();
            str = read_string.Substring(17, 1);
            if (str == "0" && str == "4" && str == "8" && str == "C")
            {
                return arraybool;
            }
            else
            {
                correct_read_string = "2";
            }
                while (true)
                {
                     modernbit = '1';
                     startInfo.Arguments = "cs_tcl.tcl " + "-dig " + "00000000000000000"+correct_read_string + " " + modernbit;
                       proces.Start();
                   proces.WaitForExit();
                  proces.Close();
                modernbit = '0';
                file = new System.IO.StreamReader(@"C:\xilinx\14.7\ISE_DS\ISE\bin\nt\check_line.txt");
                    read_string = file.ReadLine();
                     file.Close();
                    str = read_string.Substring(17, 1);
                    while (true)
                    {
                        proces.Start();
                    proces.WaitForExit();
                    proces.Close();
                    file = new System.IO.StreamReader(@"C:\xilinx\14.7\ISE_DS\ISE\bin\nt\check_line.txt");
                        read_string = file.ReadLine();
                       file.Close();
                        str = read_string.Substring(17, 1);
                        if (str == "0" || str == "4" || str == "8" || str == "C")
                            break;
                        if (correct_read_string=="1")
                        {
                            if (str == "1" || str == "5" || str == "9" || str == "D")
                            {
                                correct_read_string = "2";
                                arrayhex += read_string.Substring(1, 16);
                                break;
                            }
                        }
                        else
                        {
                            if (str == "2" || str == "7" || str == "A" || str == "E")
                            {
                                correct_read_string = "1";
                            arrayhex += read_string.Substring(1, 16);
                            break;
                            }
                        }
                   }
                    if (str == "0" || str == "4" || str == "8" || str == "C")
                        break; 
               }
            DecodeHexString();
            proces.Close();
            return arraybool;
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
                if (str[i] == '1')
                    arraybool.Add(true);
                else
                    arraybool.Add(false);
                i++;

            }
            return 1;
        }
        
        public bool init()
        {
            string file = @"C:\xilinx\14.7\ISE_DS\ISE\bin\nt\cs_tcl.tcl";
            bool check;
            check=File.Exists(file);
            if (check)
            {
                file = @"c:\xilinx\14.7\ISE_DS\ISE\bin\nt\xtclsh.exe";
                check = File.Exists(file);
                if (check)
                {
                    
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.WorkingDirectory = @"C:\xilinx\14.7\ISE_DS\ISE\bin\nt\";
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "xtclsh.exe cs_tcl.tcl -dig";
                    startInfo.RedirectStandardInput = false;
                    startInfo.RedirectStandardOutput = false;
                    startInfo.RedirectStandardError = false;
                    startInfo.UseShellExecute = false;
                    //startInfo.CreateNoWindow = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    //process.StandardInput.WriteLine("800000000000000000 1 3");
                    /*startInfo.WorkingDirectory = @"C:\xilinx\14.7\ISE_DS\ISE\bin\nt";
                    startInfo.FileName = "xtclsh.exe";
                    startInfo.Arguments = " cs_tcl.tcl -dig 000000000000000000 1 " + handle + " " + coreRef;
                    process.StartInfo = startInfo;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();                 
                    process.Close();
                    
                    startInfo.WorkingDirectory = @"C:\xilinx\14.7\ISE_DS\ISE\bin\nt";
                    startInfo.FileName = "xtclsh.exe";
                    startInfo.Arguments = " cs_tcl.tcl -dig 000000000000000034 1 " + handle + " " + coreRef;
                    process.StartInfo = startInfo;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                    process.Close();
                    startInfo.WorkingDirectory = @"C:\xilinx\14.7\ISE_DS\ISE\bin\nt";
                    startInfo.FileName = "xtclsh.exe";
                    startInfo.Arguments = " cs_tcl.tcl -dig 000000000000000000 1 " + handle + " " + coreRef;
                    process.StartInfo = startInfo;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                    process.WaitForExit();
                    process.Close();*/
                    return true;
                }
                else
                    Console.WriteLine("no exe file");
                    Console.ReadLine();
                    return false;
            }
            else
                Console.WriteLine("no tcl file");
                Console.ReadLine();
                return false; 
        }
    }

}
