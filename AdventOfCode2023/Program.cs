﻿using System.Diagnostics;
using AdventOfCode2023;

// they're sorted in reverse
var (solver,input) = Utils.FindAllSolvers().First(x => x.Input.Length > 0); 
Console.WriteLine($"Solving for day {solver.GetType().Name[3..]}");
var sw = Stopwatch.StartNew();
var (a,b) = solver.Solve(input);
sw.Stop();
Console.WriteLine($"ResultA: {a}");
Console.WriteLine($"ResultB: {b}");

if (solver.ExpectedResult != (a,b))
{
    Console.WriteLine($"Error after {sw.ElapsedMilliseconds}ms! Expected: {solver.ExpectedResult}");
}
else
{
    Console.WriteLine($"Success! {sw.ElapsedMilliseconds}ms");
}
