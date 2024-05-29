using System.Diagnostics;

using static SerializationReflection.Serialization;


namespace SerializationReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Замер времени на сериализацию
            Stopwatch stopwatch = new Stopwatch();
            bool showTextInConsole = false;
            int iterationsCount = 10000;
            string serializedString = "";            

            // Создание объекта F
            F test = new ()
            {
                i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5
            };            

            stopwatch.Start();
            for (int i = 0; i < iterationsCount; i++)
            {
                // Сериализация объекта F в строку
                serializedString = Serialize(test);
                if (showTextInConsole)
                {
                    Console.WriteLine(serializedString);
                }
            }

            stopwatch.Stop();            
            Console.WriteLine($"Сериализация {iterationsCount} раз заняла {stopwatch.Elapsed.TotalMilliseconds} мс.");
            stopwatch.Reset();
            
            if (showTextInConsole)
            {
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.ReadKey();
            }

            stopwatch.Start();
            F deserializedF = new();

            for (int i = 0; i < iterationsCount; i++)
            {
                // Десериализация строки обратно в объект F
                deserializedF = Deserialize<F>(serializedString);
                if (showTextInConsole)
                {
                        Console.WriteLine($"Десериализованный объект F: i1: {deserializedF.i1}, i2: {deserializedF.i2}," +
                            $" i3: {deserializedF.i3}, i4: {deserializedF.i4}, i5: {deserializedF.i5}");
                }
            }
            
            stopwatch.Stop();
            Console.WriteLine($"Десиарилизация {iterationsCount} раз заняла {stopwatch.Elapsed.TotalMilliseconds} мс.");
            stopwatch.Reset();

            Console.WriteLine("\nСреда разработки: Microsoft Visual Studio Community 2022 (64-разрядная версия) - Current\r\nВерсия 17.9.5");
        }        
    }
}
