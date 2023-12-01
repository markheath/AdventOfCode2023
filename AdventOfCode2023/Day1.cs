namespace AdventOfCode2023;

// https://adventofcode.com/2023/day/1
public class Day1 : ISolver
{
    public (string, string) ExpectedResult => ("53386", "");

    public (string, string) Solve(string[] input)
    {
        var part1 = input
                        .Select(line => $"{line.First(c => char.IsDigit(c))}{line.Last(c => char.IsDigit(c))}")
                        .Select(int.Parse)
                        .Sum();
        return (part1.ToString(), "");
    }
}
