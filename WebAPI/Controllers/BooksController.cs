using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController() : ControllerBase
{
    //[HttpGet]
    //public async Task<IActionResult> GetAllBooks()
    //{
    //    var books = await context.Books.ToListAsync();
    //    return Ok(books);
    //}
}
