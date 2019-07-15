using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace csharp_practice
{
    class Program
    {
        private int Test1;
        private string Test2;
        public int Prop1 { get; set; }
        

        private static void TestLinq()
        {
            var arr = new List<int> { 1, 2, 4, 5, 6 };
            
            var linq =
                from item in arr
                where item > 5
                select item;
            var list = linq.ToList();

            foreach (int item in list.ToArray())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("TestLinq End");
        }

        private static void TestEf()
        {
            var db = new MyDbContext();
            var stu = new Student();
            stu.StudentName = "name";
            stu.Remark = "remark";
            db.AddRange(stu);
            db.SaveChanges();
            var items = db.Students.ToList();
            Console.WriteLine("TestEf student count {0}",items.Count());
            foreach (var item in items)
            {
                Console.WriteLine(item.StudentName);
            }
            Console.WriteLine("TestEF End");
        }

        private static void TestString()
        {
            Console.WriteLine("{0} {1}", 123, 345);
        }

        private static void TestDateTime()
        {
            DateTime today = DateTime.Now;
            DateTime answer = today.AddDays(36);
            Console.WriteLine("Today: {0:dddd}", today);
            Console.WriteLine("36 days from today: {0:dddd}", answer);


            DateTime dt = DateTime.Now;
           Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss"));

           var endTime = dt.AddDays(10);
           Console.WriteLine(endTime.ToString("yyyy-MM-dd HH:mm:ss"));
            for (DateTime start = dt; start <= endTime; start = start.AddDays(1))
           {
               Console.WriteLine(start.ToString("yyyy-MM-dd HH:mm:ss"));
           }
        }

        private static void TestFile()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\kevin\Documents\weeplusFiles\15996355802@xw\receive file");
            FileInfo[] fileInfos = di.GetFiles();
            foreach (var fileInfo in fileInfos)
            {
                Console.WriteLine(fileInfo.Name);
            }
        }
        [MyAttribute("ddddscription","version 111")]
        private void TestType()
        {
            Type type = this.GetType();
            Console.WriteLine("{0}  {1}  {2}", type.Name, type.FullName, "123");

            FieldInfo[] fieldInfos = type.GetFields();
            Console.WriteLine("Fileinfo size {0}", fieldInfos.Length);
            foreach (var fieldInfo in fieldInfos)
            {
                Console.WriteLine(fieldInfo.Name);
            }

            object[] customAttributes = type.GetCustomAttributes(true);

            foreach (var customAttribute in customAttributes)
            {
                Console.WriteLine(customAttribute.ToString());
            }
        }

        private void TestAttribute([CallerFilePath] string filename = "")
        {
            Console.WriteLine("Filename {0}",filename);
        }

        public int Calculate
        {
            get { return Prop1 + 111110; }
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
        static void Main(string[] args)
        {
            Program program = new Program();
            program.TestProp();
        }
    }
}
