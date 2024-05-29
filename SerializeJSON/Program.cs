using System.Diagnostics;
using Newtonsoft.Json;

namespace SerializationJSON
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // Замер времени на сериализацию
            Stopwatch stopwatch = new Stopwatch();
            bool showTextInConsole = false;
            int iterationsCount = 10000;
            string jsonString = string.Empty;

            // Создание объекта F
            F test = new()
            {
                i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5
            };

            stopwatch.Start();
            for (int i = 0; i < iterationsCount; i++)
            {
                // Сериализация объекта в JSON строку
                jsonString = JsonConvert.SerializeObject(test);
                if (showTextInConsole)
                {
                    Console.WriteLine($"Сериализованная строка JSON: {jsonString}");
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Сериализация {iterationsCount} элементов заняла {stopwatch.Elapsed.TotalMilliseconds} мс.");
            stopwatch.Reset();
            
            if (showTextInConsole)
            {
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();
            }
            
            stopwatch.Start();
            for (int i = 0; i < iterationsCount; i++)
            {
                // Десериализация JSON строки обратно в объект F
                F deserializedF = JsonConvert.DeserializeObject<F>(jsonString)!;
                if (showTextInConsole)
                {                    
                    Console.WriteLine($"Десериализованный объект F: i1: {deserializedF.i1}, i2: {deserializedF.i2}," +
                        $" i3: {deserializedF.i3}, i4: {deserializedF.i4}, i5: {deserializedF.i5}");
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Десериализация {iterationsCount} элементов заняла {stopwatch.Elapsed.TotalMilliseconds} мс.");
            stopwatch.Reset();
        }
    }
}
