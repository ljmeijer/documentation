using System;
using System.Text;
using System.Text.RegularExpressions;

namespace UnderlyingModel
{
	internal static class SyntaxMatching
	{
		internal static readonly Regex IndexerMarker = new Regex(@"(.*)\sthis\s\[(.*)\]");
		internal static readonly Regex FieldAssignmentMarker = new Regex(@"^(\w+)\s(\w+)\s=");
		internal static readonly Regex EnumEntryAssignmentMarker = new Regex(@"(\w+)\s*=\s*(\w+)");
		internal static readonly Regex EnumEntryNoAssignment = new Regex(@"(\w+)\s*");
		internal static readonly Regex ConstMarker = new Regex(@"^const\s(\w+)\s(\w+)\s=");
		internal static readonly Regex ConstructorMarker = new Regex(@"^(\w+)\s*\((.*?)\)");
		internal static readonly Regex ConstructorFromAssemblyMarker = new Regex(@"^Void .ctor\((([\w\.]+(\[\])?\s*)?(,\s*[\w\.]+(\[\])?)*)?\)");
		internal static readonly Regex DestructorMarker = new Regex(@"^~(\w+)\s*\((.*?)\)");
		internal static readonly Regex MethodMarker = new Regex(@"^([\w\.]+(?:\[,*\])?)\s+(\w+)\s*\((.*)\)");
		internal static readonly Regex FieldMarker = new Regex(@"^([\w\.]+(?:\[\])?)\s+(\w+)\s*");
		internal static readonly Regex OperatorMarker = new Regex(@"^(\w+)\soperator\s(.+)\s\((.*)\)");
		internal static readonly Regex ImplOperatorMarker = new Regex(@"^implicit\soperator\s(\w+)\s*\((.*)\)");
		internal static readonly Regex ImplOperatorFromAssembly = new Regex(@"(\w+)\sop_Implicit\s*\((.*)\)");
        internal static readonly Regex OperatorFromAssembly = new Regex(@"(\w+)\sop_(\w+)\s*\((.*)\)");

		internal static void InitRegexList(out RegexMatcher[] regexList)
		{
			regexList = new[]
						{
							new RegexMatcher(ImplOperatorMarker,
			            		m =>
			            			{
			            				string ret = m.Groups[1].ToString();
			            				string extras = StringConvertUtils.ConvertArgsToString(m.Groups[2].ToString());
										return String.Concat("implop_", ret, extras);
			            			}, "IMPLICIT OPERATOR"),

							new RegexMatcher(ImplOperatorFromAssembly,
			            		m =>
			            			{
			            				string ret = m.Groups[1].ToString();
			            				string extras = StringConvertUtils.ConvertArgsToString(m.Groups[2].ToString());
										return String.Concat("implop_", ret, extras);
			            			}, "IMPLICIT OPERATOR"),
                            new RegexMatcher(OperatorFromAssembly,
			            		m =>
			            			{
			            				string name = StringConvertUtils.ConvertOperatorFromAssembly(m.Groups[2].ToString());
			            				string extras = StringConvertUtils.ConvertArgsToString(m.Groups[3].ToString());
			            				return String.Concat(name, extras);
			            			}, "OPERATOR"),
							new RegexMatcher(IndexerMarker,
			            		m =>
			            			{
			            				string extras = StringConvertUtils.ConvertArgsToString(m.Groups[2].ToString());
			            				return String.Concat("this", extras);
			            			}, "INDEXER"),
							new RegexMatcher(MethodMarker,
			            		m =>
			            			{
			            				string extras = StringConvertUtils.ConvertArgsToString(m.Groups[3].ToString());
			            				return String.Concat(m.Groups[2].ToString(), extras);
			            			}, "METHOD", 
								m => m.Groups[2].ToString()),	
							new RegexMatcher(OperatorMarker,
			            		m =>
			            			{
			            				string name = StringConvertUtils.ConvertOperator(m.Groups[2].ToString());
			            				string extras = StringConvertUtils.ConvertArgsToString(m.Groups[3].ToString());
			            				return String.Concat(name, extras);
			            			}, "OPERATOR"),
							new RegexMatcher(FieldAssignmentMarker, DefaultMatcher, "FIELD ASSIGNMENT"),
							new RegexMatcher(FieldMarker, DefaultMatcher, "FIELD"),
							
							new RegexMatcher(ConstMarker, DefaultMatcher, "CONST"),
							new RegexMatcher(ConstructorMarker, ConstructorDestructorMatcher, 
								"CONSTRUCTOR", 
								m => "ctor"),

							new RegexMatcher(DestructorMarker, ConstructorDestructorMatcher, "DESTRUCTOR"),
							new RegexMatcher(ConstructorFromAssemblyMarker,
			            		m =>
			            			{
			            				var sb = new StringBuilder(m.Groups[0].ToString());
			            				sb.Replace("Void .ctor(", "");
			            				sb.Replace(")", "");

			            				string args = StringConvertUtils.ConvertArgsToString(sb.ToString());
			            				return String.Concat("ctor", args);
			            			},
			            			"CONSTRUCTOR_ASSEMBLY"),
							new RegexMatcher(EnumEntryAssignmentMarker,
			            		m => m.Groups[1].ToString(), "ENUM_ENTRY"),
							new RegexMatcher(EnumEntryNoAssignment,
			            		m => m.Groups[1].ToString(), "ENUM_ENTRY_NOASS"),
			            		
						};
		}

		//field, fieldassignment, const
		private static string DefaultMatcher(Match m)
		{
			return m.Groups[2].ToString();
		}

		
		private static string ConstructorDestructorMatcher(Match m)
        {
            string extras = StringConvertUtils.ConvertArgsToString(m.Groups[2].ToString());
			string front = m.Groups[0].ToString().StartsWith("~") ? "dtor" : "ctor";
            return String.Concat(front, extras);
        }

		private static string ConstructorMatcherSimplified(Match m)
		{
			return "ctor";
		}
	}

}
