using System.Text.RegularExpressions;

Console.WriteLine($"Puzzle #1: {SolvePuzzle1()}");
Console.WriteLine($"Puzzle #2: {SolvePuzzle2()}");


static int SolvePuzzle1()
{
    var input = System.IO.File.ReadAllLines("./input.txt").ToList();
    var results = new List<int>();

    input.ForEach(str =>
    {
        var numStr = new String(str.Where(Char.IsDigit).ToArray());
        if (!string.IsNullOrWhiteSpace(numStr))
        {
            results.Add(
                int.Parse(numStr.Length == 1 ? $"{numStr}{numStr}" : $"{numStr[0]}{numStr[^1]}"));
        }
    });

    return results.Sum();
}


static int SolvePuzzle2()
{
    var input = System.IO.File.ReadAllLines("./input.txt").ToList();
    var results = new List<int>();

    var mapper = new Dictionary<string, string>
    {
        {"one", "1"},   {"two", "2"},   {"three", "3"},
        {"four", "4"},  {"five", "5"},  {"six", "6"},
        {"seven", "7"}, {"eight", "8"}, {"nine", "9"}
    };

    input.ForEach(str =>
    {
        var pattern = @"\d|(?=(one|two|three|four|five|six|seven|eight|nine))";
        var regx = new Regex(pattern);
        var matches = regx.Matches(str);

        var match1 = !string.IsNullOrEmpty(matches.First().Value) ? matches.First().Value : matches.First().Groups[1].Value;
        if (!int.TryParse(match1, out _))
            match1 = mapper[match1];

        var match2 = !string.IsNullOrEmpty(matches.Last().Value) ? matches.Last().Value : matches.Last().Groups[1].Value;
        if (!int.TryParse(match2, out _))
            match2 = mapper[match2];

        results.Add(int.Parse($"{match1}{match2}"));
    });

    return results.Sum();
}