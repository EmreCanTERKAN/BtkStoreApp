using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore;
public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(RepositoryContext context) : base(context)
    {
        
    }

    public void CreateOneBook(Book book) => Create(book);


    public void DeleteOneBook(Book book) => Delete(book);


    public IQueryable<Book> GetAllBook(bool trackChanges) => FindAll(trackChanges);


    public IQueryable<Book> GetOneBookById(bool trackChanges, int id) => FindByCondition(b => b.Id.Equals(id), trackChanges);


    public void UpdateOneBook(Book book) => Update(book);

    

}
