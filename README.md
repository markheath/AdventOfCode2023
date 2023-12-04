# Advent of Code 2023

This project contains solutions to the [Advent of Code](https://adventofcode.com/) puzzles for 2023 in C#. Not sure if I'll make it to the end as the puzzles typically get progressively harder, and I don't always have the time. I've based the project structure on last year's (and brought through some utils). Also updating to .NET 8.

Some notes:
- **Day 1**: Nice and easy although I didn't have time to tidy up the code.
- **Day 2**: Another easy one. I actually solved this on a livestream, and then came back to do my own implementation. I created a `ToDictionaryWithCombiner` extension method to make the code a bit cleaner.
- **Day 3** not proud of my non-elegant solution - I made a stupid mistake and didn't have time to clean up afterwards. But was handy having my Coord class to hand.
- **Day 4** A bit easier today. Part 1 was a LINQ one-liner. Part 2 I split out into an foreach loop to make it easier to write but could be refactored	into a LINQ one-liner.