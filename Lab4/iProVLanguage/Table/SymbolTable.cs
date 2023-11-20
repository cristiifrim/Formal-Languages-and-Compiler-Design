using iProVLanguage.Utils;
using iProVLanguage.Utils.Interfaces;
using System.Text;

namespace iProVLanguage.Table
{
    public class SymbolTable
    {
        private readonly IHashTable<string, int> _symbols;

        private static int NextValue = 0;

        public SymbolTable()
        {
            _symbols = new HashTable<string, int>(SymbolTableConstants.HashTableSize);
        }

        public void AddSymbol(string key)
        {
            _symbols.Add(key, ++NextValue);
        }

        public int GetSymbolValue(string key)
        {
            return _symbols.GetByKey(key);
        }

        public void RemoveSymbol(string key)
        {
            _symbols.Remove(key);
        }

        public override string ToString()
        {
            return _symbols.ToString();
        }
    }
}
