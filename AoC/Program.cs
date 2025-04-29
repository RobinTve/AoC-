using AoC.Day02;
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
            
            default:
                break;
        }
    }
}
