using System;
using System.Linq;

public enum Allergen
{
    Eggs,
    Peanuts,
    Shellfish,
    Strawberries,
    Tomatoes,
    Chocolate,
    Pollen,
    Cats
}

public class Allergies
{
    private readonly int mask;

    public Allergies(int mask) => this.mask = mask;

    public bool IsAllergicTo(Allergen allergen) => ((mask >> (int)allergen) & 1) != 0;

    public Allergen[] List() => Enum.GetValues(typeof(Allergen)).Cast<Allergen>().Where(IsAllergicTo).ToArray();
}