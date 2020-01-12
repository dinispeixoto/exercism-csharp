using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public static class Match
{
    public enum Points
    {
        LOSS = 0,
        DRAW = 1,
        WIN = 3
    }
    public static Points Parse(this string points) => (Points)Enum.Parse(typeof(Points), points, true);
    public static Points Reverse(this Points points) => points == Points.WIN ? Points.LOSS : points == Points.LOSS ? Points.WIN : Points.DRAW;
}

public class Team
{
    public string Name { get; set; }
    public int MatchesWon { get; set; }
    public int MatchesDrawn { get; set; }
    public int MatchesLost { get; set; }
    public int MatchesPlayed => this.MatchesWon + this.MatchesDrawn + this.MatchesLost;
    public int Points => this.MatchesWon * (int)Match.Points.WIN + this.MatchesDrawn * (int)Match.Points.DRAW + this.MatchesLost * (int)Match.Points.LOSS;
    public void AddMatch(Match.Points points)
    {
        if (points == Match.Points.WIN) this.MatchesWon++;
        else if (points == Match.Points.LOSS) this.MatchesLost++;
        else this.MatchesDrawn++;
    }
    public string ToString() => $"{Name,-30} | {MatchesPlayed,2} | {MatchesWon,2} | {MatchesDrawn,2} | {MatchesLost,2} | {Points,2}";
}

public static class Tournament
{
    public static void Tally(Stream inStream, Stream outStream) => inStream
        .ReadLinesFromStream()
        .ProcessLines()
        .BuildOutputTable()
        .WriteLinesToStream(outStream);

    private static Dictionary<string, Team> ProcessLines(this IEnumerable<string> lines)
    {
        var teams = new Dictionary<string, Team>();
        lines.ToList().ForEach(line => teams.ProcessLine(line));
        return teams;
    }

    private static Dictionary<string, Team> ProcessLine(this Dictionary<string, Team> teams, string line)
    {
        var splitted = line.Split(';');
        var matchResult = splitted[2].Parse();

        return teams
            .UpdateTeam(splitted[0], matchResult)
            .UpdateTeam(splitted[1], matchResult.Reverse());
    }

    private static IEnumerable<string> BuildOutputTable(this Dictionary<string, Team> teams)
    {
        return teams.Keys
            .OrderByDescending(team => teams[team].Points)
            .ThenBy(team => team)
            .Select(team => teams[team].ToString());
    }

    private static Dictionary<string, Team> UpdateTeam(this Dictionary<string, Team> teams, string name, Match.Points points)
    {
        teams.TryGetValue(name, out var team);
        (team ??= new Team { Name = name }).AddMatch(points);
        teams[name] = team;
        return teams;
    }

    private static void WriteLinesToStream(this IEnumerable<string> lines, Stream stream)
    {
        using (StreamWriter writer = new StreamWriter(stream)){
            writer.Write("Team                           | MP |  W |  D |  L |  P"); 
            lines.ToList().ForEach(line => { writer.Write("\n"); writer.Write(line); });
        }
    }

    private static IEnumerable<string> ReadLinesFromStream(this Stream stream)
    {
        using (StreamReader reader = new StreamReader(stream))
            while (!reader.EndOfStream)
                yield return reader.ReadLine();
    }
}
