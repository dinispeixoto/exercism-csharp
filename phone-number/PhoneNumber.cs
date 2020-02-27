using System;
using System.Linq;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    private static Match MatchNANP(string phoneNumber) => Regex.Match(string.Concat(phoneNumber.Where(char.IsDigit)), @"^1?([2-9]\d\d[2-9]\d{6})$");

    public static string Clean(string phoneNumber)
    {
        var match = MatchNANP(phoneNumber);
        
        return ((match = MatchNANP(phoneNumber)).Success) ? 
            match.Groups[1].ToString() : throw new ArgumentException();
    }
}