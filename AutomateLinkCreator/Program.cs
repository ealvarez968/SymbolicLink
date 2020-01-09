using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AutomateLinkCreator
{
    class Program
    {


        static void Main(string[] args)
        {


            //string directoryFile = @"C:\Users\Soporte\Desktop\NAS.csv";
            string directoryFile = @"C:\NAS\NAS.csv";
            if (!File.Exists(directoryFile))
            {
                Console.WriteLine("El archivo no se encontro en " + directoryFile);
                Console.ReadKey();
                return;
            }


            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            //cmd.StandardInput.WriteLine(@"mkdir c:\Users\Soporte\Quetal");
            //cmd.StandardInput.WriteLine(@"mkdir c:\Users\Soporte\Que222tal");
           
            string[] lines = File.ReadAllLines(directoryFile);
            foreach (string line in lines)
            {

                //string command =;

                cmd.StandardInput.WriteLine(@"mklink /D C:\NAS\" + line + " \\192.168.1.174\\" + line);

                /*Console.WriteLine("mklink /D C:\\NAS\\" + line + " \\\\192.168.1.174\\\\" + line);
                string command = "mklink /D C:\\NAS\\" + line + " \\\\192.168.1.174\\\\" + line;
                try
                {
                   // System.Diagnostics.Process.Start("CMD.exe", command);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.GetBaseException()+""+e.ToString());
                    Console.ReadKey();
                }*/


            }

            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());




        }
    }
}
