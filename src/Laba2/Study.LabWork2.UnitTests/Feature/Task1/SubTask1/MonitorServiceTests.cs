using NUnit.Framework;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class MonitorServiceTests
{
    [Test]
    public void CountPrimes_Range1To10000_ReturnsCorrectCount()
    {
        // создаем сервис через точный путь в проекте
        var service = new study.labwork2.feature.task1.subtask1.MonitorService();

        // вызываем метод подсчета
        var result = service.CountPrimes(1, 10000, 4);

        // проверяем результат
        Assert.That(result.PrimeCount, Is.EqualTo(1229));
    }
}
