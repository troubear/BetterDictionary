using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnsafeGeneric
{
    /// <summary>
    ///     An implementation of <see cref="IEqualityComparer{T}" /> for 32 bit signed integer types.
    /// </summary>
    /// <typeparam name="T">The interger type to compare.</typeparam>
    internal struct Int32EqualityComparer<T> : IEqualityComparer<T>
    {
        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern bool Equals(T x, T y);

        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern int GetHashCode(T obj);
    }

    /// <summary>
    ///     An implementation of <see cref="IEqualityComparer{T}" /> for 64 bit signed integer types.
    /// </summary>
    /// <typeparam name="T">The interger type to compare.</typeparam>
    internal struct Int64EqualityComparer<T> : IEqualityComparer<T>
    {
        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern bool Equals(T x, T y);

        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern int GetHashCode(T obj);
    }

    /// <summary>
    ///     An implementation of <see cref="IEqualityComparer{T}" /> for 64 bit unsigned integer types.
    /// </summary>
    /// <typeparam name="T">The interger type to compare.</typeparam>
    internal struct UInt64EqualityComparer<T> : IEqualityComparer<T>
    {
        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern bool Equals(T x, T y);

        [MethodImpl(MethodImplOptions.ForwardRef)]
        public extern int GetHashCode(T obj);
    }

    /// <summary>
    ///     An implementation of <see cref="IEqualityComparer{T}" /> for the string types.
    /// </summary>
    internal struct StringEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return string.Equals(x, y);
        }

        public int GetHashCode(string obj)
        {
            unsafe
            {
                var hash1 = (5381 << 16) + 5381;
                var hash2 = hash1;
                var len = obj.Length;
                fixed (char* pobj = obj)
                {
                    var pint = (int*) pobj;
                    while (len > 2)
                    {
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ pint[0];
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ pint[1];
                        pint += 2;
                        len -= 4;
                    }
                    if (len > 0)
                    {
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ pint[0];
                    }
                }
                return hash1 + hash2 * 1566083941;
            }
        }
    }
}