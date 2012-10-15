using System.IO;
using NUnit.Framework;

namespace UnderlyingModel.Tests
{
	[TestFixture]
	public class RenamingTests
	{
		[TestFixtureSetUp]
		public void Init()
		{
			Directory.SetCurrentDirectory("../../Tests");
		}
		

		[Test]
		public void RenameEnglishOnly()
		{
			var fullPathMemberDocs = Path.GetFullPath("TestMemberDocs");
			var fullPathOrig = Path.GetFullPath("TestMemberDocsOrig");

			DirectoryUtil.CopyDirectoryFromScratch(fullPathOrig, fullPathMemberDocs);

		    var project = new DocumentDataItemProject();
            project.ReloadAllProjectData();

			var oldFilesCount = Directory.GetFiles(fullPathMemberDocs).Length;
            var successCode = project.AssignDocToAsm("PlayerSettings.Android", "Android", fullPathMemberDocs);
		    AssertSuccessCode(successCode);
			successCode = project.AssignDocToAsm("PlayerSettings.iOS", "iOS", fullPathMemberDocs);
            AssertSuccessCode(successCode);

			var newFiles = Directory.GetFiles(fullPathMemberDocs);
			var newFilesCount = newFiles.Length;
			Assert.AreEqual(oldFilesCount, newFilesCount);

			var expectedAndroidName = Path.Combine(fullPathMemberDocs, "PlayerSettings.Android.mem");
			Assert.IsTrue(File.Exists(expectedAndroidName));

			var expectedIOSName = Path.Combine(fullPathMemberDocs, "PlayerSettings.iOS.mem");
			Assert.IsTrue(File.Exists(expectedIOSName));

		}

		[Test]
		public void RenameAllLangs()
		{
			var fullPathMemberDocs = Path.GetFullPath("TestMemberDocsAllLangs");
			var fullPathOrig = Path.GetFullPath("TestMemberDocsAllLangsOrig");

			DirectoryUtil.CopyDirectoryFromScratch(fullPathOrig, fullPathMemberDocs);

            var project = new DocumentDataItemProject();
            project.ReloadAllProjectData();

			var oldFilesCount = Directory.GetFiles(fullPathMemberDocs).Length;
			var success = project.AssignDocToAsm("PlayerSettings.Android", "Android", fullPathMemberDocs);
            AssertSuccessCode(success);
			success = project.AssignDocToAsm("PlayerSettings.iOS", "iOS", fullPathMemberDocs);
            AssertSuccessCode(success);
			var newFiles = Directory.GetFiles(fullPathMemberDocs);
			var newFilesCount = newFiles.Length;
			Assert.AreEqual(oldFilesCount, newFilesCount);

			var korMemberDocs = Path.Combine(fullPathMemberDocs, "Korean");

			var expectedAndroidNameKorean = Path.Combine(korMemberDocs, "PlayerSettings.Android.mem");
			Assert.IsTrue(File.Exists(expectedAndroidNameKorean));

			var expectedIOSNameKorean = Path.Combine(korMemberDocs, "PlayerSettings.iOS.mem");
			Assert.IsTrue(File.Exists(expectedIOSNameKorean));
		}

	    private static void AssertSuccessCode(DocumentDataItemProject.SuccessCode success)
        {
            if ((success & DocumentDataItemProject.SuccessCode.AsmItemExists) != DocumentDataItemProject.SuccessCode.AsmItemExists)
                Assert.Fail("Asm Item not in assembly");
            if ((success & DocumentDataItemProject.SuccessCode.AsmItemHasAsm) != DocumentDataItemProject.SuccessCode.AsmItemHasAsm)
                Assert.Fail("Asm Item does not have Asm entry");
            if ((success & DocumentDataItemProject.SuccessCode.AsmItemHasNoDoc) != DocumentDataItemProject.SuccessCode.AsmItemHasNoDoc)
                Assert.Fail("Asm Item has already has a doc, cannot override");
            if ((success & DocumentDataItemProject.SuccessCode.DocItemExists) != DocumentDataItemProject.SuccessCode.DocItemExists)
                Assert.Fail("Doc Item does not exist");
            if ((success & DocumentDataItemProject.SuccessCode.DocItemHasDoc) != DocumentDataItemProject.SuccessCode.DocItemHasDoc)
                Assert.Fail("Doc Item does not have a doc");
            if ((success & DocumentDataItemProject.SuccessCode.DocItemHasNoAsm) != DocumentDataItemProject.SuccessCode.DocItemHasNoAsm)
                Assert.Fail("Doc item is not orphan! It already has an associated assembly");
        }
	}
}
