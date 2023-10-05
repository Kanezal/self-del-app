using System.Diagnostics;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            CreateTempProcess();
        }

        foreach (string arg in args)
        {
            if (arg.Contains("istmp"))
            {
                MainTmpProcess(arg);
            }
        }

        Console.ReadKey();
    }

    static void CreateTempProcess()
    {
        string currentPath = Process.GetCurrentProcess().MainModule.FileName;
        string tempDirectory = Path.GetTempPath();
        string tempFilePath = Path.Combine(tempDirectory, "selfdel.exe");
        File.Copy(currentPath, tempFilePath, true);
        
        string arguments = $"istmp={currentPath}";
        
        ProcessStartInfo tmpProcessInfo = new ProcessStartInfo
        {
            FileName = tempFilePath,
            Arguments = arguments
        };

        Process.Start(tmpProcessInfo);
        Environment.Exit(0);
    }

    static void MainTmpProcess(string arg)
    {
        string mainProgramPath = arg.Split("=")[1];

        Console.WriteLine("Я БУДУ ЖИТЬ ВЕЧНО В ТВОЕЙ ПАМЯТИ УХАХАХХАХАХАХАХАХ");

        File.Delete(mainProgramPath);
    }
}