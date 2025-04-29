namespace AoC.Day02;
using System;
using System.IO;

public class Day02
{
    private const int MaxRed = 12;
    private const int MaxGreen = 13;
    private const int MaxBlue = 13;

    public static void Run()
    {
        int resultPart1 = 0;
        int resultPart2 = 0;

        try
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, @"..\..\..\day02\input.txt");
            using var reader = new StreamReader(filePath);

            while (!reader.EndOfStream)
            {
                string? line = reader.ReadLine();
                if (line == null) continue;

                var parts = line.Split(':');
                int gameId = int.Parse(parts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                string[] gameData = parts[1].Replace(';', ',').Split(',');

                
                if (Part1(gameData))
                {
                    resultPart1 += gameId;
                }
                
                resultPart2 += Part2(gameData);
                
            }

            Console.WriteLine($"Result Part 1: {resultPart1}");
            Console.WriteLine($"Result Part 2: {resultPart2}");
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }

    private static bool Part1(string[] draws)
    {
        foreach (var draw in draws)
        {
            var trimmed = draw.Trim();
            var parts = trimmed.Split(' ');
            int count = int.Parse(parts[0]);
            string color = parts[1];

            switch (color)
            {
                case "red" when count > MaxRed:
                case "green" when count > MaxGreen:
                case "blue" when count > MaxBlue:
                    return false;
            }
        }
        return true;
    }
    
    private static int Part2(string[] draws)
    {
        var highestRed = 0;
        var highestGreen = 0;
        var highestBlue = 0;
        foreach (var draw in draws)
        {
            var trimmed = draw.Trim();
            var parts = trimmed.Split(' ');
            int count = int.Parse(parts[0]);
            string color = parts[1];

            switch (color)
            {
                case "red" when count > highestRed:
                    highestRed = count;
                    break;
                case "green" when count > highestGreen:
                    highestGreen = count;
                    break;
                case "blue" when count > highestBlue:
                    highestBlue = count;
                    break;
            }
        }
        
        return highestRed * highestGreen * highestBlue;
    }
}