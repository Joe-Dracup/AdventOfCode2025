public class Day1 : IAdventSolution
{
    private readonly IEnumerable<string> inputLines; 
    public Day1()
    {
        inputLines = IOHelper.GetLines(nameof(Day1));
    }
    
    public string Solve1()
    {
        int currentNumber = 50;
        int zeroCount = 0;

        foreach (var inputLine in inputLines)
        {
            var lineStart = inputLine[0];
            var lineValue = int.Parse(inputLine.Substring(1));

            currentNumber = lineStart switch
            {
                 'R' => currentNumber + lineValue,
                 'L' => currentNumber - lineValue
            };
            
            if (currentNumber % 100 == 0)
                zeroCount++;
        }

        return zeroCount.ToString();
    }

    // Possibly should have tried to be better with the first solution - There will be a cleverer way of doing this one.
    public string Solve2()
    {
        int currentNumber = 50;
        int zeroCount = 0;

        foreach (var inputLine in inputLines)
        {
            var lineStart = inputLine[0];
            var lineValue = int.Parse(inputLine.Substring(1));

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