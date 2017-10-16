// UnsafeEqualityComparer_Int32
.class private sealed sequential ansi beforefieldinit 
  System.Collections.Generic.UnsafeEqualityComparer_Int32`1<T>
    extends [mscorlib]System.ValueType
    implements class [mscorlib]System.Collections.Generic.IEqualityComparer`1<!0/*T*/>
{
    .method public final hidebysig virtual newslot instance bool Equals(!0/*T*/ x, !0/*T*/ y) cil managed
    {
        .maxstack 8

        ldarg.1
        ldarg.2
        ceq
        ret
    }

    .method public final hidebysig virtual newslot instance int32 GetHashCode(!0/*T*/ obj) cil managed
    {
        .maxstack 8

        // return obj;
        ldarg.1
        conv.i8 // HACK: Avoids the compile error on IL2CPP.
        conv.i4
        ret
    }
}

// UnsafeEqualityComparer_Int64
.class private sealed sequential ansi beforefieldinit
  System.Collections.Generic.UnsafeEqualityComparer_Int64`1<T>
    extends [mscorlib]System.ValueType
    implements class [mscorlib]System.Collections.Generic.IEqualityComparer`1<!0/*T*/>
{
    .method public final hidebysig virtual newslot instance bool Equals(!0/*T*/ x, !0/*T*/ y) cil managed
    {
        .maxstack 8

        ldarg.1
        ldarg.2
        ceq
        ret
    }

    .method public final hidebysig virtual newslot instance int32 GetHashCode(!0/*T*/ obj) cil managed
    {
        .maxstack 8

        // return ((int)obj) ^ (int)(obj >> 32);
        ldarg.1
        conv.i8 // HACK: Avoids the compile error on IL2CPP.
        conv.i4
        ldarg.1
        conv.i8 // HACK: Avoids the compile error on IL2CPP.
        ldc.i4.s    32
        shr
        conv.i4
        xor
        ret
    }
}


// UnsafeEqualityComparer_UInt64
.class private sealed sequential ansi beforefieldinit
  System.Collections.Generic.UnsafeEqualityComparer_UInt64`1<T>
    extends [mscorlib]System.ValueType
    implements class [mscorlib]System.Collections.Generic.IEqualityComparer`1<!0/*T*/>
{
    .method public final hidebysig virtual newslot instance bool Equals(!0/*T*/ x, !0/*T*/ y) cil managed
    {
        .maxstack 8

        ldarg.1
        ldarg.2
        ceq
        ret
    }

    .method public final hidebysig virtual newslot instance int32 GetHashCode(!0/*T*/ obj) cil managed
    {
        .maxstack 8

        // return ((int)obj) ^ (int)(obj >> 32);
        ldarg.1
        conv.i8 // HACK: Avoids the compile error on IL2CPP.
        conv.i4
        ldarg.1
        conv.i8 // HACK: Avoids the compile error on IL2CPP.
        ldc.i4.s    32
        shr.un
        conv.i4
        xor
        ret
    }
}