using System;
using Better.UnsafeGeneric;

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
        ///     The hash code of the string.
        /// </summary>
        public readonly int HashCode;

        public StringKey(string str)
        {
            Value = str;
            HashCode = StringHashCode.Calculate(str);
        }

        public bool Equals(StringKey key)
        {
            return string.Equals(Value, key.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj is StringKey)
            {
                return Equals((StringKey)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode;
        }

        public static bool operator ==(StringKey a, StringKey b)
        {
            return a.HashCode == b.HashCode && a.Value == b.Value;
        }

        public static bool operator !=(StringKey a, StringKey b)
        {
            return a.HashCode != b.HashCode || a.Value != b.Value;
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