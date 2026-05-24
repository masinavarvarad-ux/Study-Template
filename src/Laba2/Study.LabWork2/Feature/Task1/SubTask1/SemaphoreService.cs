using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace study.labwork2.feature.task1.subtask1;

public sealed class SemaphoreService : IPrimeCounter
{
    private static readonly Semaphore sem = new Semaphore(1, 1);

    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        int totalPrimes = 0;
        List<int> foundList = new List<int>();
        Thread[] threads = new Thread[threadCount];
        int range = (end - start + 1) / threadCount;

        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < threadCount; i++)
        {
            int tStart = start + i * range;
            int tEnd = (i == threadCount - 1) ? end : tStart + range - 1;

            threads[i] = new Thread(() =>
            {
                for (int num = tStart; num <= tEnd; num++)
                {
                    if (IsPrime(num))
                    {
                        sem.WaitOne();
                        try
                        {
                            totalPrimes++;
                            foundList.Add(num);
                        }
                        finally
                        {
                            sem.Release();
                        }
                    }
                }
            });
            threads[i].Start();
        }

        foreach (var t in threads) t.Join();
        sw.Stop();

        return new PrimeCountResultDto
        {
            PrimeCount = totalPrimes,
            ExecutionTime = sw.Elapsed,
            ThreadCount = threadCount,
            SynchronizationType = GetVersionName(),
            FoundPrimes = foundList
        };
    }

    public string GetVersionName() => "Semaphore";

    private static bool IsPrime(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }
}
