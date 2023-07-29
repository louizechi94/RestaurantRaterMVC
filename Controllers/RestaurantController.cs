using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantRatyerMVC.Data;
using RestaurantRatyerMVC.Models.RestaurantModels;
using RestaurantRatyerMVC.Services.RestaurantServices;

namespace RestaurantRatyerMVC.Controllers
{
    [Route("[controller]")]
    public class RestaurantController : Controller
    {
        private IRestaurantService _service;
        
        private readonly ILogger<RestaurantController> _logger;

        public RestaurantController(ILogger<RestaurantController> logger, IRestaurantService service)
        {
            _logger = logger;
            _service = service;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            List<RestaurantListItem> restaurants = await _service.GetAllRestaurants();
            return View(restaurants);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RestaurantCreate model)
        {
            if (!ModelState.IsValid)
            return View(model);
            await _service.CreateRestaurant(model);
            return RedirectToAction(nameof(Index));
        }
        [Route("{id}")]
        public async Task<IActionResult> Detail(int id)
        {
              
               
              var restaurantDetail = await _service.GetRestaurantById(id);
                if(restaurantDetail is null)
                {
                    return RedirectToAction(nameof(Index));
                }
                
            
               return View(restaurantDetail);
            
          
           
               
                
        }
        [Route("Edit")]
        public async Task<IActionResult> Edit(int id)
        {
              
             RestaurantDetail restaurant = await _service.GetRestaurantById(id);

            if (restaurant == null)
                return RedirectToAction(nameof(Index));
            RestaurantEdit restaurantEdit = new RestaurantEdit()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location,
            };

            return View(restaurantEdit);
            
        }

       [HttpPost]
        public async Task<IActionResult> Edit(int id, RestaurantEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
           if(await _service.UpdateRestaurant(model))
           {
             return RedirectToAction(nameof(Index));
           }
             return View(ModelState);
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
              
            RestaurantDetail restaurant = await _service.GetRestaurantById(id);

            if (restaurant == null)
                return RedirectToAction(nameof(Index));
            RestaurantDetail restaurantEdit = new RestaurantDetail()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Location = restaurant.Location,
            };

            return View(restaurant);
            
        }
        [HttpPost]
        public async Task<IActionResult> Delete (int id)
        {
         
           if(await _service.DeleteRestaurant(id))
           {
             return RedirectToAction(nameof(Index));
           }
             return Error();
        }
    }
}