using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

namespace Drunk_Computer
{
    class Program
    {
        public static int startupDellaySeconds = 10;
        public static int totalDurationSeconds = 45;

        public static Random rnd = new Random();
         
        static void Main(string[] args)
        {

            Thread drunkMouseThread = new Thread(new ThreadStart(DrunkMouse));
            Thread drunkKeyboardThread = new Thread(new ThreadStart(DrunkKeyboard));
            Thread drunkSoundThread = new Thread(new ThreadStart(DrunkSound));
            Thread drunkPoppUpThread = new Thread(new ThreadStart(DrunkPoppUp));


            DateTime future = DateTime.Now.AddSeconds(startupDellaySeconds);
            while (future > DateTime.Now)
            {
                Thread.Sleep(10000);
            }

            //starting the threads
            drunkMouseThread.Start();
            drunkKeyboardThread.Start();
            drunkSoundThread.Start();
            drunkPoppUpThread.Start();

            future = DateTime.Now.AddSeconds(totalDurationSeconds);
            while (future > DateTime.Now)
            {
                Thread.Sleep(1000);
            }
            //aborting the threads
            drunkMouseThread.Abort();
            drunkKeyboardThread.Abort();
            drunkSoundThread.Abort();
            drunkPoppUpThread.Abort();
        }

        public static void DrunkMouse()
        {
            Console.WriteLine("DrunkMouse thread started!");
            int moveX = 0;
            int moveY = 0;
            while (true)
            {
                moveX = rnd.Next(20) - 10;
                moveY = rnd.Next(20) - 10;

                Cursor.Position = new Point(
                    Cursor.Position.X + moveX,
                    Cursor.Position.Y + moveY
                    );
                Thread.Sleep(50);
            }
        }

        public static void DrunkKeyboard()
        {
            Console.WriteLine("DrunkKeyboard thread started!");
            
            while (true)
            {
                //generate a random capital letter
                char key = (char)(rnd.Next(25) + 65);

                //generate capital letter to lower case 50/50
                if (rnd.Next(2) == 0)
                {
                    key = char.ToLower(key);
                }

                SendKeys.SendWait(key.ToString());

                Thread.Sleep(rnd.Next(1000));
            }
            
        }

        public static void DrunkSound()
        {
            Console.WriteLine("DrunkSound thread started!");

            while (true)
            {
                if (rnd.Next(100) > 80)
                {
                    switch (rnd.Next(5))
                    {
                        case 0:
                            SystemSounds.Asterisk.Play();
                            break;
                        case 1:
                            SystemSounds.Beep.Play();
                            break;
                        case 2:
                            SystemSounds.Exclamation.Play();
                            break;
                        case 3:
                            SystemSounds.Hand.Play();
                            break;
                        case 4:
                            SystemSounds.Question.Play();
                            break;
                    }
                }
                Thread.Sleep(1000);
            }
        }

        public static void DrunkPoppUp()
        {
            Console.WriteLine("DrunkPoppUp thread started!");

            while (true)
            {
                if (rnd.Next(100) > 40)
                {
                    switch (rnd.Next(2))
                    {
                        case 0:
                            MessageBox.Show(
                                "Internet explorer has stopped working",
                                "Internet Explorer",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            break;
                        case 1:
                            MessageBox.Show(
                                "Your system is running low on resources",
                                "Microsoft Windows",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            break;
                    }
                }
                Thread.Sleep(10000);
            }
        }
    }
}
