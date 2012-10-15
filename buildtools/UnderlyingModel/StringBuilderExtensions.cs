using System.Text;

namespace UnderlyingModel
{
	public static class StringBuilderExtensions
	{
		public static string Consume(this StringBuilder builder)
		{
			var result = builder.ToString();
			builder.Length = 0;
			return result;
		}

		public static string ConsumeAndTrim(this StringBuilder builder)
		{
			var result = builder.ToString();
			builder.Length = 0;
			return result.Trim();
		}

		public static string ConsumeAndTrimEndAndNewlines(this StringBuilder builder)
		{
			var result = builder.ToString();
			builder.Length = 0;
			return result.TrimEndAndNewlines();
		}

		public static string ConsumeAndTrimNewlines(this StringBuilder builder)
		{
			var result = builder.ToString();
			builder.Length = 0;
			return result.Trim();
		}

		public static void AppendUnixLine(this StringBuilder accumulator, string line)
		{
			accumulator.Append(line);
			accumulator.Append("\n");
		}

		public static void AppendUnixLine(this StringBuilder accumulator)
		{
			accumulator.Append("\n");
		}
	}
}
