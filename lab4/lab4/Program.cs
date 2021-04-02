using System;
using System.Runtime.InteropServices;

namespace Lab4
{
    class Lab4
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n\tCOMPUTER INFO:\n");

            Console.WriteLine("Physical Memory:\n");
            PrintPhysMemory(); 

            Console.WriteLine("-------------------------------------------\n");
            Console.WriteLine("Global Memory:\n");
            PrintGlobalMemoryStatus();

            Console.WriteLine("-------------------------------------------\n");
            Console.WriteLine("System Info:\n");
            PrintSystemInfo();

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("\nDisk C:\n");
            PrintDiskFreeSpace("C:");

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("\nDisk D:\n");
            PrintDiskFreeSpace("D:");

            Console.WriteLine("-------------------------------------------");
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out ulong PhysMem);

        static void PrintPhysMemory()
        {
            ulong PhysMem;
            bool allRight = GetPhysicallyInstalledSystemMemory(out PhysMem);
            if (!allRight)
                Console.WriteLine("Something went wrong!");

            Console.WriteLine("There are {0} GB of RAM ", PhysMem / 1024 / 1024);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
        }

        [DllImport("kernel32.dll")]
        public static extern void GlobalMemoryStatusEx(out MEMORYSTATUSEX lpBuffer);

        public static void PrintGlobalMemoryStatus()
        {
            MEMORYSTATUSEX statex;
            statex.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            GlobalMemoryStatusEx(out statex);

            Console.WriteLine("There is {0} percent of memory in use.",
                               statex.dwMemoryLoad);
            Console.WriteLine("There are {0} total KB of physical memory.",
                               statex.ullTotalPhys / 1024);
            Console.WriteLine("There are {0} free  KB of physical memory.",
                               statex.ullAvailPhys / 1024);
            Console.WriteLine("There are {0} total KB of paging file.",
                               statex.ullTotalPageFile / 1024);
            Console.WriteLine("There are {0}  free  KB of paging file.",
                               statex.ullAvailPageFile / 1024);
            Console.WriteLine("There are {0} total KB of virtual memory.",
                               statex.ullTotalVirtual / 1024);
            Console.WriteLine("There are {0} free  KB of virtual memory.",
                               statex.ullAvailVirtual / 1024);
            Console.WriteLine("There are {0} free  KB of extended memory.",
                               statex.ullAvailExtendedVirtual / 1024);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_INFO
        {
            public ushort wProcessorArchitecture;
            ushort wReserved;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public IntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public ushort wProcessorLevel;
            public ushort wProcessorRevision;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void GetSystemInfo(out SYSTEM_INFO SystInfo);

        public static void PrintSystemInfo()
        {
            SYSTEM_INFO SysInfo;
            GetSystemInfo(out SysInfo);

            switch(SysInfo.wProcessorArchitecture)
            {
                case 9:
                    Console.WriteLine("Processor architecture: (AMD or Intel) x64");
                    break;
                case 5:
                    Console.WriteLine("Processor architecture: ARM");
                    break;
                case 12:
                    Console.WriteLine("Processor architecture: ARM64");
                    break;
                case 6:
                    Console.WriteLine("Processor architecture: Intel x64 (Intel Itanium-based)");
                    break;
                case 0:
                    Console.WriteLine("Processor architecture: Intel x86");
                    break;
                default:
                    Console.WriteLine("Unknown processor architecture");
                    break;
            }

            Console.WriteLine("Page size: {0} KB", SysInfo.dwPageSize / 1024);
            Console.WriteLine("The number of processors {0}", SysInfo.dwNumberOfProcessors);
            Console.WriteLine("Processor type: {0}", SysInfo.dwProcessorType);
            Console.WriteLine("Allocation granularity: {0}", SysInfo.dwAllocationGranularity);
            Console.WriteLine("Processor level: {0}", SysInfo.wProcessorLevel);
            Console.WriteLine("Processor revision: {0}", SysInfo.wProcessorRevision);
        }

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetDiskFreeSpaceEx(string lpDirectoryName,
                                              out ulong lpFreeBytesAvailable,
                                              out ulong lpTotalNumberOfBytes,
                                              out ulong lpTotalNumberOfFreeBytes);

        static void PrintDiskFreeSpace(string lpDirectoryName)
        {
            ulong FreeBytesAvailable;
            ulong TotalNumberOfBytes;
            ulong TotalNumberOfFreeBytes;

            bool allRight = GetDiskFreeSpaceEx(lpDirectoryName,
                                              out FreeBytesAvailable,
                                              out TotalNumberOfBytes,
                                              out TotalNumberOfFreeBytes);

            if (!allRight)
                Console.WriteLine("Something went wrong!");

            Console.WriteLine("Free gigabytes available: " + FreeBytesAvailable / 1024 / 1024 / 1024);
            Console.WriteLine("Total number of gigabytes: " + TotalNumberOfBytes / 1024 / 1024 / 1024);
            Console.WriteLine("Total number of free gigabytes: " + TotalNumberOfFreeBytes / 1024 / 1024 / 1024);
        }
    }
}
