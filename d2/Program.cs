Console.WriteLine($"Puzzle #1: {SolvePuzzle1()}");
//Console.WriteLine($"Puzzle #2: {SolvePuzzle2()}");

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

        var isValid = !str
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
    var results = new List<int>();

    return results.First();
}