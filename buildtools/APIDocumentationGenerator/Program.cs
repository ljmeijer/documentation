using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Cecil;
using NUnit.Framework;
using UnderlyingModel;

namespace APIDocumentationGenerator2
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			All();
		}

		public static void All()
		{
			var input = DirectoryUtil.EngineDllLocation;
			var assemblies = new[]
				{AssemblyDefinition.ReadAssembly(input), AssemblyDefinition.ReadAssembly(DirectoryUtil.EditorDllLocation)};

			var namespaces = new HashSet<string>();

			foreach (var t in assemblies.Select(a=>a.MainModule).SelectMany(m=>m.Types).Where(UnityDocumentation.IsDocumentedType))
			{
				Console.WriteLine("t:"+t.FullName);
				namespaces.Add(t.Namespace);
				var output = "c:/alchemy/build/newdocs/" + UnityDocumentation.HtmlNameFor(t);


				var stringWriter = new StringWriter();
				new TypePageGenerator().GeneratePageFor(t, assemblies,stringWriter);
				File.WriteAllText(output, stringWriter.ToString());
			}

			foreach(var namespaze in namespaces)
			{
				var result = new NamespacePageGenerator().GeneratePageFor(namespaze, assemblies);
				File.WriteAllText("c:/alchemy/build/newdocs/"+UnityDocumentation.HtmlNameFor(namespaze),result);
			}
		}
	}
}
