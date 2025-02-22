namespace Entities.Exceptions;

public sealed class  BookNotFound : NotFound
{
    public BookNotFound(int id) : base($"{id}li kitap bulunamadı..")
    {
        
    }
}