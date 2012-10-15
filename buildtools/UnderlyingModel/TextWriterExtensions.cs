using System.IO;

namespace UnderlyingModel
{
	public static class TextWriterExtensions
	{
		public static void WriteLineUnixEndings(this TextWriter self)
		{
			self.Write("\n");
		}

		public static void WriteLineUnixEndings(this TextWriter self, string st)
		{
			self.Write(st);
			self.Write("\n");
		}
	}
}
