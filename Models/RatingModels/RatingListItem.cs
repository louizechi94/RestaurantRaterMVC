using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRatyerMVC.Models.RatingModels
{
    public class RatingListItem
    {
        [Display(Name = "Restaurant")]
        public string RestaurantName { get; set; }
        public int Id { get; set; }
       

    }
}