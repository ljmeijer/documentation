using System;
using System.Collections.Generic;
using System.Text;

namespace UnderlyingModel
{
	public static class StringConvertUtils
	{
		//note the spaces after each word!
		static readonly string[] Modifiers = { "private ", "internal ", "public ", "delegate ", "abstract ", "const ", "static ", "virtual ", "override "};
		static readonly string[] ParamModifiers = { "ref ", "params ", "out " };


		public static string ConvertArgsToString(string args)
		{
			var ret = new StringBuilder();

			if (args.Trim().Length > 0)
			{
				var sb = new StringBuilder(args);
				SimplifyArrays(ref sb);

				var p = sb.ToString().Split(',');
				foreach (var pp in p)									// foreach arg
				{
					var ppp = StripMethodParameters(pp.Trim());			// remove any method param		
					var indexOf = ppp.IndexOf(" ");
					if (indexOf > 0)
						ppp = ppp.Substring(0, indexOf).Trim();	// grab just type
					else
					{
						indexOf = ppp.IndexOf("\t"); //if space not found, try to find tab
						if (indexOf > 0)
							ppp = ppp.Substring(0, indexOf).Trim();	// grab just type
					}
					ret.AppendFormat("_{0}", ppp);
				}
			}

			SimplifyTypes(ref ret);
			return ret.ToString();
		}

		public static string ConvertOperator(string o)
		{
			var sb = new StringBuilder(o.TrimStart());
			sb.Replace("+", "Plus");
			sb.Replace("-", "Minus");
			sb.Replace("*", "Times");
			sb.Replace("/", "Divide");
			sb.Replace("!=", "NotEqual");
			sb.Replace("==", "Equal");
			return sb.ToString();
		}

        public static string ConvertOperatorFromAssembly(string o)
        {
            var sb = new StringBuilder(o.TrimStart());
            sb.Replace("Addition", "Plus");
            sb.Replace("Subtraction", "Minus");
            sb.Replace("Multiplication", "Times");
            sb.Replace("Division", "Divide");
            sb.Replace("Inequality", "NotEqual");
            sb.Replace("Equality", "Equal");
            sb.Replace("UnaryNegation", "Minus");
            return sb.ToString();
        }
        
        
		//to manage name collision in Windows where test.txt is equivalent to Test.txt
		public static string LowerCaseNeedsUnderscore(string s)
		{
			if (s.StartsWith("ctor") || s.StartsWith("dtor") || s.StartsWith("implop") || s.StartsWith("operator"))
				return s;
			if (s.Length > 0 && Char.IsLower(s[0]))
				return string.Format("_{0}", s);
			return s;
		}

		private static void SimplifyTypes(ref StringBuilder sb)
		{
			sb.Replace("UnityEngine.", ""); //consider "UEobject" instead to make the distinction
			sb.Replace("UnityEditor.", "");
			sb.Replace("System.", "");
			sb.Replace("Object", "object");
			sb.Replace("String", "string");
			sb.Replace("Int32", "int");
			sb.Replace("Boolean", "bool");
			sb.Replace("Float", "float");
			sb.Replace("Single", "float");
			sb.Replace("Double", "double");
			sb.Replace("Byte", "byte");
			sb.Replace("/", ".");
		}

		private static void SimplifyArrays(ref StringBuilder sb)
		{
			sb.Replace("[]", "Array");
			sb.Replace("[,]", "Array");
			sb.Replace("[,,]", "Array");
		}

		private static void SimplifyTypesAndArrays(ref StringBuilder sb)
		{
			SimplifyTypes(ref sb);
			SimplifyArrays(ref sb);
		}

		public static string SimplifyTypesAndArrays(this string str)
		{
			var sb = new StringBuilder(str);
			SimplifyTypesAndArrays(ref sb);
			return sb.ToString();
		}

		private static string StripFromList(string s, IEnumerable<string> list)
		{
			var a = new StringBuilder(s);
			foreach (var mod in list)
				a.Replace(mod, "");

			return a.ToString().Trim();
		}

		private static string StripMethodParameters(string s)
		{
			return StripFromList(s, ParamModifiers);            
		}

		public static string StripCommonModifiers(string s)
		{
			return StripFromList(s, Modifiers);
		}
	}
}
