using System;

namespace csharp_practice
{
    public abstract class TestBase
    {
        protected static void PrintObj(object item)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Type: {0} | Value: {1}",item.GetType(),item);
        }

        public abstract void TestThisFeature();
    }
}
