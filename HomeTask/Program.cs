using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        #region Settings
        int size = 100_000;
        //int size = 1_000_000;
        //int size = 10_000_000;

        int numThreads = 2;
        //int numThreads = 6;
        //int numThreads = 8;

        int[] array = Enumerable.Repeat(1, size).ToArray();
        Stopwatch sw = Stopwatch.StartNew();
        #endregion

        // 1.Последовательный подсчет элементов массива
        #region sequentialCalculation
        sw.Start();
        int length = array.Length;
        int sum1 = 0;
        for (int i = 0; i < length; i++)
        {
            sum1 += array[i];
        }
        sw.Stop();
        Console.WriteLine($"1. {sum1} {sw.Elapsed.TotalSeconds}");
        sw.Reset();
        #endregion

        // 2.Подсчет элементов массива с помощью Threads в List
        #region ThreadsInListCalculation
        sw.Start();
        int chunkSize = array.Length / numThreads;
        List<Thread> threads = new List<Thread>();
        int[] partialSums = new int[numThreads];

        for (int i = 0; i < numThreads; i++)
        {
            int start = i * chunkSize;
            int end = (i == numThreads - 1) ? array.Length : start + chunkSize;
            int threadIndex = i;

            threads.Add(new Thread(() =>
            {
                partialSums[threadIndex] = CalculatePartialSum(array, start, end);
            }));
        }

        foreach (Thread thread in threads)
        {
            thread.Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        int sum2 = 0;
        foreach (var part in partialSums)
        {
            sum2 += part;
        }
        sw.Stop();
        Console.WriteLine($"2. {sum2} {sw.Elapsed.TotalSeconds}");
        sw.Reset();
        #endregion

        // 3.Параллельный подсчет элементов массива с помощью Parallel LINQ
        #region PLINQCalculation
        sw.Start();
        int sum3 = array.AsParallel().WithDegreeOfParallelism(numThreads).Sum();
        sw.Stop();
        Console.WriteLine($"3. {sum3} {sw.Elapsed.TotalSeconds}");
        sw.Reset();
        #endregion        
    }

    private static int CalculatePartialSum(int[] array, int start, int end)
    {
        int sum = 0;
        for (int i = start; i < end; i++)
        {
            sum += array[i];
        };
        return sum;
    }
}