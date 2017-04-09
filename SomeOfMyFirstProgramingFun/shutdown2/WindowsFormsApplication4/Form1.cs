using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class PCShutdownSchedule : Form
    {
        public PCShutdownSchedule()
        {
            InitializeComponent();
            richTextBox1.AppendText("Въведете време за изключване(в минути),\nако искате да отмените изключването въведете \"0\"");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScheduleSetter();
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text;
        }

        private static void Cmd(string text)
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

        private void ScheduleSetter()
        {
            try
            {
                int minutes = int.Parse(textBox1.Text);
                if (minutes < 0)
                {
                    throw new ArgumentException();
                }
                int convertToSec = minutes * 60;
                string result = "";
                if (minutes == 0)
                {
                    result = "shutdown /a ";
                }
                else
                {
                    result = "shutdown /s /t " + convertToSec;
                }
                Cmd(result);

                Application.Exit();
            }
            catch (ArgumentException)
            {
                richTextBox1.AppendText(Environment.NewLine + "Минутите немогат да бъдат отрицателни!");
            }
            catch (System.Exception)
            {
                richTextBox1.AppendText(Environment.NewLine + "Невалидни минути!");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                ScheduleSetter();
            }
        }
    }
}
