
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace CA
{
    class tclwithc 
    {
        private
            List<bool> arraybool;
            List<int> arrayint;
            string arrayhex;
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
            string modebit ="1";
            string write_string, read_string = "", check_read_string = "", argument = " ";
            System.IO.StreamReader file = null;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
       
            //Console.WriteLine("7777777777777777777777777777777777");
            //Console.ReadLine();

            startInfo.WorkingDirectory = @"C:\xilinx\14.7\ISE_DS\ISE\bin\nt";
            startInfo.FileName = "xtclsh.exe";
            arraybool = listbool;

            //Console.WriteLine("7777777777777777777777777777777777");
            //Console.ReadLine();

            for (int j = 0; j != 64 - listbool.Count % 64 && listbool.Count % 64 !=0; j++)
                listbool.Add(false);

            //Console.WriteLine("111111111111111111111111111111111");
            //Console.ReadLine();

            modern();

            //Console.WriteLine("222222222222222222222222222222222222");
            //Console.ReadLine();

            Hexstring();

            //Console.WriteLine("33333333333333333333333333333333333");
            //Console.ReadLine();
            
            int i = 0;
            string correctbit = "4";
            while (i < arrayhex.Length)
            {
              //  Console.WriteLine("7777777777777777777777777777777777");
               // Console.ReadLine();

                write_string = "0";//
                write_string += arrayhex.Substring(i,i+16);
                write_string += correctbit;//----------------
                argument += "cs_tcl.tcl ";
                argument += "-dig ";
                argument += write_string;
                argument += " ";
                argument += modebit;
                startInfo.Arguments = argument.Substring(0,37);
                process.StartInfo = startInfo;
                process.StartInfo.UseShellExecute = true;
                process.Start();
                process.WaitForExit();
                process.Close();

                //Console.WriteLine("7777777777777777777777777777777777");
                //Console.ReadLine();
              
                modebit = "0";
                if (correctbit == "4" || correctbit == "5" || correctbit == "6" || correctbit == "7")
                    while (true)
                    {
                  //      Console.WriteLine("7777777777777777777777777777777777");
                    //    Console.ReadLine();


                        argument = "";
                        argument += "cs_tcl.tcl ";
                        argument += "-dig ";
                        argument += "null";//-----------------------------------------------
                        argument += " ";
                        argument += modebit;
                        startInfo.Arguments = argument;
                        process.StartInfo = startInfo;
                        process.Start();
                        process.Close();
                        file = new System.IO.StreamReader(@"C:\\xilinx\\14.7\\ISE_DS\\ISE\\bin\\nt\\check_line.txt");
                        read_string = file.ReadLine();
                        check_read_string = read_string.Substring(17,1);
                    
                      //  Console.WriteLine("7777777777777777777777777777777777");
                     //   Console.ReadLine();

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
                        process.StartInfo.UseShellExecute = true;
                        process.Start();
                        process.Close();
                        file = new System.IO.StreamReader(@"C:\\xilinx\\14.7\\ISE_DS\\ISE\\bin\\nt\\check_line.txt");
                        read_string = file.ReadLine();
                        check_read_string = read_string.Substring(17, 1);

                       // Console.WriteLine("7777777777777777777777777777777777");
                        //Console.ReadLine();

                        if (check_read_string == "8" || check_read_string == "9" || check_read_string == "A" || check_read_string == "B")
                            break;
                    }
                
                if (correctbit == "4" || correctbit == "5" || correctbit == "6"  || correctbit == "7")
                    correctbit = "8";
                else
                {
                    correctbit = "4";
                }
                i += 17;
                modebit = "1";
            }
            file.Close();

          //  Console.WriteLine("7777777777777777777777777777777777");
           // Console.ReadLine();

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

            //Console.WriteLine("7777777777777777777777777777777777");
            //Console.ReadLine();

            return 1;
        }

        public List<bool> gethex()
        {
            char modernbit = '0';
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\xilinx\14.7\ISE_DS\ISE\bin\nt\test");
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory =@"C:\xilinx\14.7\ISE_DS\ISE\bin\nt";
            startInfo.FileName = "xtclsh.exe";
            string str="", read_string,correct_read_string="";
            startInfo.Arguments = "cs_tcl.tcl " + "-dig " + "null" + " " + modernbit;
            process.StartInfo = startInfo;
            read_string = file.ReadLine();
            str = read_string.Substring(16, 1);
            if (str != "0" && str != "4" && str != "8" && str != "C")
            {
                arraybool.Clear();
                return arraybool;
            }
            else
            {
                correct_read_string = "1";
            }
                while (true)
                {
                   
                    process.Start();
                    read_string = file.ReadLine();
                    str = read_string.Substring(16, 1);
                    while (true)
                    {
                        process.Start();
                        read_string = file.ReadLine();
                        str = read_string.Substring(16, 16);
                        if (str == "0" || str == "4" || str == "8" || str == "C")
                            break;
                        if (correct_read_string=="1")
                        {
                            if (str == "1" || str == "5" || str == "9" || str == "D")
                            {
                                correct_read_string = "2";
                                arrayhex += read_string;
                                break;
                            }
                        }
                        else
                        {
                            if (str == "2" || str == "7" || str == "A" || str == "E")
                            {
                                correct_read_string = "1";
                                arrayhex += read_string;
                                break;
                            }
                        }
                        

                    }
                    if (str == "0" || str == "4" || str == "8" || str == "C")
                        break; 
               }
            file.Close();
            DecodeHexString();
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
                if (str[i] == 1)
                    arraybool.Add(true);
                else
                    arraybool.Add(false);
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
                Console.WriteLine("tcl exists :)");
           //     Console.ReadLine();
                file = @"c:\xilinx\14.7\ISE_DS\ISE\bin\nt\xtclsh.exe";
                check = File.Exists(file);
                if (check)
                {
                    Console.WriteLine("exe exists :)");
                    Console.ReadLine();
                    string str;
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.WorkingDirectory = @"C:\xilinx\14.7\ISE_DS\ISE\bin\nt";
                    startInfo.FileName = "xtclsh.exe";
                    startInfo.Arguments =" cs_tcl.tcl -dig 800000000000000000 1";
                    process.StartInfo = startInfo;
                    process.StartInfo.UseShellExecute = true;
                    str = startInfo.Arguments;
                    process.Start();
                    process.WaitForExit();
                    process.Close();
                    //process.Start();
                    System.IO.StreamReader fileid = new System.IO.StreamReader(@"C:\\xilinx\\14.7\\ISE_DS\\ISE\\bin\\nt\\check_line.txt");
                    str = fileid.ReadLine();
                    fileid.Close();
                   // Console.WriteLine("0000000000000000000000000000000000");
                    //Console.WriteLine(str);
                    //Console.WriteLine("0000000000000000000000000000000000");
                    //Console.ReadLine();
                    startInfo.WorkingDirectory = @"C:\xilinx\14.7\ISE_DS\ISE\bin\nt";
                    startInfo.FileName = "xtclsh.exe";
                    startInfo.Arguments = " cs_tcl.tcl -dig 000000000000000000 1";
                    process.StartInfo = startInfo;
                    process.StartInfo.UseShellExecute = true;
                    process.Start();
                    process.WaitForExit();
                    process.Close();
                    process.Dispose();
                    //process.Start();
                    fileid = new System.IO.StreamReader(@"C:\\xilinx\\14.7\\ISE_DS\\ISE\\bin\\nt\\check_line.txt");
                    str = fileid.ReadLine();
                    fileid.Close();
                    //Console.WriteLine("1111111111111111111111111111111111");
                    //Console.WriteLine(str);
                    //Console.WriteLine("1111111111111111111111111111111111");
                    //Console.ReadLine();
                    List<bool> spisok = new List<bool>();
                    for (int i = 0; i < 64; i++)
                        if (i != 62 && i != 63)
                            spisok.Add(false);
                        else
                        {
                            spisok.Add(true);
                        }
                   // Console.WriteLine("7777777777777777777777777777777777");
                    //Console.ReadLine();
                    sethex(spisok);
                    //Console.WriteLine("2222222222222222222222222222222222");
                    fileid = new System.IO.StreamReader(@"C:\\xilinx\\14.7\\ISE_DS\\ISE\\bin\\nt\\check_line.txt");
                    str = fileid.ReadLine();
                    fileid.Close();
                    //Console.WriteLine("2222222222222222222222222222222222");
                    //Console.WriteLine("YOU WIN");
                    //Console.ReadLine();
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
