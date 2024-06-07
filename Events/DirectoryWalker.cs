public class DirectoryWalker
{
    // Событие, вызывающееся при нахождении каждого файла 
    public event EventHandler<FileArgs>? FileFound;


    public void Walk(string dir)
    {
        if (string.IsNullOrEmpty(dir))
        {
            throw new ArgumentException("The directory path cannot be null or empty.", nameof(dir));
        };

        if (!Directory.Exists(dir))
        {
            throw new DirectoryNotFoundException($"The directory '{dir}' does not exist.");
        }

        WalkDirectory(dir);
    }

    private void WalkDirectory(string dir)
    {
        try
        {
            foreach (var filePath in Directory.GetFiles(dir))
            {
                var args = new FileArgs(filePath);
                OnFileFound(args);

                if (args.Cancel)
                {
                    Console.WriteLine("Searcing canceled");
                    return;
                }

            }

            foreach (var subDir in Directory.GetDirectories(dir))
            {
                WalkDirectory(subDir);
            }

        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Access denied to directory '{dir}': {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while accessing directory '{dir}': {ex.Message}");
        }
    }

    // Метод для вызова события FileFound
    protected virtual void OnFileFound(FileArgs e)
    {
        FileFound?.Invoke(this, e);
    }
}