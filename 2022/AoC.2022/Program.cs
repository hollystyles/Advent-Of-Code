var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/day/1", () => { 

    return Solutions.Day1Output().ToString();
});

app.Run();


static class Solutions
{
    public static int Day1Output()
    {
        var day1InputFile = new StreamReader(@"C:\Users\PaulAlcon\source\repos\AdventofCode\2022\AoC.2022\inputs\day1\input.txt");

        string? line = "";
        int max = 0;
        int sum = 0;

        while(line != null)
        {
            line = day1InputFile.ReadLine();
            
            if(string.IsNullOrEmpty(line))
            {
                max = Math.Max(max, sum);
                sum = 0;
            }
            else
            {
                sum += int.Parse(line);
            }
            
        }

        return max;
    }
}