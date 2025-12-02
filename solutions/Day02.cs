public static class Day02
{
    public static string Solve()
    {
        var solution1 = GetIdRanges("Day02.txt").Sum(r => r.Sum(GetInvalidIds));

        return @$"Day 2 
        Solution 1: {solution1}
        Solution 2:  
        ";
    }

    private static IEnumerable<IEnumerable<long>> GetIdRanges(this string fileName)
    {
        return File.ReadAllLines($"./inputs/{fileName}").First().Split(',').Select(GetRange);
    }

    private static IEnumerable<long> GetRange(this string item)
    {
        var bounds = item.Split('-').Select(long.Parse);

        for (long i = bounds.First(); i <= bounds.Last(); i++)
        {
            yield return i;
        }
    }

    private static long GetInvalidIds(this long id)
    {
        var idString = id.ToString();
        
        if ((idString.Length % 2) != 0) return 0;

        var firstHalf = idString.Substring(0, idString.Length / 2);

        var secondHalf = idString.Substring(idString.Length / 2);

        if (firstHalf == secondHalf)
        {
            return id;
        }

        return 0;
    }
}