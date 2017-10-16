using System.Runtime.CompilerServices;

namespace System.Collections.Generic
{
    /// <summary>
    ///     Provides the factory method of the UnsafeEqualityComparers.
    /// </summary>
    internal static class UnsafeEqualityComparerFactory
    {
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
                return new UnsafeEqualityComparer_Int32<T>();
            }
            if (keyType == typeof(long))
            {
                return new UnsafeEqualityComparer_Int64<T>();
            }
            if (keyType == typeof(ulong))
            {
                return new UnsafeEqualityComparer_UInt64<T>();
            }
            return null; // float, double, structs
        }
    }

    /// <summary>
    ///     An implementation of <see cref="IEqualityComparer{T}" /> for 32 bit signed integer types.
    /// </summary>
    /// <typeparam name="T">The enum type to compare.</typeparam>
    internal struct UnsafeEqualityComparer_Int32<T> : IEqualityComparer<T>
    {
        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern bool Equals(T x, T y);

        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern int GetHashCode(T obj);
    }

    /// <summary>
    ///     An implementation of <see cref="IEqualityComparer{T}" /> for 64 bit signed integer types.
    /// </summary>
    /// <typeparam name="T">The enum type to compare.</typeparam>
    internal struct UnsafeEqualityComparer_Int64<T> : IEqualityComparer<T>
    {
        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern bool Equals(T x, T y);

        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern int GetHashCode(T obj);
    }

    /// <summary>
    ///     An implementation of <see cref="IEqualityComparer{T}" /> for 64 bit unsigned integer types.
    /// </summary>
    /// <typeparam name="T">The enum type to compare.</typeparam>
    internal struct UnsafeEqualityComparer_UInt64<T> : IEqualityComparer<T>
    {
        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern bool Equals(T x, T y);

        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern int GetHashCode(T obj);
    }
}