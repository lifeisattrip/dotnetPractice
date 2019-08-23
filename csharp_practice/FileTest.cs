using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace csharp_practice
{
    public class FileTest
    {
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