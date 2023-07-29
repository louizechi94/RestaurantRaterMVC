using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRatyerMVC.Models.RestaurantModels
{
    public class RestaurantDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        [Display(Name = "Average Score")]
        public double Score { get; set; }
    }
}