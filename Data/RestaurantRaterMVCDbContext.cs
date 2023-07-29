using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestaurantRatyerMVC.Data
{
    public class RestaurantRaterMVCDbContext : DbContext
    {
        public RestaurantRaterMVCDbContext(DbContextOptions<RestaurantRaterMVCDbContext> options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Rating> Ratings { get; set; }
      
    }
}