using System;
using System.Reflection;
using System.IO;

namespace Trampoline
{
    public static class Main
    {
        public static void Run()
        {
#if (TRAMPOLINE_QUEST)
            byte[] data = File.ReadAllBytes("/sdcard/VRCTools/VRCModLoader.dll");
#else
            byte[] data = File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "VRCModLoader.dll"));
#endif
            Assembly a = Assembly.Load(data);
            a.GetType("VRCModLoader.Injector").GetMethod("Inject").Invoke(null, null);
        }
    }
}