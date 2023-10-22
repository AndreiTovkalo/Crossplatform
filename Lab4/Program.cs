using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string labDirectory = "../../../../Lab4ClassLib"; 
        
        if (!Directory.Exists(labDirectory))
        {
            Console.WriteLine($"Folder '{labDirectory}' not exist");
            return;
        }

        Console.WriteLine("Enter command (lab1, lab2 or lab3):");
        string command = Console.ReadLine();

        string labFile = Path.Combine(labDirectory, $"{command}.cs");

        if (File.Exists(labFile))
        {
            Process process = new Process();
            process.StartInfo.FileName = "csc";
            process.StartInfo.Arguments = $"{labFile} /out:LabX.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
            process.WaitForExit();

            process.StartInfo.FileName = "LabX.exe";
            process.StartInfo.Arguments = "";
            process.Start();

            process.WaitForExit();
        }
        else
        {
            Console.WriteLine($"File '{labFile}' not found.");
        }
    }
}