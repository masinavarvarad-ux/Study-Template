using NUnit.Framework;
using Study.LabWork2.Feature.Task1.SubTask2;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask2.DtoModels;

namespace Study.LabWork2.UnitTests.Feature.Task1.SubTask2;

[TestFixture]
public sealed class NumberSetProcessorTests
{
    // тест 1: проверка корректного количества наборов (ровно 15)
    [Test]
    public void Process_WhenExecuted_ProcessesExactly15Sets()
    {
        var processor = new NumberSetProcessor();

        var result = processor.GetResult();

        Assert.That(result.ProcessedSetsCount, Is.EqualTo(15));
        Assert.That(result.Results.Count, Is.EqualTo(15));
    }

    // тест 2: проверка корректности общей суммы
    [Test]
    public void Process_WhenExecuted_CalculatesCorrectTotalSum()
    {
        var processor = new NumberSetProcessor();

        var result = processor.GetResult();

        // проверяем, что общая сумма не равна нулю и посчитана
        Assert.That(result.TotalSum, Is.GreaterThan(0));
    }

    // тест 3: проверка структуры каждого элемента ResultEntryDto
    [Test]
    public void Process_WhenExecuted_SetsCorrectPropertiesInEntries()
    {
        var processor = new NumberSetProcessor();

        var result = processor.GetResult();

        // берем первый элемент для проверки базовых свойств
        var firstEntry = result.Results[0];

        Assert.That(firstEntry.SetNumber, Is.GreaterThanOrEqualTo(1));
        Assert.That(firstEntry.ThreadId, Is.GreaterThan(0));
    }
}
