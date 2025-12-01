var solutions = new List<Func<string>>()
{
    Day01.Solve
};

foreach (var item in solutions)
{
    Console.WriteLine(item());
}