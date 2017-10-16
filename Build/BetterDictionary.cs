namespace System.Collections.Generic
{
    /// <summary>
    ///     An enhanced System.Collections.Dictionary for Unity
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    public class BetterDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        private static readonly IEqualityComparer<TKey> EqualityComparer = UnsafeEqualityComparerFactory.Create<TKey>();

        public BetterDictionary() : base(EqualityComparer)
        {
        }

        public BetterDictionary(int capacity) : base(capacity, EqualityComparer)
        {
        }

        public BetterDictionary(IEqualityComparer<TKey> comparer) : base(0, comparer)
        {
        }

        public BetterDictionary(int capacity, IEqualityComparer<TKey> comparer)
            : base(capacity, comparer)
        {
        }

        public BetterDictionary(IDictionary<TKey, TValue> dictionary)
            : base(dictionary, null)
        {
        }

        public BetterDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
            : base(dictionary, comparer)
        {
        }
    }
}