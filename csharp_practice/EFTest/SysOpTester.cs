using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace csharp_practice.EFTest
{
    class SysOpTester : TestBase
    {
        readonly string _host = "172.16.0.182";
        readonly string _username = "root";
        readonly string _password = "xianwei1019";
        readonly int _port = 22;

        // how to use ssh sftp
        // https://ourcodeworld.com/articles/read/369/how-to-access-a-sftp-server-using-ssh-net-sync-and-async-with-c-in-winforms
        public static int UploadFtp(string localFileName,
            string remoteFileName, string ftpServerIP, int ftpPort, string ftpUserID, string ftpPassword)
        {
            try
            {
                using (var sftp = new SftpClient(ftpServerIP, ftpPort, ftpUserID, ftpPassword))
                {
                    sftp.Connect();
                    using (var file = File.OpenRead(localFileName))
                    {
                        sftp.UploadFile(file, remoteFileName);
                    }
                    sftp.Disconnect();
                    Console.WriteLine("上传文件成功,文件路径：" + localFileName);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("上传失败，原因：" + ex.Message);
                return -2;

            }
        }
        void TestSSHCommand()
        {

            //连接信息
            ConnectionInfo conInfo = new ConnectionInfo(_host, _port, _username,
                new AuthenticationMethod[] { new PasswordAuthenticationMethod(_username, _password) });

            //SSH对象
            SshClient sshClient = new SshClient(conInfo);
            Console.WriteLine("输入命令");
            while (true)
            {
                if (!sshClient.IsConnected)
                {
                    sshClient.Connect();
                }

                Console.WriteLine("输入命令:");
                string line = Console.ReadLine();
                if (line.Equals("_quite;"))
                {
                    break;
                }
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                SshCommand sshCmd = sshClient.RunCommand(line);
                if (!string.IsNullOrWhiteSpace(sshCmd.Error))
                {
                    Console.WriteLine(sshCmd.Error);
                }
                else
                {
                    Console.WriteLine(sshCmd.Result);
                }
            }
            sshClient.Disconnect();
        }
        public override void TestThisFeature()
        {
            UploadFtp(@"D:\1.txt", "/opt/test/2.txt", _host, _port, _username, _password);
            //TestSSHCommand();
        }
    }
}
