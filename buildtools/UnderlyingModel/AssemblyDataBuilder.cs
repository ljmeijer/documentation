using System;
using System.Collections.Generic;
using System.Diagnostics;
using Mono.Cecil;
using Mono.Collections.Generic;

namespace UnderlyingModel
{

	/// <summary>
	/// Builder class for AssemblyDataItemSet
	/// </summary>
	public class AssemblyDataBuilder
	{
		public static AssemblyDataItemSet BuildAssemblyDataItemsMonoCecil()
		{
			var asmDataItemsSet = new AssemblyDataItemSet();

			ModuleDefinition asmEngine = null;
			ModuleDefinition asmEditor = null;
			try
			{
				asmEngine = ModuleDefinition.ReadModule(DirectoryUtil.EngineDllLocation);
				asmEditor = ModuleDefinition.ReadModule(DirectoryUtil.EditorDllLocation);
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex);
			}

			var engineDataItems = LoadAssemblyDataItemsMonoCecil(asmEngine);
			Console.Out.WriteLine("engineDataItems.Count = {0}", engineDataItems.Count);
			var editorDataItems = LoadAssemblyDataItemsMonoCecil(asmEditor);
			Console.Out.WriteLine("editorDataItems.Count = {0}", editorDataItems.Count);

			Debug.Assert(engineDataItems != null);
			Debug.Assert(editorDataItems != null);

			asmDataItemsSet.AddDataItems(engineDataItems);
			asmDataItemsSet.AddDataItems(editorDataItems);
			asmDataItemsSet.EngineAssemblySize = engineDataItems.Count;
			asmDataItemsSet.EditorAssemblySize = editorDataItems.Count;
			asmDataItemsSet.engineModule = asmEngine;
			asmDataItemsSet.editorModule = asmEditor;

			return asmDataItemsSet;
		}

		private static List<AssemblyDataItem> LoadAssemblyDataItemsMonoCecil(ModuleDefinition asm)
		{
			Collection<TypeDefinition> types = null;
			var a = new List<AssemblyDataItem>();

			try
			{
				types = asm.Types;
			}
			catch (Exception rte)
			{
				Console.Out.WriteLine("ReflectionTypeLoadException:{0}", rte.Message);
			}

			if (types == null)
			{
				return a;
			}

			// Display all the types contained in the specified assembly.
			foreach (TypeDefinition objType in types)
			{
			    if (!objType.IsPublic)
			        continue;

			    if (objType.IsPrimitive)
			    {
			        var asmDataItem = new AssemblyDataItem(AssemblyType.Primitive, objType, objType.Name);
			        a.Add(asmDataItem);
			    }
			    else if (objType.IsEnum)
			    {
			        var asmDataItem = new AssemblyDataItem(AssemblyType.Enum, objType, objType.Name);
			        a.Add(asmDataItem);
			        AssemblyDataBuilderUtil.BuildAsmChildOfEnum(asmDataItem, a);
			    }
				
			    else if (objType.IsClass || objType.IsValueType && !objType.IsPrimitive)
			    {
			        var classOrStruct = objType.IsClass ? AssemblyType.Class : AssemblyType.Struct;
			        var asmDataItem = new AssemblyDataItem(classOrStruct, objType, objType.Name);
			        a.Add(asmDataItem);
			        AssemblyDataBuilderUtil.BuildAsmChildOfClass(asmDataItem, a);
			    }
				
			    else
			    {
			        Console.Out.WriteLine("Unknown Item: {0}", objType);
			    }
			}

			return a;
		}

		
	}
}
