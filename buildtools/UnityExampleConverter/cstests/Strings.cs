using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Boo.Lang.Runtime;
using UnityEngine;


namespace UnityExampleConverter.Tests
{
    public static partial class StringsModule
    {
        internal static Regex reg = new Regex("^\\s*");

        public static void AssertAreEqualIgnoringNewLineDifferences(string expected, string actual)
        {
            Assert.AreEqual(NormalizeNewLines(expected).TrimEnd(), NormalizeNewLines(actual).TrimEnd());
        }

        public static string NormalizeIndentation(string s)
        {
            var first = FirstNonEmptyLineOf(s);
	        if (first.Length == 0) return s;
            string indent = reg.Match(first).Value;
	        if (indent.Length == 0) return s;

            var result = new StringBuilder();
            foreach (string line in TextReaderEnumerator.lines(new StringReader(s)))
            {
		        if (line.StartsWith(indent))
		        {
                    result.AppendLine(line.Substring(RuntimeServices.NormalizeStringIndex(line, indent.Length)));
		        }
		        else
                    result.AppendLine(line);
            }
            return result.ToString().Trim();
        }
        	
        public static string FirstNonEmptyLineOf(string s)
        {
            foreach (var line in TextReaderEnumerator.lines(new StringReader(s)))
		        if (line.Trim().Length > 0)
		            return line;
            return string.Empty;
        }
        	
        public static string NormalizeNewLines(string s)
        {
            return s.Replace("\r\n", "\n");
        }
    }
}