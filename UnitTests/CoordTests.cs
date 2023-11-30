using System.Linq;
using AdventOfCode2023;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class CoordTests
    {
        [TestCase(5, 1, 90, 1, -5)]
        [TestCase(5, 1, 180, -5, -1)]
        [TestCase(5, 1, 270, -1, 5)]
        [TestCase(5, 1, 0, 5, 1)]
        public void RotateClockwise(int x, int y, int degrees, int x2, int y2)
        {
            var coord = new Coord(x, y);
            Assert.That(new Coord(x2,y2), Is.EqualTo(coord.RotateClockwise(degrees)));
        }

        [TestCase(5, 1, 90, 1, -5)]
        [TestCase(5, 1, 180, -5, -1)]
        [TestCase(5, 1, 270, -1, 5)]
        [TestCase(5, 1, 0, 5, 1)]
        public void Rotate3DClockwiseAroundZ(int x, int y, int degrees, int x2, int y2)
        {
            var z = 4;
            var coord = new Coord3(x, y, z);
            var actual = coord.RotateClockwiseAroundZ(degrees);
            Assert.That(actual,  Is.EqualTo(new Coord3(x2, y2, z)));
        }

        [Test]
        public void GetNeighbours()
        {
            var p = new Coord(4, 5);
            var neighbours = p.Neighbours().ToHashSet();
            Assert.That(neighbours.Count, Is.EqualTo(4));
            Assert.That(neighbours.Contains(new Coord(3, 5)));
            Assert.That(neighbours.Contains(new Coord(5, 5)));
            Assert.That(neighbours.Contains(new Coord(4, 4)));
            Assert.That(neighbours.Contains(new Coord(4, 6)));
        }

        [Test]
        public void GridNeighbours()
        {
            var g = new Grid<int>(4, 5);
            var neighbours = g.Neighbours((0,1)).ToHashSet();
            Assert.That(neighbours.Count, Is.EqualTo(3));
            Assert.That(neighbours.Contains(new Coord(0, 0)));
            Assert.That(neighbours.Contains(new Coord(0, 2)));
            Assert.That(neighbours.Contains(new Coord(1, 1)));
        }

        [Test]
        public void LineTo()
        {
            var c = new Coord(3, 3);
            var line = c.LineTo((3,0)).Take(1000).ToList();
            Assert.That(line.Count, Is.EqualTo(4));
            Assert.That(line, Is.EqualTo(new Coord[] { (3, 3), (3, 2), (3, 1), (3, 0) }));
        }

        [Test]
        public void RangeCombiner()
        {
            var r = new RangeCombiner
            {
                { 3, 5 },
                { 7, 9 },
                { 4, 8 }
            };
            Assert.That(r.ToList(), Is.EqualTo(new[] { (3, 9) }));

        }
    }
}
