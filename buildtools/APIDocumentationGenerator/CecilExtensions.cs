using System;
using Mono.Cecil;

static internal class CecilExtensions
{
	public static bool IsVoid(this TypeReference propertyType)
	{
		return propertyType == propertyType.Module.TypeSystem.Void;
	}

	public static bool IsBoolean(this TypeReference propertyType)
	{
		return propertyType == propertyType.Module.TypeSystem.Boolean;
	}

	public static bool IsStatic(this PropertyDefinition propertyDefinition)
	{
		var method = propertyDefinition.GetMethod ?? propertyDefinition.SetMethod;
		return method.IsStatic;
	}

	public static bool IsStatic(this MemberReference mr)
	{
		var pd = mr as PropertyDefinition;
		if (pd != null) return pd.IsStatic();

		var md = mr as MethodDefinition;
		if (md != null) return md.IsStatic;

		throw new ArgumentException();
	}

	public static bool IsPublic(this PropertyDefinition prop)
	{
		if (prop.SetMethod != null)
			if (prop.SetMethod.IsPublic)
				return true;
		if (prop.GetMethod != null)
			if (prop.GetMethod.IsPublic)
				return true;
		return false;
	}

	public static TypeReference GetReturnType(this MemberReference memberReference)
	{
		var method = memberReference as MethodDefinition;
		if (method != null)
			return method.ReturnType;

		var property = memberReference as PropertyDefinition;
		if (property != null)
			return property.PropertyType;

		throw new ArgumentException();
	}
}
