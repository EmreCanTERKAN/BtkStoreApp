using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore;
public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(RepositoryContext context) : base(context) { }

    public async Task CreateOneBookAsync(Book book) => await CreateAsync(book);

    public async Task DeleteOneBookAsync(Book book) => await DeleteAsync(book);

    public async Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges) => await FindAllAsync(trackChanges);

    public async Task<Book?> GetOneBookByIdAsync(int id, bool trackChanges)
    {
        var result = await FindByConditionAsync(b => b.Id == id, trackChanges);
        return result.FirstOrDefault(); // Eğer kitap yoksa null döndür
    }

    public async Task UpdateOneBookAsync(Book book) => await UpdateAsync(book);

}
