//css_host /version:v4.0 /platform:x86;
using System;
using System.Runtime.InteropServices;

class Script
{
    static public void Main(string [] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
 
        System.Diagnostics.Debug.Assert(false);
        
        System.Diagnostics.Debug.WriteLine("retrewter");
        System.Diagnostics.Debug.WriteLine("微软");
        Console.WriteLine("微软");
        Console.WriteLine("TragetFramework: " + Environment.Version);
        Console.WriteLine("Platform: " + ((Marshal.SizeOf(typeof(IntPtr)) == 8) ? "x64" : "x32"));
    }
}
