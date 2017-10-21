using System.Collections.Generic;
using UnsafeGeneric;

#if BETTER_PATCH
namespace Better
{
    /// <summary>
    ///     The define symbol 'BETTER_PATCH' is enabled.
    /// </summary>
    public abstract class ReadMe
    {
    }
}
#else
namespace Better
{
    /// <summary>
    ///     To replace the default <see cref="T:System.Collections.Generic.Dictionary`2" /> and
    ///     <see cref="T:System.Collections.Generic.HashSet`1" /> classes with the better classes, add the define symbol
    ///     'BETTER_PATCH' to the PlayerSettings.
    /// </summary>
    public abstract class ReadMe
    {
    }
}
#endif

#if !BETTER_PATCH
namespace Better
{
#endif
    /// <summary>
    ///     A generic dictionary class optimized for the Unity.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    public class Dictionary<TKey, TValue> : System.Collections.Generic.Dictionary<TKey, TValue>
    {
        private static readonly IEqualityComparer<TKey> EqualityComparer = EqualityComparerFactory.Create<TKey>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:Better.Dictionary`2" /> class that is
        ///     empty, has the default initial capacity, and uses the default equality comparer for the key type.
        /// </summary>
        public Dictionary() : this(0, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:Better.Dictionary`2" /> class that is
        ///     empty, has the specified initial capacity, and uses the default equality comparer for the key type.
        /// </summary>
        /// <param name="capacity">
        ///     The initial number of elements that the <see cref="T:Better.Dictionary`2" />
        ///     can contain.
        /// </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="capacity" /> is less than 0.
        /// </exception>
        public Dictionary(int capacity) : this(capacity, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:Better.Dictionary`2" /> class that is
        ///     empty, has the default initial capacity, and uses the specified
        ///     <see cref="T:System.Collections.Generic.IEqualityComparer`1" />.
        /// </summary>
        /// <param name="comparer">
        ///     The <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> implementation to use when
        ///     comparing keys, or null to use the default <see cref="T:Better.Dictionary`1" /> for the
        ///     type of the key.
        /// </param>
        public Dictionary(IEqualityComparer<TKey> comparer) : this(0, comparer)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:Better.Dictionary`2" /> class that is
        ///     empty, has the specified initial capacity, and uses the specified
        ///     <see cref="T:System.Collections.Generic.IEqualityComparer`1" />.
        /// </summary>
        /// <param name="capacity">
        ///     The initial number of elements that the <see cref="T:Better.Dictionary`2" />
        ///     can contain.
        /// </param>
        /// <param name="comparer">
        ///     The <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> implementation to use when
        ///     comparing keys, or null to use the default <see cref="T:System.Collections.Generic.EqualityComparer`1" /> for the
        ///     type of the key.
        /// </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        ///     <paramref name="capacity" /> is less than 0.
        /// </exception>
        public Dictionary(int capacity, IEqualityComparer<TKey> comparer) : base(capacity, comparer ?? EqualityComparer)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:Better.Dictionary`2" /> class that
        ///     contains
        ///     elements copied from the specified <see cref="T:System.Collections.Generic.IDictionary`2" /> and uses the default
        ///     equality comparer for the key type.
        /// </summary>
        /// <param name="dictionary">
        ///     The <see cref="T:System.Collections.Generic.IDictionary`2" /> whose elements are copied to the
        ///     new <see cref="T:Better.Dictionary`2" />.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="dictionary" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="dictionary" /> contains one or more duplicate keys.
        /// </exception>
        public Dictionary(IDictionary<TKey, TValue> dictionary) : this(dictionary, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:Better.Dictionary`2" /> class that
        ///     contains
        ///     elements copied from the specified <see cref="T:System.Collections.Generic.IDictionary`2" /> and uses the specified
        ///     <see cref="T:System.Collections.Generic.IEqualityComparer`1" />.
        /// </summary>
        /// <param name="dictionary">
        ///     The <see cref="T:System.Collections.Generic.IDictionary`2" /> whose elements are copied to the
        ///     new <see cref="T:Better.Dictionary`2" />.
        /// </param>
        /// <param name="comparer">
        ///     The <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> implementation to use when
        ///     comparing keys, or null to use the default <see cref="T:System.Collections.Generic.EqualityComparer`1" /> for the
        ///     type of the key.
        /// </param>
        /// <exception cref="T:System.ArgumentNullException">
        ///     <paramref name="dictionary" /> is null.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        ///     <paramref name="dictionary" /> contains one or more duplicate keys.
        /// </exception>
        public Dictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
            : base(dictionary, comparer ?? EqualityComparer)
        {
        }
    }
#if !BETTER_PATCH
}
#endif