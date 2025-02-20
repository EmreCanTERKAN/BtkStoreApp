using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts;
public interface IBookService
{
    Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges, CancellationToken cancellationToken = default);
    Task<Book> GetOneBookByIdAsync(int id, bool trackChanges, CancellationToken cancellationToken = default);
    Task<Book> CreateOneBookAsync(CreateBookDto request, CancellationToken cancellationToken = default);
    Task UpdateOneBookAsync(int id, UpdateBookDto request, CancellationToken cancellationToken = default);
    Task DeleteOneBookAsync(int id, bool trackChanges, CancellationToken cancellationToken = default);


}
