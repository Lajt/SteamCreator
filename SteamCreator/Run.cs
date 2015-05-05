using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace SteamCreator
{
    /// <summary>
    /// Run/close applications if nessesery
    /// </summary>
    class Run
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        private static readonly string FullSteamPath = LoadConfig.Instance.SteamPath +"\\Steam.exe";

        public static void StartProcess(string path = "Steam")
        {
            Process.Start(path.Contains("Steam") ? FullSteamPath : path);
        }

        public static void KillPrcess(string name = "Steam")
        {
            Process[] processes = Process.GetProcessesByName(name);
            foreach (var process in processes)
            {
                process.Kill();
            }
        }

        public static void RestartProcess(string name = "Steam", string path = "Steam")
        {
            KillPrcess(path);
            //Thread.Sleep(2000);
            StartProcess(name);
        }

        public static bool IsAlive(string name = "Steam")
        {
            Process[] processes = Process.GetProcessesByName(name);
            if(processes.Length > 0)
                Console.WriteLine(processes[0].MainWindowTitle);
            return processes.Length > 0;
        }

        public static string GetWindowName(string name = "Steam")
        {
            if(!IsAlive(name))
                RestartProcess(name);
            Process[] proceses = Process.GetProcessesByName(name);
            return proceses[0].MainWindowTitle;
        }

        public static void ShowWindow(string name = "Steam")
        {
            Process[] processes = Process.GetProcessesByName(name);
            Console.WriteLine(processes[0].MainWindowTitle);
            SetForegroundWindow(processes[0].MainWindowHandle);

        }
    }
}
