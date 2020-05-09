using System;
using System.Linq;

public enum Direction
{
    North = 0,
    East = 1,
    South = 2,
    West = 3
}

public class RobotSimulator
{
    public RobotSimulator(Direction direction, int x, int y)
    {
        this.Direction = direction;
        this.X = x;
        this.Y = y;
    }

    public Direction Direction { get; private set; }

    public int X { get; private set; }

    public int Y { get; private set; }

    public void Move(string instructions)
        => instructions.ToList().ForEach(UpdateRobot);

    private void UpdateRobot(char letter)
    {
        if (letter == 'R')
            this.TurnRight();
        else if (letter == 'L')
            this.TurnLeft();
        else
            this.Advance();
    }

    private void TurnRight() => this.Direction = (Direction)(Mod((int)this.Direction + 1, 4));

    private void TurnLeft() => this.Direction = (Direction)(Mod((int)this.Direction - 1, 4));

    private void Advance()
    {
        switch (this.Direction)
        {
            case (Direction.North):
                this.Y += 1;
                break;
            case (Direction.South):
                this.Y -= 1;
                break;
            case (Direction.East):
                this.X += 1;
                break;
            case (Direction.West):
                this.X -= 1;
                break;
        }
    }

    private int Mod(int x, int m) => (x % m + m) % m;
}
