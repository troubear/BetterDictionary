using System;
using UnsafeGeneric;

#if !BETTER_PATCH
namespace Better
{
#endif
    /// <summary>
    ///     A string key class optimized for the Dictionary and HashSet.
    /// </summary>
    public struct StringKey : IEquatable<StringKey>
    {
        /// <summary>
        ///     The string of the key.
        /// </summary>
        public readonly string Value;

        /// <summary>
        ///     The length of the string.
        /// </summary>
        public readonly int Length;

        /// <summary>
        ///     The hash code of the string.
        /// </summary>
        public readonly int HashCode;

        public StringKey(string str)
        {
            Value = str;
            Length = str.Length;
            HashCode = StringHashCode.Calculate(str, Length);
        }

        public bool Equals(StringKey key)
        {
            return Length == key.Length && Value.Equals(key.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj is StringKey)
            {
                return Equals((StringKey)obj);
            }

            // exception will be thrown later for null this
            return this == null;
        }

        public override int GetHashCode()
        {
            return HashCode;
        }

        public static bool operator ==(StringKey a, StringKey b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(StringKey a, StringKey b)
        {
            return !a.Equals(b);
        }

        // StringKey key = "Foo";
        public static implicit operator StringKey(string str)
        {
            return new StringKey(str);
        }

        // StringKey key;
        // string str = key;
        public static implicit operator string(StringKey str)
        {
            return str.Value;
        }
    }
#if !BETTER_PATCH
}
#endif