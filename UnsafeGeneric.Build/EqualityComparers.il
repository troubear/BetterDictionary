// Int32EqualityComparer<T>
.class private sealed sequential ansi beforefieldinit
  Better.UnsafeGeneric.Int32EqualityComparer`1<T>
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

// Int64EqualityComparer<T>
.class private sealed sequential ansi beforefieldinit
  Better.UnsafeGeneric.Int64EqualityComparer`1<T>
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


// UInt64EqualityComparer<T>
.class private sealed sequential ansi beforefieldinit
  Better.UnsafeGeneric.UInt64EqualityComparer`1<T>
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