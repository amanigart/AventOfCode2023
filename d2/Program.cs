Console.WriteLine($"Puzzle #1: {SolvePuzzle1()}");
Console.WriteLine($"Puzzle #2: {SolvePuzzle2()}");

static int SolvePuzzle1()
{
    var input = System.IO.File.ReadAllLines("./input.txt").ToList();
    var ids = new List<int>();
    var bag = new Dictionary<string, int>()
    {
        {"red", 12 }, {"green", 13}, {"blue", 14}
    };

    input.ForEach(str =>
    {
        int commaIndex = str.IndexOf(":");
        int id = int.Parse(str[5..commaIndex]);

        bool isValid = !str
            .Substring(commaIndex + 1)
            .Split(";")
            .Select(set => set.Split(","))
            .Any(set =>
            {
                foreach (var subset in set)
                {
                    var trimmedSubset = subset.Trim();
                    int spaceIndex = trimmedSubset.IndexOf(" ");
                    int digit = int.Parse(trimmedSubset[..spaceIndex]);
                    var color = trimmedSubset[(spaceIndex + 1)..];

                    if (bag[color] < digit)
                        return true;
                }
                return false;
            });

        if (isValid)
            ids.Add(id);
    });

    return ids.Sum();
}


static int SolvePuzzle2()
{
    var input = System.IO.File.ReadAllLines("./input.txt").ToList();
    var powers = new List<int>();

    input.ForEach(str =>
    {
        int commaIndex = str.IndexOf(":");

        var pairs = str
            .Substring(commaIndex + 1)
            .Split(new char[] { ',', ';' })
            .Select(sub =>
            {
                var pair = string.Concat(sub.Where(c => !char.IsWhiteSpace(c)));
                int digit = int.Parse(new String(pair.Where(char.IsDigit).ToArray()));
                var color = new String(pair.Where(char.IsLetter).ToArray());

                return new Tuple<string, int>(color, digit);
            })
            .ToList();

        var red = pairs.Where(p => p.Item1 == "red").Max(p => p.Item2);
        var blue = pairs.Where(p => p.Item1 == "blue").Max(p => p.Item2);
        var green = pairs.Where(p => p.Item1 == "green").Max(p => p.Item2);

        powers.Add(red * blue * green);
    });

    return powers.Sum();
}