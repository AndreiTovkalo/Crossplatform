using System.Text.Json;

namespace Lab4_lib;

public static class Lab1
{

    public static void Run(string inputPath, string outputPath)
    {
        
        string[] inputLines = File.ReadAllLines(inputPath);
        int N = int.Parse(inputLines[0]);
        int[] A = inputLines[1].Split().Select(int.Parse).ToArray();

        Console.WriteLine(JsonSerializer.Serialize(A));

// Вычисление минимального количества ходов
        int moves = 0;
        for (int i = 0; i < N; i++)
        {
            while (A[i] > 1)
            {
                // Перекладываем лишние шары в соседние коробки
                if (i < N - 1)
                {
                    A[i]--;
                    A[i + 1]++;
                }
                else
                {
                    A[i]--;
                    A[0]++;
                }
                moves++;
            }
        }

        File.WriteAllText(outputPath, moves.ToString());
        
        
        
        
    }
    
    
    
}