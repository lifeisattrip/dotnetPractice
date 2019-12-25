using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_practice
{
    public sealed class MyAttributeTest : System.Attribute
    {
        public MyAttributeTest(string desc, string ver)
        {
            Description = desc;
            Version = ver;
        }

        public string Description
        { get; set; }

        public String Version { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
