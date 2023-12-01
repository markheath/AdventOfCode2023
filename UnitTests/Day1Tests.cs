using AdventOfCode2023;
using NUnit.Framework;

namespace UnitTests;

public class Day1Tests
{
    [Test]
    public void SolveWithTestInput()
    {
        var testInput = @"1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet".Split("\r\n");
        var solver = new Day1();
        var solution = solver.Solve(testInput);
        Assert.That(solution, Is.EqualTo(("142", "")));
    }
}