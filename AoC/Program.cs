using AoC.Day02;
using AoC.Day03;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Which day do you want to run?");
        string? input = Console.ReadLine();

        switch (input)
        {
            case "2":
                Day02.Run();
                break;
            case "3":
                Day03.Run();
                break;
            default:
                break;
        }
    }
}
