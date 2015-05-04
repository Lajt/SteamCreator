using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PasswordUtility.PasswordGenerator;

namespace SteamCreator
{
    /// <summary>
    /// Generate usernames and trash code
    /// </summary>
    class Generator
    {
        private static readonly string UsernamesPath = LoadConfig.Instance.UsernamesPath;
        public static string PasswordGenerator()
        {
            return PasswordUtility.PasswordGenerator.PwGenerator.Generate(10, true, true, false).ReadString();
        }

        public static string DigitsGenerator(int num = 4)
        {
            return PasswordUtility.PasswordGenerator.PwGenerator.Generate(num, false, true, false).ReadString();
        }

        public static string RandomName()
        {
            var lines = File.ReadAllLines(UsernamesPath);
            var r = new Random();
            var line = lines[r.Next(0, lines.Length - 1)];
            return line.ToLower();
        }
    }
}
