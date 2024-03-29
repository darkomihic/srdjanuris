﻿using System.ComponentModel.DataAnnotations;

namespace RatingService.Entities
{
    public class Rating
    {
        [Key] public Guid ratingId { get; set; }
        [Required] public DateOnly date {  get; set; }
        [Required] public int grade {  get; set; }
        public string comment { get; set;}
        public string title { get; set;}

        [Required] public Guid buyerId { get; set; }
        [Required] public Guid sellerId { get; set; }
        [Required] public Guid purchaseId { get; set; }
    }
}
