namespace WebAPI.Dtos;

public sealed record CreateBookDto(
    decimal Price,
    string Title);
