using System;
using System.Runtime.InteropServices;

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
        Console.WriteLine($"Starting from the '{selectedPath}' to destination folder in '{newDirectory}'...");
        sorter.SortFiles();
             
        }
    else
        {
            Console.WriteLine("\n\nIf directory selection fails or is canceled, please ensure you have Zenity installed.\n\n" +
        "Use the appropriate command for your Linux distribution:\n" +
        "----------------------------------------------------\n" +
        "1. Debian/Ubuntu/Mint (APT):\n" +
        "   sudo apt update\n" +
        "   sudo apt install zenity\n\n" +
        "2. Fedora/RHEL/CentOS (DNF):\n" +
        "   sudo dnf install zenity\n\n" +
        "3. Arch Linux (Pacman):\n" +
        "   sudo pacman -S zenity\n\n" +
        "4. openSUSE (Zypper):\n" +
        "   sudo zypper install zenity\n" +
        "----------------------------------------------------");
        }
    }
}
