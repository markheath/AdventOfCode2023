using AdventOfCode2023;
using NUnit.Framework;
using System;

namespace UnitTests;

public class Day3Tests
{
    [Test]
    public void SolveWithTestInput()
    {
        var testInput = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..".Split(Environment.NewLine);
        var solver = new Day3();
        var solution = solver.Solve(testInput);
        Assert.That(solution, Is.EqualTo(("4361", "")));
    }
}

