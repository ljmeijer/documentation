using System.IO;

namespace UnderlyingModel
{
    public static class DirectoryWithLangUtil
    {
		public static string GetPathFromMemberNameAndDir(string memberName, string dir)
		{
			return GetPathFromMemberNameAndDir(memberName, dir, LanguageUtil.ELanguage.English);
		}

    	public static string GetPathFromMemberNameAndDir(string memberName, string dir, LanguageUtil.ELanguage lang)
    	{
    		if (!LanguageUtil.IsEnglish(lang))
    			dir = Path.Combine(dir, lang.ToString());
    		return Path.Combine(dir, DirectoryUtil.MemberNameWithExtension(memberName, DirectoryUtil.MemExtension));
    	}

    	public static string LocalizedDir(string path, LanguageUtil.ELanguage locale)
		{
			var localizedPath = LanguageUtil.IsEnglish(locale) ? path : Path.Combine(path, locale.ToString());
    		return localizedPath;
		}

        public static void RenameMemFile(string sourceName, string destinName, string rootMemberDocs)
        {
            //rename the items with sourceName to destinName
            foreach (var lang in LanguageUtil.GetAllLanguages())
            {
                var sourcePath = GetPathFromMemberNameAndDir(sourceName, rootMemberDocs, lang);
                var destinPath = sourcePath.Replace(sourceName, destinName);
                if (File.Exists(sourcePath))
                    File.Move(sourcePath, destinPath);
            }
        }
    }
}
