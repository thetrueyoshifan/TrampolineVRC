#if (TRAMPOLINE_PC)
using System;
using System.Runtime.InteropServices;
using System.IO;
using UnityEngine;

namespace Windows
{
    public static class GuiConsole 
    {
        [DllImport("kernel32.dll")]
        private static extern int AllocConsole();
        [DllImport("user32.dll")]
        [return: MarshalAs(2)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();
        private static void ShowConsole() { SetForegroundWindow(GetConsoleWindow()); }
        public static void CreateConsole()
        {
            AllocConsole();
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            Console.Title = $"{Application.productName} v{Application.version} on {Enum.GetName(typeof(RuntimePlatform), Application.platform).Replace("Player", "")} [VRCModloader]";
            ShowConsole();
        }
    }
}
#endif