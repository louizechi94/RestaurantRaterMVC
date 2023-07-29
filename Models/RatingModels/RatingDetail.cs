using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantRatyerMVC.Data;

namespace RestaurantRatyerMVC.Models.RatingModels
{
    public class RatingDetail
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName{ get; set; }
        public double Score { get; set; }
        public double FoodScore { get; set; }
        public double CleanlinessScore { get; set; }
        public double AtmosphereScore { get; set; }
    }
}