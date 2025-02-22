namespace Entities.Exceptions;

public sealed class  BookNotFound : NotFoundException
{
    public BookNotFound(int id) : base($"{id}li kitap bulunamadı..")
    {
        
    }
}