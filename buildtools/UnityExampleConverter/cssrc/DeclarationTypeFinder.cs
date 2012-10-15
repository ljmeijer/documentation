using Boo.Lang.Compiler.Ast;
using Boo.Lang.Compiler.TypeSystem;
using System;
using System.Collections.Generic;

namespace UnityExampleConverter
{
	[Serializable]
	public class DeclarationTypeFinder : TypeFinderBase
	{
		public DeclarationTypeFinder(CompileUnit source)
			: base(source)
		{
		}
		public override void OnMethod(Method node)
		{
			IEnumerator<Local> enumerator = node.Locals.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					Local current = enumerator.Current;
					if (LookingFor(current))
					{
						Found(TypeSystemServices.GetType(current));
					}
				}
			}
			finally
			{
				enumerator.Dispose();
			}
		}
	}
}
