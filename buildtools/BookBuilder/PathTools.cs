using System.IO;

namespace BookBuilder
{
	class PathTools
	{
		public static void EnsureDirectoryExists(string dir)
		{
			if (Directory.Exists(dir))
				return;

			var parent = Path.GetDirectoryName(dir);
			EnsureDirectoryExists(parent);

			Directory.CreateDirectory(dir);
		}
	}
}
