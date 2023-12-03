
using System.Linq;

namespace AdventOfCode2023;

public class Day3 : ISolver
{
    public (string, string) ExpectedResult => ("536576", "75741499");

    public (string, string) Solve(string[] input)
    {
        var grid = Grid<char>.ParseToGrid(input, c => c);
        var part1 = 0L;
        var part2 = 0L;
        var numbers = new List<(int x, int y, string number)>();
        var gears = new List<Coord>();

        for (var y = 0; y < grid.Height; y++)
        {
            var currentNumber = "";
            var currentNumberStartPos = 0;
            var isPartNumber = false;
            for (var x = 0; x < grid.Width; x++)
            {
                Coord coord = (x, y);
                var c = grid[coord];
                if (c == '*')
                {
                    gears.Add(coord);
                }
                if (char.IsDigit(c))
                {
                    if (currentNumber == "")
                    {
                        currentNumberStartPos = x;
                    }
                    currentNumber += c;
                    if (!isPartNumber)
                    {
                        isPartNumber = coord.Neighbours(true).Any(n => grid.IsInGrid(n) && !char.IsDigit(grid[n]) && grid[n] != '.');
                    }
                }
                else if (currentNumber != "")
                {
                    // end of number
                    if (isPartNumber)
                    {
                        //Console.WriteLine($"Part {currentNumber}");
                        part1 += long.Parse(currentNumber);
                    }
                    numbers.Add((x - currentNumber.Length, y, currentNumber));
                    isPartNumber = false;
                    currentNumber = "";
                }
            }
            if (currentNumber != null && isPartNumber)
            {
                Console.WriteLine($"Part at end of line {currentNumber}");
                part1 += long.Parse(currentNumber);
                numbers.Add((grid.Width - currentNumber.Length, y, currentNumber));
                currentNumber = "";
                isPartNumber = false;
            }

        }

        foreach(var gear in gears)
        {
            var adjacentNumbers = new List<int>();
            foreach (var n in numbers)
            {
                var lowX = n.x - 1; var highX = n.x + n.number.Length;
                if (gear.X >= lowX && gear.X <= highX && Math.Abs(n.y - gear.Y) <= 1)
                {
                    adjacentNumbers.Add(int.Parse(n.number));
                }
            }
            if (adjacentNumbers.Count > 2)
            {
                throw new InvalidOperationException($"multiple neighbours for gear {gear}");
            }
            if (adjacentNumbers.Count == 2)
            {
                if (gear.Y >= grid.Height - 10)
                    Console.WriteLine($"Gear {gear} has neighbours {adjacentNumbers[0]} and {adjacentNumbers[1]}");
                part2 += adjacentNumbers[0] * adjacentNumbers[1];
            }
            else
            {
                if (gear.Y >= grid.Height - 10)
                    Console.WriteLine($"Gear {gear} has neighbours {String.Join(',', adjacentNumbers)}");
            }
        }

        return (part1.ToString(), part2.ToString());
    }



}
