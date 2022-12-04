var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/day/1", () => { 

    return Solutions.Day1Output();
});

app.MapGet("/day/2", () => { 

    return Solutions.Day2Output();
});

app.Run();


static class Solutions
{
    public static string Day2Output()
    {
        var lookup1 = new Dictionary<string, int>{
            //Rock Rock
            {"A X", 4},
            //Rock Paper
            {"A Y", 8},
            //Rock Scissors
            {"A Z", 3},
            //Paper Rock
            {"B X", 1},
            //Paper Paper
            {"B Y", 5},
            //Paper Scissors
            {"B Z", 9},
            //Scissors Rock
            {"C X", 7},
            //Scissors Paper
            {"C Y", 2},
            //Scissors Scissors
            {"C Z", 6},
        };
        
        var lookup2 = new Dictionary<string, int>{
            //Rock Scissors
            {"A X", 3},
            //Rock Rock
            {"A Y", 4},
            //Rock Paper
            {"A Z", 8},
            //Paper Rock
            {"B X", 1},
            //Paper Paper
            {"B Y", 5},
            //Paper Scissors
            {"B Z", 9},
            //Scissors Paper
            {"C X", 2},
            //Scissors Scissors
            {"C Y", 6},
            //Scissors Rock
            {"C Z", 7},
        };

        var dayInputFile = new StreamReader(@"inputs\day2\input.txt");

        string? line = "- -";
        var sum1 = 0;
        var sum2 = 0;

        while(line != null)
        {
            line = dayInputFile.ReadLine();

            if(!string.IsNullOrEmpty(line))
            {
                sum1 += lookup1[line];
                sum2 += lookup2[line];
            }
        }

        return $"Part1: {sum1.ToString()}, Part2: {sum2.ToString()}";
    }

    public static string Day1Output()
    {
        var dayInputFile = new StreamReader(@"inputs\day1\input.txt");

        string? line = "";
        var elfCalories = new List<int>();
        int sum = 0;

        while(line != null)
        {
            line = dayInputFile.ReadLine();

            if(string.IsNullOrEmpty(line))
            {
                elfCalories.Add(sum);
                sum = 0;
            }
            else
            {
                sum += int.Parse(line);
            }            
        }

        var part1 = elfCalories.Max();
        var part2 = elfCalories.OrderByDescending(c => c).Take(3).Sum();

        return $"Part1: {part1}; Part2: {part2}";
    }
}