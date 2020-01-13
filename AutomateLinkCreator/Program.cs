using System;
using System.IO;
using System.Diagnostics;

namespace AutomateLinkCreator
{
    class Program
    {


        static void Main(string[] args)
        {


            string directoryFile = @"C:\NAS\NAS.csv";
            if (!File.Exists(directoryFile))
            {
                Console.WriteLine("El archivo no se encontro en " + directoryFile);
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Hey you!");

            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

           
            string[] lines = File.ReadAllLines(directoryFile);
            foreach (string line in lines)
            {

                //string command =;

                Console.WriteLine("mklink /D C:\\NAS\\" + line + " \\\\192.168.1.174\\\\" + line);

                try
                {
                    cmd.StandardInput.WriteLine("mklink /D C:\\NAS\\" + line + " \\\\192.168.1.174\\\\" + line);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Hay un error");
                    Console.WriteLine(e.GetBaseException() + "" + e.ToString());
                    Console.ReadKey();
                }





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
            Console.WriteLine("Finalizado");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());

            Console.WriteLine();




        }
    }
}
