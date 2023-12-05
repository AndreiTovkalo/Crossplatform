using Lab4_lib;
using McMaster.Extensions.CommandLineUtils;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Enter command (version, run lab1/lab2/lab3, set-path -p/--path <path>):");
            string userInput = Console.ReadLine();
            string[] inputTokens = userInput.Split(' ');

            if (inputTokens.Length == 0)
            {
                Console.WriteLine("Unknown command. Try again.");
                continue;
            }

            string command = inputTokens[0].ToLower();

            if (command == "version")
            {
                Console.WriteLine("Author: Andrii Tovkalo");
                Console.WriteLine("Version: 1.0.0");
            }
            else if (command == "run" && inputTokens.Length > 1)
            {
                string subCommand = inputTokens[1].ToLower();
                string inputFilePath = null;
                string outputFilePath = null;

                for (int i = 2; i < inputTokens.Length; i++)
                {
                    if (inputTokens[i] == "-I" || inputTokens[i] == "--input")
                    {
                        if (i + 1 < inputTokens.Length)
                        {
                            inputFilePath = inputTokens[i + 1];
                            i++;
                        }
                    }
                    else if (inputTokens[i] == "-o" || inputTokens[i] == "--output")
                    {
                        if (i + 1 < inputTokens.Length)
                        {
                            outputFilePath = inputTokens[i + 1];
                            i++;
                        }
                    }
                }

                if (subCommand == "lab1" || subCommand == "lab2" || subCommand == "lab3")
                {
                    Console.WriteLine($"Executing command 'run {subCommand}' with input file '{inputFilePath}' and output file '{outputFilePath}'");

                    if (!string.IsNullOrEmpty(inputFilePath) && !string.IsNullOrEmpty(outputFilePath))
                    {
                        switch (subCommand)
                        {
                            case "lab1":
                                Lab1.Run(inputFilePath, outputFilePath);
                                break;
                            case "lab2":
                                Lab2.Run(inputFilePath, outputFilePath);
                                break;
                            case "lab3":
                                Lab3.Run(inputFilePath, outputFilePath);
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Unknown command for 'run'. Try again...");
                }
            }
            else if (command == "set-path" && inputTokens.Length > 2)
            {
                if ((inputTokens[1] == "-p" || inputTokens[1] == "--path") && !string.IsNullOrEmpty(inputTokens[2]))
                {
                    string labPath = inputTokens[2];
                    Environment.SetEnvironmentVariable("LAB_PATH", labPath);
                    Console.WriteLine($"Path to the folder with input and output files set to '{labPath}'");
                }
                else
                {
                    Console.WriteLine("Invalid 'set-path' command. Enter the command again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid command. Enter the command again.");
            }
        }
    }
}
