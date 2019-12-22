using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private readonly List<int> scores;

    public HighScores(List<int> list)
    {
        this.scores = list;
    }

    public List<int> Scores() => this.scores;

    public int Latest() => this.scores.Last();

    public int PersonalBest() => this.scores.Max();

    public List<int> PersonalTopThree() => this.scores
        .OrderByDescending(score => score)
        .Take(3)
        .ToList();
}