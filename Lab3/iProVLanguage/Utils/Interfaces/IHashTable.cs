namespace iProVLanguage.Utils.Interfaces
{
    /// <summary>
    /// Provides access to Hash Table implementation
    /// </summary>
    public interface IHashTable<TKey, TValue>
    {
        /// <summary>
        /// Get the value that is represented by the given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Value of the key</returns>
        TValue? GetByKey(TKey key);

        /// <summary>
        /// Adds a new Key, Value pair in the hashtable
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Add(TKey key, TValue value);

        /// <summary>
        /// Removes a Key, Value pair from the hashtable
        /// </summary>
        /// <param name="key"></param>
        void Remove(TKey key);
    }
}
