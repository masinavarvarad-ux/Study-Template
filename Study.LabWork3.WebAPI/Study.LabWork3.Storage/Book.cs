using System;

namespace Study.LabWork3.Storage
{
    // Делаем класс public, чтобы его видел проект с контроллерами
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Isbn { get; set; } = string.Empty;
    }
}
