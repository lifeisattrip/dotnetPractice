using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using csharp_practice.EFTest;

namespace csharp_practice
{
    internal class Program
    {
        private int Test1;
        private string Test2;
        public int Prop1 { get; set; }

        public int Calculate => Prop1 + 111110;


        private static void TestLinq()
        {
            var arr = new List<int> {1, 2, 4, 5, 6};

            var linq =
                from item in arr
                where item > 5
                select item;
            var list = linq.ToList();

            foreach (var item in list.ToArray()) Console.WriteLine(item);

            Console.WriteLine("TestLinq End");
        }

        private static void TestEf()
        {
            var db = new AppDbContext();
            var stu = new SysUser();
            stu.UserName = "name";
            stu.Address = "remark";
            db.AddRange(stu);
            db.SaveChanges();
            var items = db.SysUsers.ToList();
            Console.WriteLine("TestEf student count {0}", items.Count());
            foreach (var item in items) Console.WriteLine(item.UserName);

            Console.WriteLine("TestEF End");
        }

        private static void TestString()
        {
            Console.WriteLine("{0} {1}", 123, 345);
        }

        private static void TestDateTime()
        {
            var today = DateTime.Now;
            var answer = today.AddDays(36);
            Console.WriteLine("Today: {0:dddd}", today);
            Console.WriteLine("36 days from today: {0:dddd}", answer);


            var dt = DateTime.Now;
            Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss"));

            var endTime = dt.AddDays(10);
            Console.WriteLine(endTime.ToString("yyyy-MM-dd HH:mm:ss"));
            for (var start = dt; start <= endTime; start = start.AddDays(1))
                Console.WriteLine(start.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        private static void TestFile()
        {
            var di = new DirectoryInfo(@"C:\Users\kevin\Documents\weeplusFiles\15996355802@xw\receive file");
            var fileInfos = di.GetFiles();
            foreach (var fileInfo in fileInfos) Console.WriteLine(fileInfo.Name);
        }

        [My("ddddscription", "version 111")]
        private void TestType()
        {
            var type = GetType();
            Console.WriteLine("{0}  {1}  {2}", type.Name, type.FullName, "123");

            var fieldInfos = type.GetFields();
            Console.WriteLine("Fileinfo size {0}", fieldInfos.Length);
            foreach (var fieldInfo in fieldInfos) Console.WriteLine(fieldInfo.Name);

            var customAttributes = type.GetCustomAttributes(true);

            foreach (var customAttribute in customAttributes) Console.WriteLine(customAttribute.ToString());
        }

        private void TestAttribute([CallerFilePath] string filename = "")
        {
            Console.WriteLine("Filename {0}", filename);
        }

        private void TestProp()
        {
            Prop1 = 123;
            Console.WriteLine(Prop1);
            Console.WriteLine(Calculate);
        }


        private void TestIndex()
        {
        }

        private static void PrintObj(object item)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine(item.GetType());
            Console.WriteLine(item);
        }


        private void TestTuple()
        {
            var t1 = (1, 2, 34, 5, "123", 15.6f);
            (int, int, int) t2 = (1, 2, 34);

            var named = (name: "kevin", age: 123);

            PrintObj(t1);
            PrintObj(named);
            PrintObj(named.age);
            PrintObj(t1.Item6);
            PrintObj(t2);
        }

        private void TestUnnameType()
        {
            var v = new {Name = "Kevin", Age = 123};

            PrintObj(v);
            PrintObj(v.Name);
        }

        private void TestEssentialCSharp()
        {
            System.Console.WriteLine($"0x{42:x}");
            int firstName = 471654;
            string lastName = "toqi";

            System.Console.WriteLine($@"Your full name is:
{firstName} {lastName}");
            //有位有@符号 所以才能被解析 因为左大括号 换行了
            System.Console.WriteLine($@"Your full name is: {
                firstName} {lastName}");

            double outPut = 0;
            bool result = double.TryParse("1x0", out outPut);

            (string country, string capital, double gdpPerCapita) = ("Malawi", "Lilongwe", 226.50);

            PrintObj(outPut);
            PrintObj(result);

            PrintObj(country);
            PrintObj(gdpPerCapita);
        }

        private static void Main(string[] args)
        {
            var program = new Program();
            program.TestEssentialCSharp();

            var fileTest = new FileTest();
            var browserAllFiles =
                fileTest.BrowserAllFiles(@"C:\develop\develop_tool\IntelliJ IDEA 2019.2\license");
            fileTest.FileInfoParser(browserAllFiles);

            EfTester efTester = new EfTester();
            efTester.TestSelect();
        }
    }
}
