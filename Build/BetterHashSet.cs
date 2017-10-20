using System.Linq;

namespace System.Collections.Generic
{
    /// <summary>
    ///     An enhanced System.Collections.Generic.HashSet for Unity
    /// </summary>
    /// <typeparam name="T">The type of elements in the hash set.</typeparam>
    public class BetterHashSet<T> : HashSet<T>
    {
        private static readonly IEqualityComparer<T> EqualityComparer = UnsafeEqualityComparerFactory.Create<T>();

        public BetterHashSet() : base(EqualityComparer)
        {
        }

        public BetterHashSet(IEqualityComparer<T> comparer) : base(comparer)
        {
        }

        public BetterHashSet(IEnumerable<T> collection)
            : base(collection, EqualityComparer)
        {
        }

        public BetterHashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
            : base(collection, comparer)
        {
        }
    }
}