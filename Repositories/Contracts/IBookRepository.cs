using Entities.Models;

namespace Repositories.Contracts;
public interface IBookRepository : IRepositoryBase<Book>
{
    IQueryable<Book> GetAllBook(bool trackChanges);
    IQueryable<Book> GetOneBookById(bool trackChanges , int id);
    void CreateOneBook(Book book);
    void UpdateOneBook(Book book);
    void DeleteOneBook(Book book);
}
