var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/day/1", () => { 

    return Solutions.Day1Output();
});

app.Run();


static class Solutions
{
    public static string Day1Output()
    {
        var day1InputFile = new StreamReader(@"inputs\day1\input.txt");

        string? line = "";
        var elfCalories = new List<int>();
        int sum = 0;

        while(line != null)
        {
            line = day1InputFile.ReadLine();

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