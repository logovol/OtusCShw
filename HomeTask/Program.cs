using System.Diagnostics;

Stopwatch sw = Stopwatch.StartNew();
// Путь к директории
string path = @"C:\Users\logov\Desktop\testtext";
// Файлы в директории
string[] files = Directory.GetFiles(path);

// Создается массив задач, каждая из которых читает файл и считает пробелы в нем.
// Метод Select используется для создания задач с помощью лямбда-функции.
Task<int>[] tasks = files.Select(files => CountSpacesinFileAsync(files)).ToArray();
// Ожидание завершения всех задач с использованием метода Task.WhenAll,
// который возвращает массив результатов выполнения всех задач.
int[] results = await Task.WhenAll(tasks);

sw.Stop();
Console.WriteLine($"Обнаружено {results.Sum()} пробелов");
Console.WriteLine($"Отработало за {sw.Elapsed.TotalSeconds} секунд");

// Асинхронный метод подсчета пробела в файле
static async Task<int> CountSpacesinFileAsync(string filePath)
{  
    string text = await File.ReadAllTextAsync(filePath);
    return text.Count(x  => x == ' ');
}
