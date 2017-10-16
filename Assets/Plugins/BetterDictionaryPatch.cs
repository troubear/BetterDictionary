using System.Collections.Generic;

/// <summary>
///     An enhanced System.Collections.Dictionary for Unity
/// </summary>
/// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
/// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
public class Dictionary<TKey, TValue> : BetterDictionary<TKey, TValue>
{
    public Dictionary()
    {
    }

    public Dictionary(int capacity) : base(capacity)
    {
    }

    public Dictionary(IEqualityComparer<TKey> comparer) : base(comparer)
    {
    }

    public Dictionary(int capacity, IEqualityComparer<TKey> comparer)
        : base(capacity, comparer)
    {
    }

    public Dictionary(IDictionary<TKey, TValue> dictionary)
        : base(dictionary)
    {
    }

    public Dictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        : base(dictionary, comparer)
    {
    }
}