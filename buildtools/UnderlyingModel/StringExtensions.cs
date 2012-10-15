using System;
using System.Text.RegularExpressions;

namespace UnderlyingModel
{
	public static class StringExtensions
	{
		public static bool IsEmpty(this string self)
		{
			return self.Length == 0;
		}

		public static string WithUnixLineEndings(this string self)
		{
			return self.Replace("\r\n", "\n");
		}

		public static string WithNativeLineEndings(this string self)
		{
			return self.Replace("\r\n", Environment.NewLine);
		}

		public static string[] SplitLines(this string self)
		{
			return Regex.Split(self, @"\r?\n");
		}

		public static string TrimEndAndNewlines(this string self)
		{
			var result = self.TrimStart(new char[] {'\n'});
			return result.TrimEnd();
		}
	}
}
