using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace csharp_practice
{
    public class FileTest  : TestBase
    {
        public void FileInfoParser(List<FileInfo> files)
        {
            PrintObj(files.Count);
            var query = files.GroupBy(file => file.Extension);

            files.Sort((a, b) =>
            {
                var o = b.Length - a.Length;
                return (int)o;
            });
            foreach (var fileInfo in query.ToList())
            {
                PrintObj(fileInfo.Key);
                PrintObj(fileInfo.Count());
                foreach (var info in fileInfo)
                {
                    PrintObj(info);
                    PrintObj(info.Length);
                }
            }
        }
        public List<FileInfo> BrowserAllFiles(string folderPath)
        {
            var fileInfos = new List<FileInfo>();
            var stack = new Stack<DirectoryInfo>();

            stack.Push(new DirectoryInfo(folderPath));
            while (stack.Count > 0)
            {
                DirectoryInfo directoryInfo = stack.Pop();
                foreach (var fsInfo in directoryInfo.GetFileSystemInfos())
                {
                    switch (fsInfo)
                    {
                        case FileInfo fileInfo:
                            fileInfos.Add(fileInfo);
                            break;
                        case DirectoryInfo info:
                            stack.Push(info);
                            break;
                    }
                }
            }

            return fileInfos;
        }
    }
}
