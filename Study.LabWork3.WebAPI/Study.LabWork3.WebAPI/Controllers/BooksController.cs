using Microsoft.AspNetCore.Mvc;
using Study.LabWork3.Storage;
using System.Collections.Generic;
using System.Linq;

namespace Study.LabWork3.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Путь к API: api/books
    public class BooksController : ControllerBase
    {
        // Временное хранилище в памяти вместо реальной БД
        private static readonly List<Book> _books = new()
        {
            new Book { Id = 1, Title = "Преступление и наказание", Author = "Фёдор Достоевский", Year = 1866, Isbn = "978-5-389-04921-5" },
            new Book { Id = 2, Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Year = 1967, Isbn = "978-5-17-112345-6" }
        };

        // 1. Получить все книги (GET: api/books)
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            return Ok(_books);
        }

        // 2. Получить одну книгу по ID (GET: api/books/{id})
        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound(new { Message = $"Книга с ID {id} не найдена." });
            }
            return Ok(book);
        }

        // 3. Добавить новую книгу (POST: api/books)
        [HttpPost]
        public ActionResult<Book> Create([FromBody] Book newBook)
        {
            // Автоматическая генерация нового ID
            newBook.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(newBook);

            return CreatedAtAction(nameof(GetById), new { id = newBook.Id }, newBook);
        }

        // 4. Удалить книгу по ID (DELETE: api/books/{id})
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound(new { Message = $"Книга с ID {id} не найдена." });
            }

            _books.Remove(book);
            return NoContent(); // Успешное удаление без возврата тела
        }
    }
}
