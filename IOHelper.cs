public static class IOHelper
{
    public static IEnumerable<string> GetLines(string DayPath)
    {
        string filePath = $"./inputs/{DayPath}.txt";
        if(!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist :{0} ", filePath);
            return Enumerable.Empty<string>();
        }

        return File.ReadAllLines(filePath);
    }
}