using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;
public class BookManager(IRepositoryManager manager) : IBookService
{
    public async Task<Book> CreateOneBookAsync(CreateBookDto request, CancellationToken cancellationToken = default)
    {
        if (request is null)
            throw new ArgumentException(nameof(request));
        
        var book = new Book
        {
            Price = request.Price,
            Title = request.Title
        };
        await manager.Book.CreateOneBookAsync(book);
        await manager.SaveAsync();
        return book;
    }

    public async Task DeleteOneBookAsync(int id, bool trackChanges, CancellationToken cancellationToken = default)
    {
        var book = await manager.Book.GetOneBookByIdAsync(id, false);
        if (book is null)
            throw new ArgumentException(nameof(book));
        await manager.Book.DeleteOneBookAsync(book);
        await manager.SaveAsync();

    }

    public Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges, CancellationToken cancellationToken = default)
    {
        return manager.Book.GetAllBooksAsync(trackChanges);
    }

    public async Task<Book> GetOneBookByIdAsync(int id, bool trackChanges, CancellationToken cancellationToken = default)
    {
        var entity = await manager.Book.GetOneBookByIdAsync(id, trackChanges, cancellationToken);
        if (entity is null)
            throw new InvalidOperationException($"No Book Found with by {id}");
        return entity;
    }

    public async Task UpdateOneBookAsync(int id, UpdateBookDto request, CancellationToken cancellationToken = default)
    {
        if(request is null)
            throw new ArgumentNullException(nameof(request));

        var book = await manager.Book.GetOneBookByIdAsync(id, false,cancellationToken);

        if (book is null)
            throw new InvalidOperationException($"No Book Found with by {id}");

        book.Title = request.Title;
        book.Price = request.Price;

        await manager.Book.UpdateOneBookAsync(book,cancellationToken);
        await manager.SaveAsync();

    }
}
