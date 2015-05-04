using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace SteamCreator
{
    class Program
    {
         
        static void Main(string[] args)
        {

            var start = 0;
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
            }
            /*
            get steam files and zip them example
            Copy.CopyFiles("test1", Copy.GetSteamFiles());
            Copy.ZipFiles("test1");
            */
        }
    }
}
