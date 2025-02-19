using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;


namespace WebAPI.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndPoints(this WebApplication app)
    {
        // Tüm kitapları getir
        app.MapGet("AllBooks", async ([FromServices] IRepositoryManager manager) =>
        {
            var books = await manager.Book.GetAllBooksAsync(false);
            return Results.Ok(books);
        });

        // Belirtilen ID'ye sahip kitabı getir
        app.MapGet("BookWithId/{id}", async ([FromServices] IRepositoryManager manager, int id) =>
        {
            var book = await manager.Book.GetOneBookByIdAsync(id, false);
            return book is null ? Results.NotFound() : Results.Ok(book);
        });

        // Yeni kitap oluştur
        app.MapPost("Create", async ([FromServices] IRepositoryManager manager, [FromBody] CreateBookDto request) =>
        {
            var newBook = new Book
            {
                Price = request.Price,
                Title = request.Title
            };

            await manager.Book.UpdateOneBookAsync(newBook);
            await manager.SaveAsync();

            return Results.Created($"/books/{newBook.Id}", newBook);
        });

        // Varolan kitabı güncelle
        app.MapPut("UpdateBookWithId/{id}", async ([FromServices] IRepositoryManager manager, int id, [FromBody] UpdateBookDto request) =>
        {
            var existingBook = await manager.Book.GetOneBookByIdAsync(id, false);
            if (existingBook is null)
                return Results.NotFound();

            existingBook.Price = request.Price;
            existingBook.Title = request.Title;

            await manager.Book.UpdateOneBookAsync(existingBook);
            await manager.SaveAsync();

            return Results.Ok(existingBook);
        });

        // Kitap silme işlemi
        app.MapDelete("DeleteBookWithId/{id}", async ([FromServices] IRepositoryManager manager, int id) =>
        {
            var book = await manager.Book.GetOneBookByIdAsync(id, false);
            if (book is null)
                return Results.NotFound();

            await manager.Book.CreateOneBookAsync(book);
            await manager.SaveAsync();

            return Results.NoContent();
        });
    }



}
