using System;

class Program
{
    static void Main()
    {
    string selectedPath = FolderSelector.SelectFolder();
    string newDirectory = FolderSelector.SelectFolder();

    if (!string.IsNullOrEmpty(selectedPath) && !string.IsNullOrEmpty(newDirectory))
        {
        Console.WriteLine($"\nSource Selected: {selectedPath}");
        Console.WriteLine($"Destination Selected: {newDirectory}");  

        FileSorter sorter = new FileSorter(selectedPath, newDirectory);      
        }
    else
        {
                Console.WriteLine("\nOperation cancelled: One or both folders were not selected.");
        }
    }
}
