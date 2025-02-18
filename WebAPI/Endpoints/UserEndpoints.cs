using Microsoft.EntityFrameworkCore;
using WebAPI.Dtos;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndPoints(this WebApplication app)
    {
        app.MapGet("AllUser", async (RepositoryContext context) =>
        {
            var books = await context.Books.ToListAsync();
            return books;
        });

        app.MapGet("UserWithId", async (RepositoryContext context, int id) =>
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book is null)
                return Results.NotFound();

            return Results.Ok(book);
        });

        app.MapPost("Create", async (RepositoryContext context, CreateBookDto request) =>
        {
            using var transaction = await context.Database.BeginTransactionAsync(); // Transaction başlatılıyor
            try
            {
                var user = new Book
                {
                    Price = request.Price,
                    Title = request.Title
                };

                // Veritabanına ekleme işlemi
                await context.Books.AddAsync(user);
                await context.SaveChangesAsync();

                // Eğer burada başka işlemler yapıyorsanız ve hata oluşmazsa, commit ediyoruz
                await transaction.CommitAsync();

                return Results.Created($"/books/{user.Id}", user);
            }
            catch (Exception e)
            {
                // Eğer hata olursa, tüm işlemi geri alıyoruz (rollback)
                await transaction.RollbackAsync();
                return Results.BadRequest($"An error occurred: {e.Message}");
            }
        });

        app.MapPut("OneBookWithId", async (RepositoryContext context, int id, UpdateBookDto request) =>
        {
            var user = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            using var transaction = await context.Database.BeginTransactionAsync(); // Transaction başlatılıyor
            try
            {
                user = new Book
                {
                    Price = request.Price,
                    Title = request.Title
                };

                // Veritabanına ekleme işlemi
                await context.Books.AddAsync(user);
                await context.SaveChangesAsync();

                // Eğer burada başka işlemler yapıyorsanız ve hata oluşmazsa, commit ediyoruz
                await transaction.CommitAsync();

                return Results.Created($"/books/{user.Id}", user);
            }
            catch (Exception e)
            {
                // Eğer hata olursa, tüm işlemi geri alıyoruz (rollback)
                await transaction.RollbackAsync();
                return Results.BadRequest($"An error occurred: {e.Message}");
            }
        });

        app.MapDelete("BookWithId", async (RepositoryContext context, int id) =>
        {
            var user = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            using var transaction = await context.Database.BeginTransactionAsync(); // Transaction başlatılıyor
            try
            {
               
                // Veritabanına ekleme işlemi
                context.Books.Remove(user!);
                await context.SaveChangesAsync();

                // Eğer burada başka işlemler yapıyorsanız ve hata oluşmazsa, commit ediyoruz
                await transaction.CommitAsync();

                return Results.NoContent();
            }
            catch (Exception e)
            {
                // Eğer hata olursa, tüm işlemi geri alıyoruz (rollback)
                await transaction.RollbackAsync();
                return Results.BadRequest($"An error occurred: {e.Message}");
            }
        });

    }
}
