using Infrastructure.Entities;

namespace WebApi.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal DiscountPrice { get; set; }
    public int Hours { get; set; }
    public bool IsBestseller { get; set; }
    public decimal LikesInNumbers { get; set; }
    public decimal LikesInProcent { get; set; }
    public string? Author { get; set; }
    public string? ImageUrl { get; set; } = null!;

    public static implicit operator Course(CourseEntity courseEntity)
    {
        return new Course
        {
            Id = courseEntity.Id,
            Title = courseEntity.Title,
            Price = courseEntity.Price,
            DiscountPrice = courseEntity.DiscountPrice,
            Hours = courseEntity.Hours,
            IsBestseller = courseEntity.IsBestseller,
            LikesInNumbers = courseEntity.LikesInNumbers,
            LikesInProcent = courseEntity.LikesInProcent,
            Author = courseEntity.Author,
            ImageUrl = courseEntity.ImageName
        };
    }

}
