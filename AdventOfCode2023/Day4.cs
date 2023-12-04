
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2023;

public class Day4 : ISolver
{
    public (string, string) ExpectedResult => ("20855", "5489600");

    class Card
    {
        public int CardNumber { get; set; }
        public int[] WinningNumbers { get; set; }
        public int[] MyNumbers { get; set; }
        public int Count { get; set; }
    }

    public (string, string) Solve(string[] input)
    {
        var part1 = input.Select(card => card.Split(':', '|').Select(n => Regex.Matches(n, @"\d+").Select(m => int.Parse(m.Value)).ToArray()).ToArray())
            .Select(c => new Card { CardNumber = c[0][0], WinningNumbers = c[1], MyNumbers = c[2] })
            .Select(c => c.WinningNumbers.Count(wn => c.MyNumbers.Contains(wn)))
            .Sum(x => x == 0 ? 0 : (1 << (x - 1)));

        var cards = input.Select(card => card.Split(':', '|').Select(n => Regex.Matches(n, @"\d+").Select(m => int.Parse(m.Value)).ToArray()).ToArray())
            .Select(c => new Card { CardNumber = c[0][0], WinningNumbers = c[1], MyNumbers = c[2], Count = 1 })
            .ToArray();
        for (var n = 0; n < cards.Length; n++)
        {
            var c = cards[n];
            var matches = c.WinningNumbers.Count(wn => c.MyNumbers.Contains(wn));
            for(var i = 0; i < matches; i++)
            {
                cards[n+1+i].Count += c.Count;
            }
        }
        var part2 = cards.Sum(c => c.Count);

        return (part1.ToString(), part2.ToString());
    }
}
