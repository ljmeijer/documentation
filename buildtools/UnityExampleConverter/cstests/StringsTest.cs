using NUnit.Framework;


namespace UnityExampleConverter.Tests
{
    [TestFixture]
    class StringsTest
    {
    	
	    [Test]
	    public void NormalizeIndentationTest()
        {
            string expected = "\r\nclass Foo {\r\n    void Bar() {}\r\n}";
            string actual = "\r\n\t\tclass Foo {\r\n\t\t    void Bar() {}\r\n\t\t}";
            StringsModule.AssertAreEqualIgnoringNewLineDifferences(expected.Trim(), StringsModule.NormalizeIndentation(actual));
        }
    }
}
