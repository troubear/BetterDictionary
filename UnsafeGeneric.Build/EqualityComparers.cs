using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Better.UnsafeGeneric
{
    /// <summary>
    ///     An implementation of <see cref="IEqualityComparer{T}" /> for 32 bit signed integer types.
    /// </summary>
    /// <typeparam name="T">The integer type to compare.</typeparam>
    public sealed class Int32EqualityComparer<T> : IEqualityComparer<T>
    {
        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern bool Equals(T x, T y);

        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern int GetHashCode(T obj);
    }

    /// <summary>
    ///     An implementation of <see cref="IEqualityComparer{T}" /> for 64 bit signed integer types.
    /// </summary>
    /// <typeparam name="T">The integer type to compare.</typeparam>
    public sealed class Int64EqualityComparer<T> : IEqualityComparer<T>
    {
        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern bool Equals(T x, T y);

        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern int GetHashCode(T obj);
    }

    /// <summary>
    ///     An implementation of <see cref="IEqualityComparer{T}" /> for 64 bit unsigned integer types.
    /// </summary>
    /// <typeparam name="T">The integer type to compare.</typeparam>
    public sealed class UInt64EqualityComparer<T> : IEqualityComparer<T>
    {
        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern bool Equals(T x, T y);

        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern int GetHashCode(T obj);
    }

    /// <summary>
    ///     An implementation of <see cref="IEqualityComparer{T}" /> for the string type.
    /// </summary>
    public sealed class StringEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return string.Equals(x, y);
        }

        public int GetHashCode(string obj)
        {
            return StringHashCode.Calculate(obj);
        }
    }
}