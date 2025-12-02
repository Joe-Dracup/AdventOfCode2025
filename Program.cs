var solutions = new List<Func<string>>()
{
    Day01.Solve,
    Day02.Solve
};

foreach (var item in solutions)
{
    Console.WriteLine(item());
}