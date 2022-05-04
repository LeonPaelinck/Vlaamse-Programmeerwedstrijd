using System.Text;

int numberOfCases = Int32.Parse(Console.ReadLine());
int[] results = new int[numberOfCases];
for (int index = 0; index != numberOfCases; index++)
{
    string rowColumnInput = Console.ReadLine();
    string[] input = rowColumnInput.Split(' ');
    int columns = Int32.Parse(input[0]);
    int rows = Int32.Parse(input[1]);

    char[][] matrix = new char[rows][];
    for (int index2 = rows - 1; index2 != -1; index2--)
    {
        string rowInput = Console.ReadLine();
        matrix[index2] = rowInput.ToCharArray();
    }

    int total = 0;
    int peek = -1;
    for (int column = 0; column != columns; column++)
    {
        for (int row = 0; row != rows; row++)
        {
            if (matrix[row][column].Equals('.'))
            {
                int tempPeek = row - 1;
                if (tempPeek < peek) //AKA er is afvlakking nodig
                {
                    total += (peek - tempPeek);
                }
                else //AKA piek verhoogt
                {
                    peek = tempPeek; //piek verhoogt
                }
                row = rows - 1; //break
            }
            else if (row == rows - 1) //piek is allerhoogste: geen afvlakking nodig
            {
                peek = row; //hoogste positie
            }
        }
    }
    results[index] = total;
}
for (int index = 0; index != numberOfCases; index++)
{
    Console.WriteLine("{0} {1}", index + 1, results[index]);
}
