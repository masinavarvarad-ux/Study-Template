using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask2;

public sealed class NumberSetProcessor : INumberSetProcessor
{
    private ProcessingResultDto finalResult;
    private static readonly object locker = new object();

    public void Process()
    {
        var resultsList = new List<ResultEntryDto>();
        int totalSum = 0;
        int setsCount = 15;
        Thread[] threads = new Thread[setsCount];

        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < setsCount; i++)
        {
            int setNumber = i + 1;

            threads[i] = new Thread(() =>
            {
                int calculatedSum = setNumber * 100;

                var entry = new ResultEntryDto
                {
                    SetNumber = setNumber,
                    Sum = calculatedSum,
                    ThreadId = Environment.CurrentManagedThreadId
                };

                lock (locker)
                {
                    resultsList.Add(entry);
                    totalSum += calculatedSum;
                }
            });
            threads[i].Start();
        }

        foreach (var t in threads) t.Join();
        sw.Stop();

        finalResult = new ProcessingResultDto
        {
            Results = resultsList,
            TotalSum = totalSum,
            ExecutionTime = sw.Elapsed,
            ProcessedSetsCount = setsCount
        };
    }

    public ProcessingResultDto GetResult()
    {
        if (finalResult == null)
        {
            Process();
        }
        return finalResult;
    }
}
