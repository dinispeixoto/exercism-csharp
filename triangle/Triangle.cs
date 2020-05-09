using System;
using System.Linq;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
        => IsValid(side1, side2, side3) && DifferentSides(side1, side2, side3) == 3;

    public static bool IsIsosceles(double side1, double side2, double side3)
        => IsValid(side1, side2, side3) && DifferentSides(side1, side2, side3) >= 1 && !IsScalene(side1, side2, side3);

    public static bool IsEquilateral(double side1, double side2, double side3)
        => IsValid(side1, side2, side3) && DifferentSides(side1, side2, side3) == 1;

    public static bool IsValid(double side1, double side2, double side3)
        => side1 != default && side2 != default && side3 != default && DoesntViolateTriangleInequality(side1, side2, side3);

    public static bool DoesntViolateTriangleInequality(double side1, double side2, double side3)
        => side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;

    public static int DifferentSides(double side1, double side2, double side3)
        => new double[] { side1, side2, side3 }.GroupBy(side => side).Count();

}