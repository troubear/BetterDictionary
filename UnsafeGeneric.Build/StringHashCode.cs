namespace Better.UnsafeGeneric
{
    /// <summary>
    ///     Provides the string hash code calculation method.
    /// </summary>
    public static class StringHashCode
    {
        public static unsafe int Calculate(string str)
        {
            fixed (char* fixedStr = str)
            {
                var p = fixedStr;
                var len = str.Length;

                // 1~16 characters
                switch (len)
                {
                    case 1:
                        return *p;
                    case 2:
                        return *(int*)p;
                    case 3:
                    {
                        // The legacy hash algorithm of the Unity(Mono)
                        var hash = 0;
                        hash = (hash << 5) - hash + *p++;
                        hash = (hash << 5) - hash + *p++;
                        hash = (hash << 5) - hash + *p;
                        return hash;
                    }
                    case 4:
                    {
                        var hash = 0;
                        hash = (hash << 5) - hash + *p++;
                        hash = (hash << 5) - hash + *p++;
                        hash = (hash << 5) - hash + *p++;
                        hash = (hash << 5) - hash + *p;
                        return hash;
                    }
                    // ---- The performance border line of the hash algorithm on 'MY' 64 bit PC ----
                    case 5:
                    case 6:
                    {
                        // The modern hash algorithm of the .NET
                        var hash1 = (5381 << 16) + 5381;
                        var hash2 = hash1;
                        var p32 = (int*)p;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32++;
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ *p32++;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32;
                        return hash1 + hash2 * 1566083941;
                    }
                    case 7:
                    case 8:
                    {
                        var hash1 = (5381 << 16) + 5381;
                        var hash2 = hash1;
                        var p32 = (int*)p;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32++;
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ *p32++;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32++;
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ *p32;
                        return hash1 + hash2 * 1566083941;
                    }
                    case 9:
                    case 10:
                    {
                        var hash1 = (5381 << 16) + 5381;
                        var hash2 = hash1;
                        var p32 = (int*)p;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32++;
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ *p32++;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32++;
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ *p32++;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32;
                        return hash1 + hash2 * 1566083941;
                    }
                    case 11:
                    case 12:
                    {
                        var hash1 = (5381 << 16) + 5381;
                        var hash2 = hash1;
                        var p32 = (int*)p;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32++;
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ *p32++;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32++;
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ *p32++;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32++;
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ *p32;
                        return hash1 + hash2 * 1566083941;
                    }
                    case 13:
                    case 14:
                    {
                        var hash1 = (5381 << 16) + 5381;
                        var hash2 = hash1;
                        var p32 = (int*)p;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32++;
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ *p32++;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32++;
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ *p32++;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32++;
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ *p32++;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32;
                        return hash1 + hash2 * 1566083941;
                    }
                    case 15:
                    case 16:
                    {
                        var hash1 = (5381 << 16) + 5381;
                        var hash2 = hash1;
                        var p32 = (int*)p;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32++;
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ *p32++;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32++;
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ *p32++;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32++;
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ *p32++;
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32++;
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ *p32;
                        return hash1 + hash2 * 1566083941;
                    }
                }

                // 17 characters or more
                {
                    var hash1 = (5381 << 16) + 5381;
                    var hash2 = hash1;
                    var p32 = (int*)p;
                    while (len > 2)
                    {
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32++;
                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ *p32++;
                        len -= 4;
                    }
                    if (len > 0)
                    {
                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ *p32;
                    }
                    return hash1 + hash2 * 1566083941;
                }
            }
        }
    }
}