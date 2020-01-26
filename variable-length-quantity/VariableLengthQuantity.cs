using System;
using System.Collections.Generic;

public static class VariableLengthQuantity
{
    // 00000000 00000000 00000000 01111111 -> 01111111 
    // 00000000 00000000 00111111 11111111 -> 11111111 01111111
    // 00001111 11111111 11111111 11111111 -> 11111111 11111111 11111111 01111111

    public static uint[] Encode(uint[] numbers)
    {
        // 1 - Take the last 7 bits
        // 2 - Compare what's left with 0 (remaining & 0 == 0) 
        // 2.1 - If it is we reached the end, which means that the most significant bit is 0
        // 2.2 - If it isn't we have to keep going, the most significant bit is 1 and theirs also 1 bit accumulatted from the previous byte
        var number = numbers[0];
        var encoded = new List<uint>();

        while(number > 0){
            if((number >> 7 & 0) == 0){
                encoded.Add(number);
                break;
            }
            else {
                number-=128;
            }
        }

        return encoded.ToArray();
    }

    public static uint[] Decode(uint[] bytes)
    {
        // 1 - Shift 7 bits -> 1 byte
        // 2 - Compare the most significant bit
        // 2.1 - If 0 we got our int
        // 2.2 - If 1 the next bit belongs to this byte and keep it going
        throw new NotImplementedException("You need to implement this function.");
    }
}