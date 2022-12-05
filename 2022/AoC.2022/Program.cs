var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/day/1", () => { 

    return Solutions.Day1Output();
});

app.MapGet("/day/2", () => { 

    return Solutions.Day2Output();
});

app.MapGet("/day/3", () => { 

    return Solutions.Day3Output();
});

app.MapGet("/day/4", () => { 

    return Solutions.Day4Output();
});

app.Run();


static class Solutions
{
    public static string Day4Output()
    {
        var dayInputFile = new StreamReader(@"inputs\day4\input.txt");

        string? line = "- -";
        var sum1 = 0;
        var sum2 = 0;

        while(line != null)
        {
            line = dayInputFile.ReadLine();
            
            if(!string.IsNullOrEmpty(line))
            {
                var ranges = line.Split(',');
                var range1 = ranges[0].Split('-');
                var range2 = ranges[1].Split('-');
                var min1 = int.Parse(range1[0]);
                var max1 = int.Parse(range1[1]);
                var min2 = int.Parse(range2[0]);
                var max2 = int.Parse(range2[1]);

                //one range is fully encapsulated in the other
                if((min1 >= min2 && max1 <= max2) || (min2 >= min1 && max2 <= max1))
                {
                    sum1++;
                    sum2++;
                }//Ranges overlap
                else if((min2 <= min1 && min1 <= max2) || (min1 <= min2 && min2 <= max1))
                {
                    sum2++;
                }
            }
        }

        return $"Part1: {sum1}, Part2: {sum2}";
    }

    public static string Day3Output()
    {
        var lookup = new Dictionary<char, int>{
            {'a', 1},{'b', 2},{'c', 3},{'d', 4},{'e', 5},{'f', 6},{'g', 7},{'h', 8},{'i', 9},{'j', 10},{'k', 11},{'l', 12},{'m', 13},
            {'n', 14},{'o', 15},{'p', 16},{'q', 17},{'r', 18},{'s', 19},{'t', 20},{'u', 21},{'v', 22},{'w', 23},{'x', 24},{'y', 25},{'z', 26},
            {'A', 27},{'B', 28},{'C', 29},{'D', 30},{'E', 31},{'F', 32},{'G', 33},{'H', 34},{'I', 35},{'J', 36},{'K', 37},{'L', 38},{'M', 39},
            {'N', 40},{'O', 41},{'P', 42},{'Q', 43},{'R', 44},{'S', 45},{'T', 46},{'U', 47},{'V', 48},{'W', 49},{'X', 50},{'Y', 51},{'Z', 52}
        };

        var dayInputFile = new StreamReader(@"inputs\day3\input.txt");

        string? line = "- -";
        int lineCounter = 0;
        int modulo = 0;
        Dictionary<int, char[]> elfGroup = new Dictionary<int, char[]>(3);
        var sum1 = 0;
        var sum2 = 0;

        while(line != null)
        {
            line = dayInputFile.ReadLine();
            lineCounter++;
            modulo = lineCounter % 3;

            if(!string.IsNullOrEmpty(line))
            {
                elfGroup[modulo] = line.ToCharArray();
                var count = line.Length / 2;
                var left = line.Substring(0, count).ToCharArray();
                var right = line.Substring(count, count).ToCharArray();

                var matched = left.Where(c => right.Contains(c)).ToArray();

                sum1 += matched.Take(1).Select(c => lookup[c]).Sum();

                if(modulo == 0)
                {
                    var badge = elfGroup[0].Where(b => elfGroup[1].Contains(b) && elfGroup[2].Contains(b)).First();
                    sum2 += lookup[badge];
                }
            }
        }

        return $"Part1: {sum1}, Part2: {sum2}";
    }

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