using System;
using study.labwork2.feature.task1.subtask1;
using Study.LabWork2.Feature.Task1.SubTask2;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== ЗАПУСК ЛАБОРАТОРНОЙ РАБОТЫ №2 (ВАРИАНТ 6) ===\n");
        Console.WriteLine("--- Запуск Задания 1.1 (Подсчет простых чисел) ---");

        var monitorService = new MonitorService();
        var mutexService = new MutexService();
        var semaphoreService = new SemaphoreService();

        PrimeCountResultDto resMonitor = monitorService.CountPrimes(1, 10000, 4);
        PrimeCountResultDto resMutex = mutexService.CountPrimes(1, 10000, 4);
        PrimeCountResultDto resSemaphore = semaphoreService.CountPrimes(1, 10000, 4);

        Console.WriteLine("\n--- ИТОГОВЫЙ ОТЧЕТ ПО ЗАДАНИЮ 1.1 ---");
        Console.WriteLine(resMonitor.ToShortString());
        Console.WriteLine(resMutex.ToShortString());
        Console.WriteLine(resSemaphore.ToShortString());
        Console.WriteLine("==================================================\n");

        Console.WriteLine("--- Запуск Задания 1.2 (Обработка 15 наборов) ---");

        var processor = new NumberSetProcessor();
        var res12 = processor.GetResult();

        Console.WriteLine("\n--- ИТОГОВЫЙ ОТЧЕТ ПО ЗАДАНИЮ 1.2 ---");
        Console.WriteLine("а) Результаты по каждому набору:");

        foreach (var entry in res12.Results)
        {
            Console.WriteLine($"   {entry}");
        }

        Console.WriteLine($"\nb) Общий итог по всем наборам (TotalSum): {res12.TotalSum}");
        Console.WriteLine($"c) Время выполнения обработки: {res12.ExecutionTime.TotalMilliseconds:F2} мс");
        Console.WriteLine("==================================================");

        Console.WriteLine("\nПрограмма успешно завершена. Нажмите любую клавишу...");
        Console.ReadKey();
    }
}
