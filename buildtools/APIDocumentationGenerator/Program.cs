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

		private static string DocumentationRoot()
		{
			return Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "..\\..\\..\\");
		}

		public static void All()
		{
			var assemblies = new[] { AssemblyDefinition.ReadAssembly(DocumentationRoot() + "/content/UnityEngine.dll"), AssemblyDefinition.ReadAssembly(DocumentationRoot() + "/content/UnityEditor.dll") };

			var namespaces = new HashSet<string>();

			EnsureDirectoryExists(ScriptApiOutputDirectory());

			File.Copy(DocumentationRoot() + "/layout/docs.css", ScriptApiOutputDirectory() + "/docs.css", true);

			foreach (var t in assemblies.Select(a=>a.MainModule).SelectMany(m=>m.Types).Where(UnityDocumentation.IsDocumentedType))
			{
				Console.WriteLine("t:"+t.FullName);
				namespaces.Add(t.Namespace);
				
				var output = ScriptApiOutputDirectory() + "/" + UnityDocumentation.HtmlNameFor(t);

				var stringWriter = new StringWriter();
				new TypePageGenerator().GeneratePageFor(t, assemblies,stringWriter);
				
				File.WriteAllText(output, stringWriter.ToString());
			}

			foreach(var namespaze in namespaces)
			{
				var result = new NamespacePageGenerator().GeneratePageFor(namespaze, assemblies);
				File.WriteAllText(ScriptApiOutputDirectory()+"/"+ UnityDocumentation.HtmlNameFor(namespaze), result);
			}
		}

		private static void EnsureDirectoryExists(string scriptApiOutputDirectory)
		{
			if (Directory.Exists(scriptApiOutputDirectory)) 
				return;

			EnsureDirectoryExists(Path.GetDirectoryName(scriptApiOutputDirectory));
			Directory.CreateDirectory(scriptApiOutputDirectory);
		}

		private static string ScriptApiOutputDirectory()
		{
			return DocumentationRoot() + "output/api";
		}
	}
}
