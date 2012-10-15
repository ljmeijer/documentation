using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UnderlyingModel
{
    public class UnmatchedRegexException : Exception
    {
        public UnmatchedRegexException(string fe)
        {
            FaultyExpression = fe;
        }
        public string FaultyExpression { private set; get; }
    }

	/// <summary>
	/// This class is used for generating unique IDs for members. 
	/// These IDs are then used for generating physical file paths.
	/// </summary>
    public class MemberNameGenerator
    {
		static private RegexMatcher[] _regexList;
        private Action<string> _unmatchedRegexHandler; //suppress / error / external
       
        public MemberNameGenerator()
        {
            _unmatchedRegexHandler = s => Console.Error.WriteLine("unmatched regex: {0}", s);

            //Note the order of these is important. Rule of thumb: more specific ones first
            SyntaxMatching.InitRegexList(out _regexList);
        }

		public void SetUnmatchedRegexHandler(Action<string> handler)
        {
            _unmatchedRegexHandler = handler;
        }

		//gets a directory-free, language-free filename for a member
		public static string GetUniqueMemberID(string codeContent, TypeKind t)
		{
			return GetMemberID(codeContent, t, false);
		}

		//member ID excluding signatures for functions
		public static string GetGenericMemberID(string codeContent, TypeKind t)
		{
			return GetMemberID(codeContent, t, true);
		}

		private static string GetMemberID(string codeContent, TypeKind t, bool simplifiedSignature)
		{
			switch (t)
			{
				case TypeKind.Class:
					string c1 = codeContent;
					if (c1.Contains(":"))
						c1 = c1.Remove(c1.IndexOf(':')).Trim();
					c1 = StringConvertUtils.StripCommonModifiers(c1);
					return c1;
				case TypeKind.Enum:
					var memberName = codeContent.Split(default(Char[]), StringSplitOptions.RemoveEmptyEntries)[0];
					memberName = memberName.TrimEnd(new[] {'='});

					memberName = StringConvertUtils.LowerCaseNeedsUnderscore(memberName);
					return memberName;
				case TypeKind.AutoProp:
					var memberName1 = codeContent.Split(' ')[1];
					memberName1 = StringConvertUtils.LowerCaseNeedsUnderscore(memberName1);
					return memberName1;
				case TypeKind.Struct:
					string s = codeContent;
					s = s.Replace("internal ", "");
					return s.Trim();
				case TypeKind.PureSignature:
					string sig = codeContent;
					var indexOfBrace = sig.IndexOf("{", StringComparison.Ordinal);
					if (indexOfBrace >= 0) // remove any body
						sig = sig.Remove(indexOfBrace).Trim();

					return GetMemberNameFromPureSignature(sig, simplifiedSignature);
				default:
					return "Error";
			}
		}

		

		//covered by unit tests
		internal static string GetMemberNameFromPureSignature(string sig, bool simplified = false)
    	{
			sig = StringConvertUtils.StripCommonModifiers(sig);

			sig = HandleGenerics(sig);

    		RegexMatcher matcher;
    		var found = TryMatchSignature(sig, out matcher);
			if (found)
			{

				string exp = simplified ? matcher.GetSimplifiedMatch(sig) : matcher.GetFullMatch(sig);
				
				return StringConvertUtils.LowerCaseNeedsUnderscore(exp);
			}
    		return "";
    	}

		//covered by unit tests
		public static bool TryMatchSignature(string sig, out RegexMatcher matcher)
		{
			if (_regexList == null)
				SyntaxMatching.InitRegexList(out _regexList);

			matcher = _regexList.FirstOrDefault(reg => reg.IsMatchSuccessful(sig));

			return matcher!=null;
		}

		private static string HandleGenerics(string sig)
		{
			if (sig.Contains("<"))
			{
				sig = sig.Replace('<', '_');
				sig = sig.Replace('>', '_');
			}
			return sig;
		}

		public string GetNameFromPureSignatureWithChecks(string sig)
    	{
    		var ret = GetMemberNameFromPureSignature(sig);
			if (ret != "")
				return ret;

			_unmatchedRegexHandler(sig);

			if (sig.StartsWith("/*"))
				Console.WriteLine("multiline comments not supported");
    		return "";
    	}

		
		//used in unit tests
		public static string PureNameWithTypeStack(string codeContent, TypeKind t, Stack<string> typeStack, bool simplifiedSignature = false)
		{
			var memberName = simplifiedSignature? GetGenericMemberID(codeContent, t) : GetUniqueMemberID(codeContent, t);
			var fullName = PrependTypesFromExternalStack(memberName, typeStack);
			return fullName;
		}

		private static string PrependTypesFromExternalStack(string memberName, Stack<string> typeStack)
		{
			var arr = typeStack.ToArray();
			var sb = new StringBuilder();
			for (int i = arr.Length - 1; i >= 0; i--)
				sb.AppendFormat("{0}.", arr[i]);
			sb.Append(memberName);
			return sb.ToString();
		}
    }
}
