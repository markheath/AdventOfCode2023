﻿namespace AdventOfCode2023;

public interface ISolver
{
    public (string Part1, string Part2) Solve(string[] input);
    public (string Part1, string Part2) ExpectedResult { get; }
}
