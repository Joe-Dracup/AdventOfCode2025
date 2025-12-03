
public static class Day02
{
    public static string Solve()
    {
        var solution1 = GetIdRanges("Day02.txt").Sum(r => r.Sum(GetInvalidIds));
        var solution2 = GetIdRanges("Day02.txt").Sum(r => r.Sum(GetInvalidIds2));
        return @$"Day 2 
        Solution 1: {solution1}
        Solution 2: {solution2}
        ";
    }

    private static long GetInvalidIds2(this long id)
    {
        var s = id.ToString();

        for (var i = 1; i < s.Length + 1; i++)
        {
            var sub = s.Substring(0, i);
            if (sub == s)
                return 0;

            var count = s.AllIndexesOf(sub).Count();

            if (count * sub.Length == s.Length)
            {
                return id;
            }
        }

        return 0;
    }

    private static List<int> AllIndexesOf(this string str, string value)
    {
        if (String.IsNullOrEmpty(value))
            throw new ArgumentException("the string to find may not be empty", "value");
        List<int> indexes = new List<int>();
        for (int index = 0; ; index += value.Length)
        {
            index = str.IndexOf(value, index);
            if (index == -1)
                return indexes;
            indexes.Add(index);
        }
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