using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
      
        string selectedPath = SelectFolder();
        
        if (!string.IsNullOrEmpty(selectedPath))
        {
            Console.WriteLine($"Selected directory: {selectedPath}");
            
        }
        else
        {
            Console.WriteLine("No directory selected.");
        }
    }
    
    static string SelectFolder()
    {
         if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return SelectFolderLinux();
        }
        else
        {
            throw new PlatformNotSupportedException("This OS is not supported.");
        }
    }
    

    
    static string SelectFolderLinux()
    {
        var psi = new ProcessStartInfo
        {
            FileName = "zenity",
            Arguments = "--file-selection --directory --title=\"Select a directory\"",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        
        try
        {
            using (var process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd().Trim();
                process.WaitForExit();
                return output;
            }
        }
        catch
        {
            Console.WriteLine("Error: zenity not found. Install it with: sudo apt install zenity");
            return string.Empty;
        }
    }
}