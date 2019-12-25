using System;
using System.Reflection;
using csharp_practice.EFTest.Linux;

namespace csharp_practice
{
    public class ReflectTester : TestBase
    {
        void PropertySet(object p, string propName, object value)
        {
            Type t = p.GetType();
            PropertyInfo info = t.GetProperty(propName);
            if (info == null)
                return;
            if (!info.CanWrite)
                return;
            info.SetValue(p, value, null);
        }

        void PropertySetLooping(object p, string propName, object value)
        {
            Type t = p.GetType();
            foreach (PropertyInfo info in t.GetProperties())
            {
                if (info.Name == propName && info.CanWrite)
                {
                    info.SetValue(p, value, null);
                }
            }
        }

        public override void TestThisFeature()
        {
            ProcStatusInfo procStatusInfo = new ProcStatusInfo();
            Type type = typeof(ProcStatusInfo);
            PropertyInfo info = procStatusInfo.GetType().GetProperty("Name");
            if (info != null && info.CanWrite)
            {
                info.SetValue(procStatusInfo, "TestName", null);
            }

            PrintObj(procStatusInfo.ToString());
        }
    }
}