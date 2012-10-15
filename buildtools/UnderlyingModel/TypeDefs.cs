namespace UnderlyingModel
{
	//for identifying things coming from the docs
    public enum TypeKind
    {
        Class,
        Struct,
        Enum,
        AutoProp,
        PureSignature
    }

    //for identifying things coming from the assembly
	public enum AssemblyType
	{
		Class,
		Struct,
		Property,
		Field,
		Method,
		Constructor,
		Enum,
		EnumValue,
		Primitive
	}

	public enum DataItemKind
	{
		Assembly,
		Doc, 
		Combined
	}

	public static class ParserToken
	{
		public const string SignatureOpen = "<signature>";
		public const string SignatureClose = "</signature>";
		public const string BeginEx = "BEGIN EX";
		public const string EndEx = "END EX";
		public const string ConvertExample = "CONVERTEXAMPLE";
		public const string NoCheck = "NOCHECK";
		public const string Param = "@param";
		public const string Return = "@return";
		public const string DocComment = "///";
	}
}
