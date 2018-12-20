using System;
using System.Collections.Generic;
using Better.UnsafeGeneric;

namespace Better
{
    /// <summary>
    ///     Provides the factory method of the better EqualityComparers.
    /// </summary>
    public static class EqualityComparerFactory
    {
        private static readonly object StringEqualityComparer = new StringEqualityComparer();
        private static readonly object StringKeyEqualityComparer = new StringKeyEqualityComparer();

        public static IEqualityComparer<T> Create<T>()
        {
            var keyType = typeof(T);
            if (keyType.IsEnum)
            {
                // enum Foo : keyType
                keyType = Enum.GetUnderlyingType(keyType);
            }

            if (keyType == typeof(sbyte) || keyType == typeof(byte) ||
                keyType == typeof(short) || keyType == typeof(ushort) ||
                keyType == typeof(int) || keyType == typeof(uint) ||
                keyType == typeof(char))
            {
                return new Int32EqualityComparer<T>();
            }
            if (keyType == typeof(long))
            {
                return new Int64EqualityComparer<T>();
            }
            if (keyType == typeof(ulong))
            {
                return new UInt64EqualityComparer<T>();
            }
            if (keyType == typeof(string))
            {
                return (IEqualityComparer<T>)StringEqualityComparer;
            }
            if (keyType == typeof(StringKey))
            {
                return (IEqualityComparer<T>)StringKeyEqualityComparer;
            }
            return null; // Use default EqualityComparer
        }
    }

    /// <summary>
    ///     An implementation of <see cref="IEqualityComparer{T}" /> for the <see cref="StringKey" /> type.
    /// </summary>
    class StringKeyEqualityComparer : IEqualityComparer<StringKey>
    {
        public bool Equals(StringKey x, StringKey y)
        {
            return string.Equals(x.Value, y.Value);
        }

        public int GetHashCode(StringKey obj)
        {
            return obj.HashCode;
        }
    }
}