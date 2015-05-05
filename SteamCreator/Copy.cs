using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Principal;
using System.Text;
using Ionic.Zip;

namespace SteamCreator
{
    /// <summary>
    /// Copy, move, remove and zip files
    /// </summary>
    internal class Copy
    {
        private static readonly string SteamPath = LoadConfig.Instance.SteamPath;
        private static readonly string SavePath = LoadConfig.Instance.SavePath;

        public static List<string> GetSteamFiles()
        {
            return
                Directory.GetFiles(SteamPath, "ssfn*")
                    .ToList()
                    .Concat(Directory.GetFiles(SteamPath + "config\\", "*.vdf").ToList())
                    .ToList();
        }

        public static void CopyFiles(string name, List<string> list)
        {
            var fullPath = SavePath + "\\" + name;
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
                Directory.CreateDirectory(fullPath + "\\config");
            }
            
                foreach (var file in list)
                {
                    string[] fileStrings = file.Split('\\');
                    string fileName = fileStrings[fileStrings.Length - 1];
                    if (!fileName.Contains(".vdf"))
                        File.Move(file, fullPath + "\\" + fileName);
                    else
                        File.Move(file, fullPath + "\\config\\" + fileName);

                }
        }

        public static void saveCoordinates(string username, string password)
        {
            string path = SavePath + "\\" + username + "\\";
            string[] lines = { "Username:\t" + username, "Password:\t" + password, "Mail address:\t" + username + "@niepodam.pl", "Go to " + username + ".niepodam.pl to receive your mails no need for password" };
            System.IO.File.WriteAllLines(path+"account.txt", lines);
        }

        public static void ZipFiles(string name)
        {
            string tempDir = SavePath + "\\" + name;
            using (ZipFile zip = new ZipFile())
            {
                zip.AddSelectedFiles("ssfn*",tempDir,"steam");
                zip.AddSelectedFiles("*.png", tempDir, "steam");
                zip.AddSelectedFiles("*.txt", tempDir, "steam");
                zip.AddSelectedFiles("*.vdf",tempDir+"\\config","config");
                zip.Save(SavePath+"\\"+name+".zip");
            }
        }
    }
}

