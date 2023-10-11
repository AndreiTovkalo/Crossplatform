using System.Text.Json;

string[] inputLines = File.ReadAllLines("INPUT.txt");
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

// Запись результата в файл OUTPUT.TXT
File.WriteAllText("OUTPUT.TXT", moves.ToString());