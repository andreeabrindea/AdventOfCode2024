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
for (int i = 0; i < leftList.Count; i++)
{
    sum += int.Abs(leftList[i] - rightList[i]);
}


Console.WriteLine(sum);