using System;

public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
        => white.SameRowAs(black) || white.SameColumnAs(black) || white.SameDiagonalAs(black);

    public static Queen Create(int row, int column)
        => (row >= 0 && row < 8 && column >= 0 && column < 8) ? new Queen(row, column) : throw new ArgumentOutOfRangeException();

    private static bool SameRowAs(this Queen white, Queen black)
        => white.Row == black.Row;

    private static bool SameColumnAs(this Queen white, Queen black)
        => white.Column == black.Column;

    private static bool SameDiagonalAs(this Queen white, Queen black)
        => Math.Abs(white.Column - black.Column) == Math.Abs(white.Row - black.Row);
}
