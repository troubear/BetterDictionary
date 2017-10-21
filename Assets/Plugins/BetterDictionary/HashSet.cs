using System.Collections.Generic;
using UnsafeGeneric;

#if !BETTER_PATCH
namespace Better
{
#endif
/// <summary>
///     A generic hash set class optimized for the Unity.
/// </summary>
/// <typeparam name="T">The type of elements in the hash set.</typeparam>
public class HashSet<T> : System.Collections.Generic.HashSet<T>
{
    private static readonly IEqualityComparer<T> EqualityComparer = EqualityComparerFactory.Create<T>();

    /// <summary>
    ///     Initializes a new instance of the <see cref="T:Better.HashSet`1" /> class that is empty
    ///     and uses the default equality comparer for the set type.
    /// </summary>
    public HashSet() : this((IEqualityComparer<T>) null)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="T:Better.HashSet`1" /> class that is empty
    ///     and uses the specified equality comparer for the set type.
    /// </summary>
    /// <param name="comparer">
    ///     The <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> implementation to use when
    ///     comparing values in the set, or null to use the default
    ///     <see cref="T:System.Collections.Generic.EqualityComparer`1" /> implementation for the set type.
    /// </param>
    public HashSet(IEqualityComparer<T> comparer) : base(comparer ?? EqualityComparer)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="T:Better.HashSet`1" /> class that uses the
    ///     default equality comparer for the set type, contains elements copied from the specified collection, and has
    ///     sufficient capacity to accommodate the number of elements copied.
    /// </summary>
    /// <param name="collection">The collection whose elements are copied to the new set.</param>
    /// <exception cref="T:System.ArgumentNullException">
    ///     <paramref name="collection" /> is null.
    /// </exception>
    public HashSet(IEnumerable<T> collection) : this(collection, null)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="T:Better.HashSet`1" /> class that uses the
    ///     specified equality comparer for the set type, contains elements copied from the specified collection, and has
    ///     sufficient capacity to accommodate the number of elements copied.
    /// </summary>
    /// <param name="collection">The collection whose elements are copied to the new set.</param>
    /// <param name="comparer">
    ///     The <see cref="T:System.Collections.Generic.IEqualityComparer`1" /> implementation to use when
    ///     comparing values in the set, or null to use the default
    ///     <see cref="T:System.Collections.Generic.EqualityComparer`1" /> implementation for the set type.
    /// </param>
    /// <exception cref="T:System.ArgumentNullException">
    ///     <paramref name="collection" /> is null.
    /// </exception>
    public HashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
        : base(collection, comparer ?? EqualityComparer)
    {
    }
}
#if !BETTER_PATCH
}
#endif