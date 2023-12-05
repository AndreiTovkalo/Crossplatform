namespace Lab4_lib;

public class Lab2
{
    public static void Run(string inputPath, string outputPath)
    {
        string[] inputLines = File.ReadAllLines(inputPath);
        int n = int.Parse(inputLines[0]);
        int[] diagonalNumbers = inputLines[1].Split().Select(int.Parse).ToArray();
        int[][] a = new int[n][];
        

        int i, j, b, t;

        for (i = 0; i < n; i++)
        {
            a[i] = new int[n];
            for (j = 0; j < n; j++)
                a[i][j] = 0;
        }

        for (i = 0; i < n; i++)
        {
            b = diagonalNumbers[i];
            a[i][i] = b;
        }

        if (n % 2 == 1)
        {
            for (i = 1; i < n; i++)
            {
                if (i % 2 == 1)
                {
                    for ( j = i, t = 0; j < n; j++, t++)
                    {
                        a[j][t] = Math.Min(a[j - 1][t], a[j][t + 1]);
                    }
                }
                else
                {
                    for (j = i, t = 0; j < n; j++, t++)
                    {
                        a[j][t] = Math.Max(a[j - 1][t], a[j][t + 1]);
                    }
                }
            }
        }
        else
        {
            for ( i = 1; i < n; i++)
            {
                if (i % 2 == 1)
                {
                    for (j = i, t = 0; j < n; j++, t++)
                    {
                        a[j][t] = Math.Max(a[j - 1][t], a[j][t + 1]);
                    }
                }
                else
                {
                    for (j = i, t = 0; j < n; j++, t++)
                    {
                        a[j][t] = Math.Min(a[j - 1][t], a[j][t + 1]);
                    }
                }
            }
        }

        i = n - 1;
        j = 0;
        b = 0;

        while (i != j)
        {
            if (b % 2 == 0)
            {
                if (a[i - 1][j] > a[i][j + 1])
                    i--;
                else
                    j++;
            }
            else
            {
                if (a[i - 1][j] > a[i][j + 1])
                    j++;
                else
                    i--;
            }
            b++;
        }

        File.WriteAllText(outputPath, a[i][j].ToString());
    }
}