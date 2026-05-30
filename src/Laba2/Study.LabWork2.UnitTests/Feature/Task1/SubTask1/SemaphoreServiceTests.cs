using NUnit.Framework;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask1;

[TestFixture]
public sealed class SemaphoreServiceTests
{
    [Test]
    public void GetVersionName_ReturnsSemaphoreString()
    {
        // создаем сервис через точный путь в проекте
        var service = new study.labwork2.feature.task1.subtask1.SemaphoreService();

        // получаем имя версии синхронизации
        string name = service.GetVersionName();

        // проверяем результат
        Assert.That(name, Is.EqualTo("Semaphore"));
    }
}
