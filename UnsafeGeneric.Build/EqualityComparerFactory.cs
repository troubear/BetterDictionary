using System;
using System.Collections.Generic;

namespace UnsafeGeneric
{
    /// <summary>
    ///     Provides the factory method of the unsafe EqualityComparers.
    /// </summary>
    public static class EqualityComparerFactory
    {
        private static readonly object StringEqualityComparer = new StringEqualityComparer();

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
                return (IEqualityComparer<T>) StringEqualityComparer;
            }
            return null; // float, double, structs
        }
    }
}