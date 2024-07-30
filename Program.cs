using System;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace QuickScriptLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the directory path for the "Local Scripts" sub-directory
            string scriptsDir = "[Script directory]";

            // Check if the directory exists
            if (!Directory.Exists(scriptsDir))
            {
                Console.WriteLine("Error: 'Local Scripts' directory not found.");
                return;
            }

            // Get the list of script files in the directory
            string[] scriptFiles = Directory.GetFiles(scriptsDir, "*.py");

            // Display the script files with IDs
            Console.WriteLine("Available Scripts:");
            for (int i = 0; i < scriptFiles.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Path.GetFileName(scriptFiles[i])}");
            }

            // Prompt the user to enter a number
            Console.Write("Enter the number of the script to run: ");
            int selectedId = int.Parse(Console.ReadLine());

            // Validate the input
            if (selectedId < 1 || selectedId > scriptFiles.Length)
            {
                Console.WriteLine("Invalid input. Please try again.");
                return;
            }

            // Get the selected script file path
            string selectedScript = scriptFiles[selectedId - 1];

            // Trim the directory info from the selected script path
            string scriptName = Path.GetFileName(selectedScript);

            // Execute the selected script using Python
            Console.WriteLine($"Executing Script: {scriptName}");
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = scriptName,
                WorkingDirectory = scriptsDir,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            Process process = new Process();
            process.StartInfo.RedirectStandardOutput = true;
            process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (!String.IsNullOrEmpty(e.Data))
                {
                    Console.WriteLine(e.Data);
                }
            });
            process.StartInfo = startInfo;

            process.Start();
            process.BeginOutputReadLine();

            
            //// Read the output from the Python script
            //string output = process.StandardOutput.ReadToEnd();

            // Wait for the script to finish executing
            process.WaitForExit();
            process.Close();
            // Display the output from the Python script
            //Console.WriteLine("Script Output:");
            //Console.WriteLine(output);

            Console.WriteLine("Script execution complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}