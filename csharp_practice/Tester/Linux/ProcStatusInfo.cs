using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_practice.EFTest.Linux
{
    class ProcStatusInfo
    {
        public string Name { get; set; }

        /*线程组号*/
        public string Tgid { get; set; }

        /*进程pid*/
        public string Pid { get; set; }

        /*父进程的pid*/
        public string PPid { get; set; }

        /*跟踪进程的pid*/
        public string TracerPid { get; set; }

        /*uid euid suid fsuid*/
        public string Uid { get; set; }

        /*gid egid sgid fsgid*/
        public string Gid { get; set; }

        /*文件描述符的最大个数，file->fds*/
        public string FDSize { get; set; }

        /*启动该进程的用户所属的组的id*/
        public string Groups { get; set; }

        /*进程地址空间的大小*/
        public string VmPeak { get; set; }

        /*进程虚拟地址空间的大小reserved_vm：进程在预留或特殊的内存间的物理页*/
        public string VmSize { get; set; }

        /*进程已经锁住的物理内存的大小.锁住的物理内存不能交换到硬盘*/
        public string VmLck { get; set; }

        /*文件内存映射和匿名内存映射的大小*/
        public string VmHWM { get; set; }

        /*应用程序正在使用的物理内存的大小，就是用ps命令的参数rss的值 (rss)*/
        public string VmRSS { get; set; }

        /*程序数据段的大小（所占虚拟内存的大小），存放初始化了的数据*/
        public string VmData { get; set; }

        /*进程在用户态的栈的大小*/
        public string VmStk { get; set; }

        /*程序所拥有的可执行虚拟内存的大小,代码段,不包括任务使用的库 */
        public string VmExe { get; set; }

        /*被映像到任务的虚拟内存空间的库的大小*/
        public string VmLib { get; set; }

        /*该进程的所有页表的大小*/
        public string VmPTE { get; set; }

        /*共享使用该信号描述符的任务的个数*/
        public string Threads { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Tgid)}: {Tgid}, {nameof(Pid)}: {Pid}, {nameof(PPid)}: {PPid}, {nameof(TracerPid)}: {TracerPid}, {nameof(Uid)}: {Uid}, {nameof(Gid)}: {Gid}, {nameof(FDSize)}: {FDSize}, {nameof(Groups)}: {Groups}, {nameof(VmPeak)}: {VmPeak}, {nameof(VmSize)}: {VmSize}, {nameof(VmLck)}: {VmLck}, {nameof(VmHWM)}: {VmHWM}, {nameof(VmRSS)}: {VmRSS}, {nameof(VmData)}: {VmData}, {nameof(VmStk)}: {VmStk}, {nameof(VmExe)}: {VmExe}, {nameof(VmLib)}: {VmLib}, {nameof(VmPTE)}: {VmPTE}, {nameof(Threads)}: {Threads}";
        }
    }
}