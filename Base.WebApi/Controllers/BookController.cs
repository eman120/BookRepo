using Base.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Base.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class BookController(IBookRepository bookRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        var books = await bookRepository.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await bookRepository.GetByIdAsync(id);
        if (book == null)
            return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(Book book)
    {
        await bookRepository.AddAsync(book);
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, Book book)
    {
        if (id != book.Id)
            return BadRequest();

        await bookRepository.UpdateAsync(book);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await bookRepository.DeleteAsync(id);
        return NoContent();
    }
}
