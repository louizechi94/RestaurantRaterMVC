using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantRatyerMVC.Models.RatingModels;

namespace RestaurantRatyerMVC.Services.RatingServices
{
    public interface IRatingService
    {
        Task<List<RatingListItem>> GetAllRatings();
        Task<bool> CreateRating(RatingCreate model);
        Task<bool> DeleteRating(int id);
        Task<RatingDetail> GetRating(int id);


    }
}