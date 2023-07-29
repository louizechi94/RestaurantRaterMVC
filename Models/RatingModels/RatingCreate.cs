using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRatyerMVC.Models.RatingModels
{
    public class RatingCreate
    {
        [Required]
        public int RestaurantId { get; set; }

        [Required]
        [Range(0.0, 10.0, ErrorMessage = "Value >0 and < 10")]
        public double FoodScore { get; set; }

        [Required]
        [Range(0.0, 10.0, ErrorMessage = "Value >0 and < 10")]
        public double CleanlinessScore { get; set; }

        [Required]
        [Range(0.0, 10.0, ErrorMessage = "Value >0 and < 10")]
        public double AtmosphereScore { get; set; }

    }
}