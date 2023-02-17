using System;

namespace utils;

internal class VarIntUtils
{
    private static readonly int[] VARINT_EXACT_BYTE_LENGTHS = new int[33];

    static VarIntUtils() 
    {
        for (int i = 0; i <= 32; ++i) {
            VARINT_EXACT_BYTE_LENGTHS[i] = (int) Math.Ceiling((31d - (i - 1)) / 7d);
        }
        VARINT_EXACT_BYTE_LENGTHS[32] = 1; // Special case for 0.
    }

    public static int GetVarIntLength(int value) 
    {
        return VARINT_EXACT_BYTE_LENGTHS[NumberOfLeadingZeros(value)];
    }
    
    public static int NumberOfLeadingZeros(int i) 
    {
        // HD, Count leading 0's
        if (i <= 0)
            return i == 0 ? 32 : 0;
        int n = 31;
        if (i >= 1 << 16) { n -= 16; i >>>= 16; }
        if (i >= 1 <<  8) { n -=  8; i >>>=  8; }
        if (i >= 1 <<  4) { n -=  4; i >>>=  4; }
        if (i >= 1 <<  2) { n -=  2; i >>>=  2; }
        return n - (i >>> 1);
    }
}