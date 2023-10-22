namespace ConsoleApp1.Models
{

    public class HashTable<TKey, TValue>
    {
        public int Capacity { get; set; }
        private LinkedList<KeyValuePair<TKey, TValue>>[] _items;

        public HashTable(int capacity)
        {
            Capacity = capacity;
            _items = new LinkedList<KeyValuePair<TKey, TValue>>[capacity];
        }

        // Add a key-value pair to the hash table
        public void Add(TKey key, TValue value)
        {
            int index = Hash(key);
            if (_items[index] == null)
            {
                _items[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
            _items[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));
        }

        // Get the value associated with a key
        public TValue Get(TKey key)
        {
            int index = Hash(key);
            var list = _items[index];
            if (list != null)
            {
                foreach (var pair in list)
                {
                    if (pair.Key != null && pair.Key.Equals(key))
                    {
                        return pair.Value;
                    }
                }
            }
            throw new KeyNotFoundException("Key not found in the hash table");
        }

        // Find a key-value pair in the hash table and return it
        public KeyValuePair<TKey, TValue>? GetPair(TKey key)
        {
            int index = Hash(key);
            var list = _items[index];
            if (list != null)
            {
                foreach (var pair in list)
                {
                    if (pair.Key != null && pair.Key.Equals(key))
                    {
                        return pair;
                    }
                }
            }
            return null;
        }

        // Hash function to calculate the index for the given key
        private int Hash(object key)
        {
            int hash = key switch
            {
                int intKey => intKey.GetHashCode() % Capacity,
                string stringKey => stringKey.GetHashCode() % Capacity,
                _ => key.GetHashCode() % Capacity
            };

            return hash < 0 ? hash + Capacity : hash;
        }
    }
}