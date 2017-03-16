using System;
using System.Diagnostics;

namespace shutdown2
{
    class PCShutdown
    {
        static void Main(string[] args)
        {
            Console.Write("Въведете време за изключване(в минути),\nако искате да отмените изключването въведете \"0\"");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Въведи минути: ");
            int minutes = int.Parse(Console.ReadLine());
            int convertToSec = minutes * 60;
            string text = "";
            if (minutes == 0)
	        {
                text = "shutdown /a ";
	        }
            else
            {
                text = "shutdown /s /t " + convertToSec;
            }
            cmd(text);
        }
        static void cmd(string text)
        {
            Process cmd = new Process();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine(text);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());
        }
    }
}
