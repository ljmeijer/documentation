using System.IO;
using NUnit.Framework;

namespace UnderlyingModel.Tests
{
	[TestFixture]
	public class InvalidMemFiles
	{
        [Test]
        public void InvalidConstructors()
        {
        	var files = Directory.GetFiles(DirectoryUtil.MemberDocsDir);
        	foreach (var file in files)
        	{
        		var pureFileName = Path.GetFileName(file);
        		var indexOfDot = pureFileName.IndexOf('.');
        		if (indexOfDot <= 0) continue;

        		var beforeDot = pureFileName.Substring(0, indexOfDot);
        		var afterDot = pureFileName.Substring(indexOfDot + 1);
        		afterDot = afterDot.Replace(".mem", "");
        		var indexOfUnderscore = afterDot.IndexOf("_");
				if (indexOfUnderscore <= 0) continue;

        		var afterDotBeforeUnderscore = afterDot.Substring(0, indexOfUnderscore);
        		Assert.IsFalse(afterDotBeforeUnderscore.Equals(beforeDot), pureFileName + ": old constructor syntax, delete");
        	}
        }
	}
}
