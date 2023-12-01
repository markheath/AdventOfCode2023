using SuperLinq;

namespace AdventOfCode2023;

// https://adventofcode.com/2023/day/1
public class Day1 : ISolver
{
    public (string, string) ExpectedResult => ("53386", "53312");

    private static readonly string[] digits = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

    public (string, string) Solve(string[] input)
    {
        var part1 = input
                        .Select(line => $"{line.First(c => char.IsDigit(c))}{line.Last(c => char.IsDigit(c))}")
                        .Sum(int.Parse);
        var part2 = input
                        .Select(line => $"{FindDigit(line, false)}{FindDigit(line, true)}")
                        .Sum(int.Parse);
        
        return (part1.ToString(), part2.ToString());
    }

    private int FindDigit(string input, bool reverse)
    {
        var indexes = Enumerable.Range(0, input.Length);
        if (reverse) indexes = indexes.Reverse();
        foreach (var n in indexes)
        {            
            if (char.IsDigit(input[n])) return input[n] - '0';
            var matchedDigit = digits.FirstOrDefault(d => input.Substring(n).StartsWith(d));
            if (matchedDigit != null)
                return digits.IndexOf(matchedDigit) + 1;
        }
        throw new ArgumentException($"No digits found in {input}");
    }
}
