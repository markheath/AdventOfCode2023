
namespace AdventOfCode2023;

public class Day3 : ISolver
{
    public (string, string) ExpectedResult => ("536576", "");

    public (string, string) Solve(string[] input)
    {
        var grid = Grid<char>.ParseToGrid(input, c=>c);
        var part1 = 0L;
        for(var y = 0; y < grid.Height; y++)
        {
            var currentNumber = "";
            var currentNumberStartPos = 0;
            var isPartNumber = false;
            for (var x = 0; x < grid.Width; x++)
            {
                Coord coord = (x, y);
                var c = grid[coord];
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
                        Console.WriteLine($"Part {currentNumber}");
                        part1 += long.Parse(currentNumber);
                    }
                    isPartNumber = false;
                    currentNumber = "";
                }
            }
            if (currentNumber != null && isPartNumber)
            {
                Console.WriteLine($"Part at end of line {currentNumber}");
                part1 += long.Parse(currentNumber);
                currentNumber = "";
                isPartNumber = false;
            }

        }
        return (part1.ToString(), "");
    }
}
