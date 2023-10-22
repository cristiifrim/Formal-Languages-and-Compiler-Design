namespace ConsoleApp1.Models
{
    public class SymbolTable
    {
        private readonly HashTable<object, int> hashTable;
        public int Capacity => hashTable.Capacity;
        private int autoIndex = 1;

        public SymbolTable(int size)
        {
            hashTable = new HashTable<object, int>(size);
        }

        public void AddSymbol(object symbol)
        {
            hashTable.Add(symbol, autoIndex++);
        }

        public int GetByKey(object key)
        {
            return hashTable.Get(key);
        }

        public KeyValuePair<object, int>? GetPair(object key)
        {
            return hashTable.GetPair(key);
        }
    }
}
