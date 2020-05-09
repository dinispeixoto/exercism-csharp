using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        var distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

        if (distance <= 1)
            return 10;

        if (distance <= 5)
            return 5;

        if (distance <= 10)
            return 1;
            
        return 0;
    }
}
