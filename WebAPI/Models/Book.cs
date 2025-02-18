namespace WebAPI.Models;

public sealed class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = default!; 
    public decimal Price { get; set; }
}
