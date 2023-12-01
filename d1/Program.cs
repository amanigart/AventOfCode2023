Console.WriteLine($"Puzzle #1: {SolvePuzzle1()}");
Console.WriteLine($"Puzzle #2: {SolvePuzzle2()}");


static int SolvePuzzle1()
{
    var input = System.IO.File.ReadAllLines("./input.txt").ToList();
    var calibrations = new List<int>();

    input.ForEach(str =>
    {
        var numStr = new String(str.Where(Char.IsDigit).ToArray());
        if (!string.IsNullOrWhiteSpace(numStr))
        {
            calibrations.Add(
                int.Parse(numStr.Length == 1 ? $"{numStr}{numStr}" : $"{numStr[0]}{numStr[^1]}"));
        }
    });

    return calibrations.Sum();
}


static int SolvePuzzle2()
{
    int result = default;

    return result;
}
