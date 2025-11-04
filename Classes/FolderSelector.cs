using System;
using System.Diagnostics;

public static class FolderSelector
{
    public static string SelectFolder()
{
        var psi = new ProcessStartInfo
        {
            FileName = "zenity",
            Arguments = "--file-selection --directory --title=\"Select a directory\"",
            RedirectStandardOutput = true,
            UseShellExecute = false,
        };
        
        using (var process = Process.Start(psi)!)
        {
            string selectedPath = process.StandardOutput.ReadToEnd().Trim();  
          process.WaitForExit();
            return selectedPath;
        }
    }
}
