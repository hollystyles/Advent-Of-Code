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

app.MapGet("/day/5", () => { 

    return Solutions.Day5Output();
});

app.MapGet("/day/6", () => { 

    return Solutions.Day6Output();
});

app.Run();


static class Solutions
{
    public static string Day6Output()
    {
        var dayInputFile = new StreamReader(@"inputs\day6\input.txt");

        string line = "- -";
        var pos = 0;
        var p_sequence = new Queue<char>(4);
        var m_sequence = new Queue<char>(14);
        var p_marker = 0;
        var m_marker = 0;

        while(line != null)
        {
            line = dayInputFile.ReadLine();

            if(!string.IsNullOrEmpty(line))
            {
                foreach(var c in line)
                {
                    pos++;
                    p_sequence.Enqueue(c);
                    m_sequence.Enqueue(c);

                    if(pos >= 4)
                    {
                        if(p_marker == 0 && p_sequence.Distinct().Count() == 4)
                        {
                            p_marker = pos;
                        }
                            
                        _ = p_sequence.Dequeue();
                    }

                    if(pos >= 14)
                    {
                        if(m_marker == 0 && m_sequence.Distinct().Count() == 14)
                        {
                            m_marker = pos;
                        }

                        _ = m_sequence.Dequeue();
                    }

                    if(p_marker > 0 && m_marker > 0)
                    {
                        break;
                    }
                }
            }
        }

        return $"Part1: {p_marker}, Part2: {m_marker}";
    }

    public static string Day5Output()
    {
        var stacks1 = new Dictionary<int, Stack<char>>(9);
        var stacks2 = new Dictionary<int, Stack<char>>(9);
        for(var i = 0; i < 9; i++)
        {
            stacks1.Add(i, new Stack<char>());
            stacks2.Add(i, new Stack<char>());
        }

        var dayInputFile = new StreamReader(@"inputs\day5\input.txt");

        string? line = "- -";

        while(line != null)
        {
            line = dayInputFile.ReadLine();
            
            if(!string.IsNullOrEmpty(line))
            {
                if(line.IndexOf("[") > -1)
                {
                    for(int i=0, j=0; i <  36; i+=4, j++)
                    {
                        var crate = line.Substring(i, 3).Replace("[", "").Replace("]", "").Trim();
                        if(!string.IsNullOrEmpty(crate))
                        {
                            stacks1[j].Push(crate[0]);
                            stacks2[j].Push(crate[0]);
                        }

                    }
                }
                else if(line.StartsWith(" 1"))
                {
                    for(int i = 0; i < 9; i++)
                    {
                        var revStack1 = new Stack<char>();
                        var revStack2 = new Stack<char>();
                        while(stacks1[i].Count > 0)
                        {
                            revStack1.Push(stacks1[i].Pop());
                            revStack2.Push(stacks2[i].Pop());
                        }
                        stacks1[i] = revStack1;
                        stacks2[i] = revStack2;
                    }
                }
                else if(line.StartsWith("move"))
                {
                    var moves = line.Split(' ');
                    var count = int.Parse(moves[1]);
                    var from = int.Parse(moves[3]) - 1;
                    var to = int.Parse(moves[5]) - 1;
                    var revStack = new Stack<char>();

                    for(int i = 0; i < count; i++)
                    {
                        stacks1[to].Push(stacks1[from].Pop());
                        revStack.Push(stacks2[from].Pop());
                    }
                    while(revStack.Count > 0)
                    {
                        stacks2[to].Push(revStack.Pop());
                    }
                }
            }
        }
        
        var result1 = "";
        for(int i = 0; i < 9; i++)
        {
            result1 += stacks1[i].Peek();
        }

        var result2 = "";
        for(int i = 0; i < 9; i++)
        {
            result2 += stacks2[i].Peek();
        }

        return $"Partt1: {result1}, Part2: {result2}";
    }

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