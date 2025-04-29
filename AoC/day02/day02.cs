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
        int result = 0;

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

                if (IsGameValid(gameData))
                {
                    result += gameId;
                }
            }

            Console.WriteLine($"Result: {result}");
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }

    private static bool IsGameValid(string[] draws)
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
}