using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantRatyerMVC.Models.RatingModels;
using RestaurantRatyerMVC.Services.RatingServices;

namespace RestaurantRatyerMVC.Controllers
{
    [Route("[controller]")]
    public class RatingsController : Controller
    {
        private IRatingService _ratingservice;
        private readonly ILogger<RatingsController> _logger;

        public RatingsController(ILogger<RatingsController> logger, IRatingService ratingservice)
        {
            _logger = logger;
            _ratingservice = ratingservice;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            List<RatingListItem> restaurants = await _ratingservice.GetAllRatings();
            return View(restaurants);
        }


        [Route("RatingDetail/{id}")]
        public async Task<IActionResult> RatingRestaurant(int id)
        {
            if (id <= 0)
            {
                ModelState.AddModelError("id", "Invalid Id");
                return View();
            }
            var rating = await _ratingservice.GetRating(id);
            if (rating is null)
            {
                ModelState.AddModelError("rating", $"id: {id} does not exist");
                return View();
            }
            return View(rating);

        }

        [Route("RatingCreate")]
        public async Task<IActionResult> RatingCreate()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateRating(RatingCreate model)
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            if (await _ratingservice.CreateRating(model))
                return RedirectToAction(nameof(Index));
            else
                return View(ModelState);
        }
        [HttpGet,Route("RatingDelete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          
            var rating = await _ratingservice.GetRating(id);

            return View(rating);

        }
        [HttpPost,ValidateAntiForgeryToken]
        [Route("DeleteRating")]
        public async Task<IActionResult> DeleteRating(int id)
        {
            if(await _ratingservice.DeleteRating(id))
            return RedirectToAction(nameof(Index));

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

    }
}