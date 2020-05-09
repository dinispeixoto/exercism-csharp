using System;
using System.Linq;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
        => IsValid(side1, side2, side3) && NumberOfDifferentSides(side1, side2, side3) == 3;

    public static bool IsIsosceles(double side1, double side2, double side3)
        => IsValid(side1, side2, side3) && !IsScalene(side1, side2, side3);

    public static bool IsEquilateral(double side1, double side2, double side3)
        => IsValid(side1, side2, side3) && NumberOfDifferentSides(side1, side2, side3) == 1;

    public static bool IsValid(double side1, double side2, double side3)
        => side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;

    public static int NumberOfDifferentSides(double side1, double side2, double side3)
        => new double[] { side1, side2, side3 }.GroupBy(side => side).Count();

}