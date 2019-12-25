namespace csharp_practice.Grammar
{
    public class NormalGrammar : TestBase
    {
        public void TestQuestionMark()
        {
            // 空合并运算符
            //如果a为非空则表达式“a??b”返回的结果为a；否则返回b。空合并运算符为右结合运算符，即操作时从右向左进行组合的。如，“a??b??c”的形式按“a??(bb??cc)”计算。
            string str1 = null;
            string str2 = str1 ?? "123";
            string str3 = str1 ?? "456" ?? "789"??"101";
            PrintObj(str2);
            PrintObj(str3);

            // System.Nullable的简写形式
            int? what1 = null;

            // null条件运算符【?.】
            // 用于在执行成员访问 (?.) 或索引 (?[) 操作之前，测试是否存在 NULL。
            var test = what1?.ToString();
            PrintObj(what1);
            PrintObj(test);
        }
        public override void TestThisFeature()
        {
            TestQuestionMark();
        }
    }
}
