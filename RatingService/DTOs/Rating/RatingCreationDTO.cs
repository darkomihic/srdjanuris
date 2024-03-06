﻿using System.ComponentModel.DataAnnotations;

namespace RatingService.DTOs.Rating
{
    public class RatingCreationDTO
    {
        [Required(ErrorMessage = "Date je obavezan")] public DateOnly date { get; set; }
        [Required(ErrorMessage = "Grade je obavezan")] public int grade { get; set; }
        public string comment { get; set; }
        public string title { get; set; }
    }
}
