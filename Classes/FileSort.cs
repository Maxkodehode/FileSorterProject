using System;
using System.IO;

public class FileSorter
{
    // 1. Fields: Store the paths so all methods in this class can use them.
    private readonly string _sourcePath;
    private readonly string _destinationDirectory;

    // 2. Constructor: Only responsible for initializing the fields.
    public FileSorter(string sourcePath, string newDirectory)
    {
        // Assign the constructor arguments to the private fields.
        _sourcePath = sourcePath; 
        _destinationDirectory = newDirectory;
    }

    // 3. Method: Contains the actual operation/logic.
    public void SortFiles() 
    {
        try
        {
            // Now use the fields (_sourcePath) which were set in the constructor
            var filesToProcess = Directory.EnumerateFiles(_sourcePath); 

            foreach (string filePath in filesToProcess)
            {
                // ... The rest of your existing sorting logic goes here ...
                string extension = Path.GetExtension(filePath);
                if (string.IsNullOrEmpty(extension)) continue;

                string folderName = extension.TrimStart('.').ToUpper();
                // Use the field _destinationDirectory here
                string destinationDir = Path.Combine(_destinationDirectory, folderName);

                if (!Directory.Exists(destinationDir))
                {
                    Directory.CreateDirectory(destinationDir);
                }
                string fileName = Path.GetFileName(filePath);
                string baseFileName = Path.GetFileNameWithoutExtension(filePath);

                string destinationPath = Path.Combine(destinationDir, fileName);
                int counter = 1;

                while (File.Exists(destinationPath))
                {
                    string newFileName = $"{baseFileName}({counter}){extension}";
                    destinationPath = Path.Combine(destinationDir, newFileName);
                    counter++;
                }

                File.Move(filePath, destinationPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn unexpected error occurred: {ex.Message}");
        }
    }
}