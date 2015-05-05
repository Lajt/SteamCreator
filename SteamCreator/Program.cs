using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SteamCreator
{
    class Program
    {
         
        static void Main(string[] args)
        {

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Creating " +(i+1) +" account.");
                DoAccount();
                Console.WriteLine((i + 1) + " created.");
            }
            //Start Steam
           
            /*var start = 0;
            while (start<3)
            {
                for (int i = 0; i < 10; i++)
                {
                    var username = Generator.RandomName() + Generator.DigitsGenerator();    
                    var password = Generator.PasswordGenerator();
                
                    Console.WriteLine("Username:\t" + username);
                    Console.WriteLine("Password:\t" + password);
                    Console.WriteLine("");
                }
                Console.ReadLine();
                if(!Run.IsAlive())
                    Run.StartProcess();
                Run.ShowWindow();
                start++;
            }*/
            /*
            get steam files and zip them example
            Copy.CopyFiles("test1", Copy.GetSteamFiles());
            Copy.ZipFiles("test1");
            */
        }

        private static void DoAccount()
        {
            if (!Run.IsAlive())
                Run.StartProcess();
            else
                Run.RestartProcess();
            Thread.Sleep(3000);
            Run.ShowWindow();

            var username = Generator.RandomName() + Generator.DigitsGenerator();
            var password = Generator.PasswordGenerator();

            Console.WriteLine("Username:\t" + username);
            Console.WriteLine("Password:\t" + password);

            Thread.Sleep(3000);

            CreateAccount(username, password);
            Console.WriteLine("Account created. Waiting some time for mail confirmation.");
            Thread.Sleep(10000);

            ManualConfirm(username);

            Thread.Sleep(5000);


            // Login to Steam 2 times to make sure ssfn files are generated
            Run.RestartProcess();
            Thread.Sleep(20000);
            Process.Start("steam://url/SteamIDEditPage");
            Run.RestartProcess();
            Thread.Sleep(20000);
            Process.Start("steam://url/SteamIDEditPage");
            Run.RestartProcess();
            Thread.Sleep(10000);
            TurnOffTrade(username);
            Run.KillPrcess();

            Copy.CopyFiles(username, Copy.GetSteamFiles());
            Copy.saveCoordinates(username, password);
            File.Move("data\\" + username + ".png", "data\\" + username + "\\" + username + ".png");
            //Thread.Sleep(1000);
            Copy.ZipFiles(username);

            Run.KillPrcess("Firefox");
        }

        private static void CreateAccount(string username, string password)
        {
            //Create account 1024x768
            //doWork(1042, 617); 
            MouseClick(505,445);//doWork(945, 597);
            MouseClick(570,565);//doWork(1018, 718);
            MouseClick(570, 565);//doWork(1018, 718);
            //doWork(1018, 718);

            //Fill user and pass

            Keyboard.FillSteam(username, password);
            //next
            MouseClick(570, 565); //doWork(1018, 718);

            // Fill mail
            Keyboard.FillMail(username);
            MouseClick(570, 565);//doWork(1818, 718);

            Keyboard.FillQuestion(username);
            MouseClick(570,565);

            //Wait for creating account
            Thread.Sleep(25000);

            //take screen of data
            ScreenCapturer.CaptureAndSave("data\\" + username, CaptureMode.Window);

            MouseClick(570,565);
            MouseClick(670,565);
            // logged, click yes to confirm mail
            Thread.Sleep(10000);
            Process.Start("steam://url/SteamIDEditPage");
            Thread.Sleep(2000);

            using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1)))
            {
                SizeF size = graphics.MeasureString(username+"@niepodam.pl", new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point));
                int t = Convert.ToInt32(Math.Round(size.Width));
                MouseClick((315 + t), 188);
            }
            MouseClick(550,455);

            // Email sent, account created
        }

        private static void SteamLogin()
        {
            if (!Run.IsAlive())
                Run.StartProcess();
            else
                Run.RestartProcess();
            Thread.Sleep(3000);
            Run.ShowWindow();


        }

        private static void TurnOffTrade(string username)
        {
            Process.Start("steam://url/SteamIDEditPage");
            Thread.Sleep(10000);
            //Click settings
            MouseClick(750, 415);
            // Hit End key
            Keyboard.HitEnd();
            //Click disabled
            MouseClick(62, 277);

            MouseClick(350, 461);

            //wait for mail
            Thread.Sleep(15000);
            //goto mailbox
            Process.Start("http://" + username + ".niepodam.pl");
            Thread.Sleep(5000);
            MouseClick(150, 420,false);

            //Hit End key
            Keyboard.HitEnd();
            MouseClick(400, 380,false);
        }

        private static void ManualConfirm(string username)
        {
            Process.Start("http://"+username + ".niepodam.pl");
            Thread.Sleep(5000);
            MouseClick(150,420,false);
            Thread.Sleep(5000);
            MouseClick(300,680,false);
        }

        private static void MouseClick(int x, int y, bool show = true)
        {
            if(show)
                Run.ShowWindow();
            Move.SetCursorPosition(x, y);
            Move.DoMouseClick(x, y);
            Thread.Sleep(2000);
        }
    }
}
