using System;
using System.Linq;

public class DndCharacter
{
	private static readonly Random random = new Random((int) DateTime.Now.Ticks);

    public int Strength { get; private set; }
    public int Dexterity { get; private set; }
    public int Constitution { get; private set; }
    public int Intelligence { get; private set; }
    public int Wisdom { get; private set; }
    public int Charisma { get; private set; }
    public int Hitpoints => 10 + Modifier(this.Constitution);

    public static int Modifier(int score) => (int)Math.Floor((double)(score - 10) / 2);

    public static int Ability() => Enumerable.Repeat(0, 4)
		.Select(_ => random.Next(1, 7))
		.OrderBy(number => number)
		.Skip(1)
		.Sum();

    public static DndCharacter Generate()
        => new DndCharacter
        {
            Strength = Ability(),
            Dexterity = Ability(),
            Constitution = Ability(),
            Intelligence = Ability(),
            Wisdom = Ability(),
            Charisma = Ability(),
        };
}
