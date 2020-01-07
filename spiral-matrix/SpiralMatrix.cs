using System;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var counter = 1;
        var result = new int[size, size];

        int start_row = 0, start_column = 0, end_row = size - 1, end_column = size - 1;

        if(size == 1) return new int[,] {{counter}};

        while (start_row < end_row && start_column < end_column){

            for(int i = start_column; i < end_column; i++) result[start_row, i] = counter++;

            for(int i = start_row; i < end_row; i++) result[i, end_column] = counter++;

            for(int i = end_column; i > start_column; i--) result[end_row, i] = counter++;

            for(int i = end_row; i > start_row; i--) result[i, start_column] = counter++;

            start_row++; start_column++; end_row--; end_column--;
        }

        if (size % 2 != 0) result[start_row, start_column] = counter;

        return result;
    }
}
