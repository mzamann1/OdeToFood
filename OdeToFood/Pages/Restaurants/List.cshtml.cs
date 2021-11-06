using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {

        [TempData]
        public string Message { get; set; }


        public readonly IConfiguration Config;

        private readonly IRestaurantData restaurantData;


        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }



        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.Config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Restaurants = restaurantData.GetAll();
            }
            else
            {
                Restaurants = restaurantData.GetRestaurantByName(SearchTerm);
            }
        }


    }
}
