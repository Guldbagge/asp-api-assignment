using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos;

public class CourseRegistrationForm
{

    [Required]
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public int Hours { get; set; }
    public bool IsBestseller = false;
    public decimal LikesInNumbers { get; set; }
    public decimal LikesInProcent { get; set; }
    public string? Author { get; set; }
    public string? ImageName { get; set; }
}
