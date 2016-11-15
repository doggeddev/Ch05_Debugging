using System;
using static System.Console;
using System.Linq;
using System.Diagnostics;
using static System.Diagnostics.Process;



namespace Ch05_Monitoring
{

    class Recorder
    {
        static Stopwatch timer = new Stopwatch();
        static long bytesPhysicalBefore = 0;
        static long bytesVirtualBefore = 0;
        public static void Start()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            bytesPhysicalBefore = GetCurrentProcess().WorkingSet64;
            bytesVirtualBefore = GetCurrentProcess().VirtualMemorySize64;
            timer.Restart();

              }

        public static void Stop()
        {
            long bytesPhysicalAfter = GetCurrentProcess().WorkingSet64;
            long bytesVirutalAfter = GetCurrentProcess().VirtualMemorySize64;
            WriteLine("Stopped recording.");
            WriteLine($"{bytesPhysicalAfter - bytesPhysicalBefore:N0} physical bytes used.");
            WriteLine($"{bytesVirutalAfter - bytesVirtualBefore:N0} virutal bytes used.");
            WriteLine($"{timer.Elapsed} time span ellapsed.");
            WriteLine($"{timer.ElapsedMilliseconds:N0} total milliseconds ellapsed.");

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Write("Press enter to start time: ");
            ReadLine();
            Recorder.Start();
            int[] largeArrayOfInts = Enumerable.Range(1, 10000).ToArray();
            Write("Press enter to stop timer: ");
            ReadLine();
            Recorder.Stop();
            ReadLine();
        }
    }
}
