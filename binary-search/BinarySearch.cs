using System;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        var min = 0;
        var max = input.Length - 1;

        var result = -1;

        if (input.Length == 0) return result;

        while (value >= input[min] && value <= input[max])
        {
            var index = (min + max) / 2;
            var tmp_value = input[index];

            if (tmp_value == value)
            {
                result = index;
                break;
            }
            else
            {
                if (value >= tmp_value)
                {
                    min = index + 1;
                }
                else
                {
                    max = index - 1;
                }
            }
        }

        return result;
    }
}