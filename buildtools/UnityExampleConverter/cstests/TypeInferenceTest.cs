using NUnit.Framework;
using System;
namespace UnityExampleConverter.Tests
{
    [TestFixture]
    [Serializable]
    public class TypeInferenceTest
    {
        [Test]
        public void VariableTypes()
        {
            string code = "\r\n\t\tfunction foo() {\r\n\t\t\tvar bar = 42;\r\n\t\t}\r\n\t\t";
            string expected = "\r\n\t\tusing UnityEngine;\r\n\t\tusing System.Collections;\r\n\t\t\r\n\t\tpublic class Script : MonoBehaviour {\r\n\t\t    void foo() {\r\n\t\t        int bar = 42;\r\n\t\t    }\r\n\t\t}\r\n\t\t";
            CSharpAssertModule.AssertCSharpConversion(expected, code);
        }
        [Test]
        public void FieldTypes()
        {
            string code = "\r\n\t\tvar bar = 42;\r\n\t\t";
            string expected = "\r\n\t\tusing UnityEngine;\r\n\t\tusing System.Collections;\r\n\t\t\r\n\t\tpublic class Script : MonoBehaviour {\r\n\t\t    public int bar = 42;\r\n\t\t}\r\n\t\t";
            CSharpAssertModule.AssertCSharpConversion(expected, code);
        }
        [Test]
        public void MethodReturnTypes()
        {
            string code = "\r\n\t\tfunction bar() {\r\n\t\t\treturn 42;\r\n\t\t}\r\n\t\t";
            string expected = "\r\n\t\tusing UnityEngine;\r\n\t\tusing System.Collections;\r\n\t\t\r\n\t\tpublic class Script : MonoBehaviour {\r\n\t\t    int bar() {\r\n\t\t        return 42;\r\n\t\t    }\r\n\t\t}\r\n\t\t";
            CSharpAssertModule.AssertCSharpConversion(expected, code);
        }
    }
}
