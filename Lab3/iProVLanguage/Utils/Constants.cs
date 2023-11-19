namespace iProVLanguage.Utils
{
    public static class SymbolTableConstants
    {
        public const int HashTableSize = 1024;
    }

    public enum SymbolTableType
    {
        Constants = 1,
        Identifiers = 2
    }

    public static class ProgramPaths
    {
        public const string Problem1 = "C:\\Users\\cifrim\\Desktop\\iProVLanguage\\Formal-Languages-and-Compiler-Design\\Lab3\\iProVLanguage\\Resources\\p1.txt";
        public const string Problem1Error = "C:\\Users\\cifrim\\Desktop\\iProVLanguage\\Formal-Languages-and-Compiler-Design\\Lab3\\iProVLanguage\\Resources\\p1err.txt";
        public const string Problem2 = "C:\\Users\\cifrim\\Desktop\\iProVLanguage\\Formal-Languages-and-Compiler-Design\\Lab3\\iProVLanguage\\Resources\\p2.txt";
        public const string Problem3 = "C:\\Users\\cifrim\\Desktop\\iProVLanguage\\Formal-Languages-and-Compiler-Design\\Lab3\\iProVLanguage\\Resources\\p3.txt";
    }

    public static class OutputPaths
    {
        public const string ProgramInternalForm = "C:\\Users\\cifrim\\Desktop\\iProVLanguage\\Formal-Languages-and-Compiler-Design\\Lab3\\iProVLanguage\\Resources\\pif.out";
        public const string SymbolTable = "C:\\Users\\cifrim\\Desktop\\iProVLanguage\\Formal-Languages-and-Compiler-Design\\Lab3\\iProVLanguage\\Resources\\st.out";
    }

    public static class InputPaths
    {
        public const string Tokens = "C:\\Users\\cifrim\\Desktop\\iProVLanguage\\Formal-Languages-and-Compiler-Design\\Lab3\\iProVLanguage\\Resources\\Tokens.in";
    }
}
