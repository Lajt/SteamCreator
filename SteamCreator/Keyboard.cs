using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace SteamCreator
{
    class Keyboard
    {
        public static void FillSteam(string username, string password)
        {
            
            var sim = new InputSimulator();
            sim.Keyboard
                .TextEntry(username)
                .Sleep(2000)
                .KeyPress(VirtualKeyCode.TAB)
                .Sleep(2000)
                .TextEntry(password)
                .Sleep(2000)
                .KeyPress(VirtualKeyCode.TAB)
                .Sleep(2000)
                .TextEntry(password)
                .Sleep(2000);

        }

        public static void HitEnd()
        {
            var sim = new InputSimulator();
            sim.Keyboard
                .KeyPress(VirtualKeyCode.END)
                .Sleep(2000);
        }
        public static void FillMail(string username)
        {
            
            var sim = new InputSimulator();
            sim.Keyboard
                .TextEntry(username + "@niepodam.pl")
                .Sleep(2000)
                .KeyPress(VirtualKeyCode.TAB)
                .Sleep(2000)
                .TextEntry(username + "@niepodam.pl")
                .Sleep(2000);

        }
        public static void FillQuestion(string username)
        {
            
            var sim = new InputSimulator();
            sim.Keyboard
                .Sleep(5000)
                .KeyPress(VirtualKeyCode.TAB)
                .Sleep(2000)
                .TextEntry(username)
                .Sleep(2000);

        }
    }
}
