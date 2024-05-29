using System.Diagnostics;
using System.Globalization;
using CsvHelper;

namespace CsvSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<F>();
            bool showTextInConsole = false;
            int iterationsCount = 10000;

            for (int i = 0; i < iterationsCount; i++)
            {
                data.Add(new F { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 });
            }

            Stopwatch sw = new Stopwatch();

            string filePath = "C:\\Users\\logov\\Desktop\\task\\data.csv";

            // Сериализация в CSV
            SerializeToCsv(data, filePath);

            sw.Start();

            // Десериализация из CSV
            var deserializedData = DeserializeFromCsv(filePath);

            if (showTextInConsole)
            {
                // Вывод десериализованных данных
                Console.WriteLine("Десериализованные объекты:");
                foreach (var f in deserializedData)
                {
                    Console.WriteLine($"F: {f.i1}, {f.i2}, {f.i3}, {f.i4}, {f.i5}");
                }
            }

            sw.Stop();
            Console.WriteLine($"Десиарелизовано {iterationsCount} элементов за {sw.Elapsed.TotalMilliseconds} мс.");
            sw.Reset();
        }

        public static void SerializeToCsv(IEnumerable<F> data, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(data);
            }
        }

        public static List<F> DeserializeFromCsv(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return new List<F>(csv.GetRecords<F>());
            }
        }
    }
}

