using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
namespace Presentation.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BookController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllBooks(CancellationToken cancellationToken)
        {
            var books = await _manager.BookService.GetAllBooksAsync(false, cancellationToken);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id, CancellationToken cancellationToken)
        {
            var book = await _manager.BookService.GetOneBookByIdAsync(id, false, cancellationToken);
            return book is null ? NotFound() : Ok(book);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto request, CancellationToken cancellationToken)
        {
            var entity = await _manager.BookService.CreateOneBookAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetBookById), new { id = entity.Id }, entity);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto request, CancellationToken cancellationToken)
        {
            await _manager.BookService.UpdateOneBookAsync(id, request, cancellationToken);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBook(int id, CancellationToken cancellationToken)
        {
            await _manager.BookService.DeleteOneBookAsync(id, true, cancellationToken);
            return NoContent();
        }
    }
}
