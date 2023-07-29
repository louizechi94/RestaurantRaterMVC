using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantRatyerMVC.Data;
using RestaurantRatyerMVC.Models.RatingModels;

namespace RestaurantRatyerMVC.Services.RatingServices
{
    public class RatingService : IRatingService
    {

        private RestaurantRaterMVCDbContext _context;

        public RatingService(RestaurantRaterMVCDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateRating(RatingCreate model)
        {
            var rating = new Rating()
            {
                RestaurantId = model.RestaurantId,
                
                FoodScore = model.FoodScore,
                CleanlinessScore = model.CleanlinessScore,
                AtmosphereScore = model.AtmosphereScore,

            };
            _context.Ratings.Add(rating);
            return await _context.SaveChangesAsync() == 1;
        }
        public async Task<List<RatingListItem>> GetAllRatings()
        {
            List<RatingListItem> ratings = await _context.Ratings.Include(r => r.Restaurant).Select(r => new RatingListItem()
            {
                RestaurantName = r.Restaurant.Name,
                Id = r.Id,
               
            }).ToListAsync();
            return ratings;

        }

        public async Task<bool> DeleteRating(int id)
        {
            var rating = await _context.Ratings.FindAsync(id);
            if (rating is null)
                return false;
            _context.Ratings.Remove(rating);
            return await _context.SaveChangesAsync() > 0;

        }
        public async Task<RatingDetail> GetRating(int id)
        {
            var rating = await _context.Ratings.Include(r => r.Restaurant).FirstOrDefaultAsync(r => r.Id ==id);
            if (rating is null)
            return null;
            
            return new RatingDetail{
                Id = rating.Id,
                RestaurantName = rating.Restaurant.Name,
                RestaurantId = rating.Restaurant.Id,
                FoodScore = rating.FoodScore,
                CleanlinessScore = rating.CleanlinessScore,
                AtmosphereScore = rating.AtmosphereScore,
            };
            
            
        }
       
}
}