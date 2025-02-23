using AutoMapper;
using Entities.Dtos;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;
public class BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper) : IBookService
{
    public async Task<Book> CreateOneBookAsync(CreateBookDto request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            await logger.LogInfoAsync("Parametre boş geldi ve hata döndü");
            throw new ArgumentException(nameof(request));
        }
        
        var book = mapper.Map<Book>(request);
        await manager.Book.CreateOneBookAsync(book);
        await manager.SaveAsync();
        return book;
    }

    public async Task DeleteOneBookAsync(int id, bool trackChanges, CancellationToken cancellationToken = default)
    {
        var book = await manager.Book.GetOneBookByIdAsync(id, false);
        if (book is null)
        {
            await logger.LogInfoAsync("Parametre boş geldi ve hata döndü");
            throw new BookNotFoundException(id); 
        }
        await manager.Book.DeleteOneBookAsync(book);
        await manager.SaveAsync();

    }

    public async Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges, CancellationToken cancellationToken = default)
    {
        var book = await manager.Book.GetAllBooksAsync(trackChanges);
        return mapper.Map<IEnumerable<BookDto>>(book);
    }

    public async Task<Book> GetOneBookByIdAsync(int id, bool trackChanges, CancellationToken cancellationToken = default)
    {
        var entity = await manager.Book.GetOneBookByIdAsync(id, trackChanges, cancellationToken);
        if (entity is null)
        {
            await logger.LogInfoAsync("Parametre boş geldi ve hata döndü");
            throw new BookNotFoundException(id);
        }
        return entity;
    }

    public async Task UpdateOneBookAsync(int id, UpdateBookDto request, CancellationToken cancellationToken = default)
    {
        if(request is null)
            throw new ArgumentNullException(nameof(request));

        var book = await manager.Book.GetOneBookByIdAsync(id, false,cancellationToken);

        if (book is null)
            throw new BookNotFoundException(id);

        book = mapper.Map<Book>(request);
        //book.Title = request.Title;
        //book.Price = request.Price;

        await manager.Book.UpdateOneBookAsync(book,cancellationToken);
        await manager.SaveAsync();

    }
}
