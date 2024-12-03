void Day1()
{
    var input = File.ReadLines("/Users/andreea/Projects/AdventOfCode/AdventOfCode/input.txt");
    List<int> leftList = new List<int>();
    List<int> rightList = new List<int>();
    foreach (var row in input)
    {
        var elem = row.Split("   ");
        leftList.Add(Convert.ToInt32(elem[0]));
        rightList.Add(Convert.ToInt32(elem[1]));
    }

    rightList.Sort();
    leftList.Sort();
    int sum = 0;
    int similarityScore = 0;
    for (int i = 0; i < leftList.Count; i++)
    {
        sum += int.Abs(leftList[i] - rightList[i]);
        similarityScore += leftList[i] * rightList.Count(x => x == leftList[i]);
    }


    Console.WriteLine(sum);
    Console.WriteLine(similarityScore);
}

void Day2()
{
    StreamReader sr = new StreamReader("/Users/andreea/Projects/AdventOfCode/AdventOfCode/input2.txt");
    string line = sr.ReadLine();
    int noOfSafeReports = 0;
    while(line != null)
    {
        var elements = line.Split(" ").Select(x => int.Parse(x)).ToList();
        if (IsMonotone(elements) && !IsNoOfDifferencesBiggerThan3(elements))
        {
            noOfSafeReports++;
        }
        line = sr.ReadLine();
    }
    
    sr.Close();
    Console.WriteLine(noOfSafeReports);
}

bool IsMonotone(List<int> intElements)
{
    bool isAscending = intElements[0] < intElements[1];
    for (int i = 2; i < intElements.Count; i++)
    {
        if (intElements[i - 1] > intElements[i] && isAscending ||
            intElements[i - 1] < intElements[i] && !isAscending)
        {
            return false;
        }
    }

    return true;
}

bool IsNoOfDifferencesBiggerThan3(List<int> intElements)
{
    for (int i = 1; i < intElements.Count; i++)
    {
        int difference = Math.Abs(intElements[i - 1] - intElements[i]);
        if ( difference > 3 || difference == 0 )
        {
            return true;
        }
    }

    return false;

}

Day2();