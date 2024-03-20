using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class CourseRegistrationFormViewModel
{
    [Required]
    [Display(Name ="Title")]
    public string Title { get; set; } = null!;
    [Display(Name ="Price")]
    public string? Price { get; set; }
    [Display(Name ="Discount Price")]
    public string? DiscountPrice { get; set; }
    [Display(Name ="Hours")]
    public string? Hours { get; set; }
    [Display(Name ="Is Bestseller")]
    public bool IsBestseller = false;
    [Display(Name ="Likes In Numbers")]
    public string? LikesInNumbers { get; set; }
    [Display(Name ="Likes In Procent")]
    public string? LikesInProcent { get; set; }
    [Display(Name ="Author")]
    public string? Author { get; set; }
    [Display(Name ="Image Url")]
    public string? ImageUrl { get; set; }
}
