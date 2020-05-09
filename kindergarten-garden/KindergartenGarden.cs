using System;
using System.Linq;
using System.Collections.Generic;

public enum Plant
{
    Violets = 'V',
    Radishes = 'R',
    Clover = 'C',
    Grass = 'G'
}

public class KindergartenGarden
{
    private readonly IEnumerable<string> garden;
    private readonly IEnumerable<string> students = new List<string> {
        "Alice", "Bob", "Charlie", "David", "Eve", "Fred", "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry"
    };

    public KindergartenGarden(string diagram)
    {
        this.garden = diagram
            .Split(new[] { Environment.NewLine }, StringSplitOptions.None)
            .Select(line => line);
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var index = students.ToList().IndexOf(student);

        var first = (index * 2);
        var second = (index * 2) + 1;

        return new Plant[] {
            (Plant)this.garden.ToList()[0][first],
            (Plant)this.garden.ToList()[0][second],
            (Plant)this.garden.ToList()[1][first],
            (Plant)this.garden.ToList()[1][second],
        };
    }
}