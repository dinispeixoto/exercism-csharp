using System;
using System.Linq;

public static class Answers {
    public static string Question => "Sure.";
    public static string Yell => "Whoa, chill out!";
    public static string Yell_Question => "Calm down, I know what I'm doing!";
    public static string Nothing => "Fine. Be that way!";
    public static string Anything_Else => "Whatever.";
}

public static class Bob
{
    public static string Response(string statement) => 
        !statement.IsEmpty() ? 
            statement.IsQuestion() ? 
                statement.IsYell() ? Answers.Yell_Question : Answers.Question : 
            statement.IsYell() ? Answers.Yell : Answers.Anything_Else : 
        Answers.Nothing; 

    public static bool IsEmpty(this string statement) => string.IsNullOrWhiteSpace(statement.Trim());
    public static bool IsQuestion(this string statement) => statement.Contains("?") && statement.Trim().EndsWith("?");
    public static bool IsYell(this string statement) => statement.ToUpper().Equals(statement) && statement.Any(char.IsLetter);
}