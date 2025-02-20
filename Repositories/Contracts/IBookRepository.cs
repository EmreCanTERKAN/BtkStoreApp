using Entities.Models;

namespace Repositories.Contracts;
public interface IBookRepository : IRepositoryBase<Book>
{
    Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges , CancellationToken cancellationToken = default);
    Task<Book?> GetOneBookByIdAsync(int id, bool trackChanges , CancellationToken cancellationToken = default);
    Task CreateOneBookAsync(Book book , CancellationToken cancellationToken = default);
    Task UpdateOneBookAsync(Book book, CancellationToken cancellationToken = default);
    Task DeleteOneBookAsync(Book book, CancellationToken cancellationToken = default);
}
