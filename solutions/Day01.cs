public static class Day01
{
    public static string Solve()
    {
        return @$"Day 1 
        Solution 1: {Solve1()} 
        Solution 2: {Solve2()}";
    }   

    private static string Solve1()
    {
        var inputLines = IOHelper.GetLines(nameof(Day01));
        int currentNumber = 50;
        int zeroCount = 0;

        foreach (var inputLine in inputLines)
        {
            var lineStart = inputLine[0];
            var lineValue = int.Parse(inputLine[1..]);

            currentNumber = lineStart switch
            {
                 'R' => currentNumber + lineValue,
                 'L' => currentNumber - lineValue,
                 _ => throw new ApplicationException(nameof(Day01) + "Un-supported case")
            };
            
            if (currentNumber % 100 == 0)
                zeroCount++;
        }

        return zeroCount.ToString();
    }

    // Possibly should have tried to be better with the first solution - There will be a cleverer way of
    private static string Solve2()
    {
        var inputLines = IOHelper.GetLines(nameof(Day01));

        int currentNumber = 50;
        int zeroCount = 0;

        foreach (var inputLine in inputLines)
        {
            var lineStart = inputLine[0];
            var lineValue = int.Parse(inputLine[1..]);

            if(lineStart == 'R')
            {
                for (int i = 0; i < lineValue; i++)
                {
                    currentNumber++;

                    if(currentNumber == 100)
                    {
                        zeroCount++;
                        currentNumber = 0;
                    }
                }
            }

            if(lineStart == 'L')
            {
                for (int i = 0; i < lineValue; i++)
                {
                    currentNumber--;

                    if(currentNumber == 0)
                    {
                        zeroCount++;
                    }

                    if(currentNumber == -1)
                    {
                        currentNumber = 99;
                    }
                }
            }
        }
        return zeroCount.ToString();
    }
}