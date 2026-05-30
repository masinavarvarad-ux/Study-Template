using NUnit.Framework;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class MutexServiceTests
{
    [Test]
    public void CountPrimes_WithTwoThreads_ReturnsCorrectCount()
    {
        // создаем сервис через точный путь в проекте
        var service = new study.labwork2.feature.task1.subtask1.MutexService();

        // вызываем метод подсчета
        var result = service.CountPrimes(1, 5000, 2);

        // проверяем результат
        Assert.That(result.PrimeCount, Is.EqualTo(669));
    }
}
