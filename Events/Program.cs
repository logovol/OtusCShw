
DirectoryWalker dirWalker = new DirectoryWalker();

// Подписка на событие
dirWalker.FileFound += (sender, e) =>
{
    Console.WriteLine($"File found {e.FileName}");

if (e.FileName.EndsWith(".txt"))
{
    Console.WriteLine("Searching canceled. txt file was founded");
    e.Cancel = true;
}
};

string dirPath = @"C:\Users\logov\Desktop\doc";
dirWalker.Walk(dirPath);

#region FileArgs
public class FileArgs : EventArgs
{
    public string FileName { get; }

    public bool Cancel { get; set; }

    public FileArgs(string fileName)
    {
        FileName = fileName;
        Cancel = false;
    }
}
#endregion