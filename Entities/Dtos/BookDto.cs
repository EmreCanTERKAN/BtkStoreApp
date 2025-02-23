namespace Entities.Dtos;


public sealed record BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public decimal Price { get; set; }
}
