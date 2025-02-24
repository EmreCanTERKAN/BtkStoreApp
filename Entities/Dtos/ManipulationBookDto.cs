using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;
public abstract record ManipulationBookDto
{
    [Required(ErrorMessage = "Title is a requeired field.")]
    [MinLength(2,ErrorMessage = "Kafayı yersin hatalısın..")]
    [MaxLength(50)]
    public string Title { get; init; } = default!;

    [Required(ErrorMessage = "Çıldırırsın... price hatasıı..")]
    [Range(10,1000)]
    public decimal Price { get; init; }
}
