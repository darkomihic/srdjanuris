using System.ComponentModel.DataAnnotations;

namespace RatingService.DTOs.Rating
{
    public class RatingUpdateDTO
    {
        [Required(ErrorMessage = "Id je obavezan")] public Guid ratingId { get; set; }
        [Required(ErrorMessage = "Date je obavezan")] public DateOnly date { get; set; }
        [Required(ErrorMessage = "Grade je obavezan")] public int grade { get; set; }
    }
}
