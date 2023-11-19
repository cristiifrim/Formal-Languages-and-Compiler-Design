using iProVLanguage.Utils.Interfaces;
using System.Text;

namespace iProVLanguage.Utils
{
    public class HashTable<TKey, TValue> : IHashTable<TKey, TValue>
    {
        private readonly int _capacity;
        private readonly List<(TKey, TValue)>[] _items;

        public HashTable(int capacity)
        {
            _capacity = capacity;
            _items = new List<(TKey Key, TValue Value)>[_capacity];
        }

        public TValue? GetByKey(TKey key)
        {
            var index = GetKeyIndex(key);
            var itemsList = GetIndexItems(index);
            foreach (var (Key, Value) in itemsList)
            {
                if (Key != null && Key.Equals(key))
                {
                    return Value;
                }
            }
            return default;
        }

        public void Add(TKey key, TValue value)
        {
            if (key != null)
            {
                var index = GetKeyIndex(key);
                var itemsList = GetIndexItems(index);
                itemsList.Add((key, value));
            }
        }

        public void Remove(TKey key)
        {
            if (key != null)
            {
                var index = GetKeyIndex(key);
                var itemsList = GetIndexItems(index);
                itemsList.RemoveAll(item => item.Key != null && item.Key.Equals(key));
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("Hash Table Contents:\n");

            for (int i = 0; i < _capacity; i++)
            {
                var itemsList = _items[i];
                if (itemsList != null && itemsList.Any())
                {
                    result.Append($"{i}: ");
                    result.Append("[ ");
                    foreach (var (Key, Value) in itemsList)
                    {
                        result.Append($"({Key}, {Value}), ");
                    }
                    result.Remove(result.Length - 2, 2); // Remove the trailing comma and space
                    result.Append(" ]");
                    result.AppendLine();
                }

            }

            return result.ToString();
        }

        private int GetKeyIndex(TKey key)
        {
            return key == null ? 0 : Math.Abs(key.GetHashCode()) % _capacity;
        }

        private List<(TKey Key, TValue Value)> GetIndexItems(int index)
        {
            var items = _items[index];
            if (items == null)
            {
                items = new List<(TKey Key, TValue Value)>();
                _items[index] = items;
            }
            return items;
        }
    }
}
