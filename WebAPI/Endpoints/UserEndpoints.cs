using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;


namespace WebAPI.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndPoints(this WebApplication app)
    {

        app.MapGet("AllBooks", async ([FromServices] IServiceManager manager,CancellationToken cancellationToken) =>
        {
            var books = await manager.BookService.GetAllBooksAsync(false, cancellationToken);
            return Results.Ok(books);
        });


        app.MapGet("BookWithId/{id}", async ([FromServices] IServiceManager manager, int id, CancellationToken cancellationToken) =>
        {
            var book = await manager.BookService.GetOneBookByIdAsync(id, false, cancellationToken);
            return book is null ? Results.NotFound() : Results.Ok(book);
        });


        app.MapPost("Create", async ([FromServices] IServiceManager manager, [FromBody] CreateBookDto request,CancellationToken cancellationToken) =>
        {
            var entity = await manager.BookService.CreateOneBookAsync(request, cancellationToken);

            return Results.Created($"/books/{entity.Id}", entity);
        });


        app.MapPut("UpdateBookWithId/{id}", async ([FromServices] IServiceManager manager, int id, [FromBody] UpdateBookDto request, CancellationToken cancellationToken) =>
        {
            await manager.BookService.UpdateOneBookAsync(id, request, cancellationToken);
            return Results.Ok();
        });


        app.MapDelete("DeleteBookWithId/{id}", async ([FromServices] IServiceManager manager, int id,CancellationToken cancellationToken) =>
        {
            var book = await manager.BookService.GetOneBookByIdAsync(id, false);
            if (book is null)
                return Results.NotFound();

            await manager.BookService.DeleteOneBookAsync(id,true, cancellationToken);
            return Results.NoContent();
        });
    }



}
